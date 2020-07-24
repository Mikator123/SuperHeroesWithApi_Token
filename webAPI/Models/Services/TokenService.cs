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
    public sealed class TokenService
    {
        #region Singleton
        private static TokenService _instance;



        public static TokenService Instance
        {
            get
            {
                return _instance ?? (_instance = new TokenService());
            }
        }
        #endregion



        private const string PassPhrase = "@?*w*92%&+d_pxTU8j3gUMsDDkU*pr@fvva*u5CBMV&Qpju$xsbx2s#UM3uhSrCB^2=pk&53JDB69SYV*48=YaQFjRTcQLPLA#sFVjZjb5ja=mkAuh?Yb*T5!G6mHf_+Zy$e5km@*fjEBBzcK8g!H4QCU*vYrEAE^p9TBUmCfPQSyC!f6tpQyBYKrT!AaMLycJL@94m94-tNmWa6b&Jw@s+2hqF2YB_G_+3k?uZU4L*gT5f5aK2F5_TvnEvtr7vE&";
        private JwtSecurityTokenHandler _handler;
        private JwtHeader _header;
        public JwtHeader Header
        {
            get
            {
                return _header ?? (_header = new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PassPhrase)),
                        SecurityAlgorithms.HmacSha512)));
            }
        }



        public JwtSecurityTokenHandler Handler
        {
            get
            {
                return _handler ?? (_handler = new JwtSecurityTokenHandler());
            }
        }



        public string EncodeToken(UserGlobal user)
        {
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                Header,
                new JwtPayload(
                    issuer: null,
                    audience: null,
                    claims: new Claim[]
                    {
                        new Claim("Id", user.Id.ToString()),
                        new Claim("LastName", user.LastName),
                        new Claim("FirstName", user.FirstName),
                        new Claim("Login", user.Login),
                    },
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddDays(1)
                    )
                );



            return Handler.WriteToken(jwtSecurityToken);
        }



        public UserGlobal DecodeToken(string token)
        {
            UserGlobal user = null;
            token = token.Replace("Bearer ", "");
            JwtSecurityToken jwtSecurityToken = Handler.ReadJwtToken(token);
            if (jwtSecurityToken.ValidFrom <= DateTime.Now && jwtSecurityToken.ValidTo >= DateTime.Now)
            {
                JwtPayload payload = jwtSecurityToken.Payload;
                string test = Handler.WriteToken(new JwtSecurityToken(Header, payload));



                if (token == test)
                {
                    payload.TryGetValue("Id", out object id);
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



            return user;
        }
    }
}