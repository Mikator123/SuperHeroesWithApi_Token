using Microsoft.IdentityModel.Tokens;
using Models.Global.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace webAPI.Models.Services
{
    public sealed class TokenService // dispose d'un header(algorithm et type de token) / Payload (datas) / vérify signature
    {
        #region Singleton
        private static TokenService _instance;

        public static TokenService Instance
        {
            get
            {
                return _instance ?? (_instance = new TokenService()); //si l'instance est null, on l'instancie.
            }
        }
        #endregion


        private const string PassPhrase = @"?*w*92%&+d_pxTU8j3gUMsDDkU*pr@fvva*u5CBMV&Qpju$xsbx2s#UM3uhSrCB^2=pk&53JDB69SYV*48=YaQFjRTcQLPLA#sFVjZjb5ja=mkAuh?Yb*T5!G6mHf_+Zy$e5km@*fjEBBzcK8g!H4QCU*vYrEAE^p9TBUmCfPQSyC!f6tpQyBYKrT!AaMLycJL@94m94-tNmWa6b&Jw@s+2hqF2YB_G_+3k?uZU4L*gT5f5aK2F5_TvnEvtr7vE&";
        // la PassPhrase contient un password qui permettra de signer les tokens (enlever les charactères ambigus)
        private JwtSecurityTokenHandler _handler; //

        public JwtSecurityTokenHandler Handler
        {
            get
            {
                return _handler ?? (_handler = new JwtSecurityTokenHandler());
            }
        } // génération du Handler

        private JwtHeader _header;
        public JwtHeader Header
        {
            get
            {
                return _header ?? (_header = new JwtHeader( // si le header est null on initialise
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PassPhrase)), // clef de sércurité -> passphrase
                        SecurityAlgorithms.HmacSha512))); // algorithme d'encryption utilisé
            }
        } // génération du Header

        public string EncodeToken(UserGlobal user) 
        {
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                Header,//fourni le header du token
                new JwtPayload( // fourni le payload du token -> les datas
                    issuer: null, // de qui le token est généré
                    audience: null, // a qui le token est destiné
                    claims: new Claim[] // liste des informations
                    {
                        new Claim("Id", user.Id.ToString()),
                        new Claim("LastName", user.LastName),
                        new Claim("FirstName", user.FirstName),
                        new Claim("Login", user.Login),
                    },
                    notBefore: DateTime.Now, // date de génération du token
                    expires: DateTime.Now.AddDays(1) // date de validité du token
                    )
                );



            return Handler.WriteToken(jwtSecurityToken); // génère le token
        }



        public UserGlobal DecodeToken(string token)
        {
            UserGlobal user = null; // défini le user à null
            token = token.Replace("Bearer ", ""); // supprimer le Bearer du token
            JwtSecurityToken jwtSecurityToken = Handler.ReadJwtToken(token); // permet de récuperer le payload
            if (jwtSecurityToken.ValidFrom <= DateTime.Now && jwtSecurityToken.ValidTo >= DateTime.Now)  // vérification de la validité du token
            {
                JwtPayload payload = jwtSecurityToken.Payload; // 
                string test = Handler.WriteToken(new JwtSecurityToken(Header, payload)); // regénère le token sur base des information du payload

                if (token == test) // si vrais = authentifié
                {
                    payload.TryGetValue("Id", out object id); // défini les info reçue
                    payload.TryGetValue("LastName", out object lastName);
                    payload.TryGetValue("FirstName", out object firstName);
                    payload.TryGetValue("Login", out object login);
                    user = new UserGlobal()
                    {
                        Id = int.Parse((string)id),
                        LastName = (string)lastName,
                        FirstName = (string)firstName,
                        Login = (string)login,
                    };
                }
            }



            return user; // si le token est pas valid, le user retourné sera null.
        }
    }
}