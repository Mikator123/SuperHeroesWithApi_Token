using Model.Interfaces;
using Models.Global.Entities;
using System.Data.SqlClient;
using System.Linq;
using ToolBoxDB;

namespace Models.Global.Repositories
{
    public class AuthRepository : IAuthRepository<UserGlobal>
    {
        public Connection _connection;
        public ConnectionStringObj _CostringObj;

        public AuthRepository()
        {
            _CostringObj = new ConnectionStringObj(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBNEW;Integrated Security=True;");
            _connection = new Connection(SqlClientFactory.Instance, _CostringObj); // connection à la DB via le ctor
        }

        public UserGlobal Login(string login, string password)
        {
            Command cmd = new Command("LoginUser", true); // commande SQL
            cmd.AddParameter("login", login); // paramètre à passer
            cmd.AddParameter("password", password);
            return _connection.ExecuteReader(cmd, (reader) => new UserGlobal() // le retour ExecutReader(plusieurs retours), ExecuteScalar (un retour), ExecuteNonQuerry(le nombre d'ordres DML affectés)
            {
                Id = (int)reader["Id"], // remplissage de l'objet avec les données prises de la DB via le reader
                LastName = reader["LastName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                Login = reader["Login"].ToString()
            }).SingleOrDefault(); // défini si l'objet retourné doit etre unique ou non
        }

        public void Register(UserGlobal entity)
        {
            Command cmd = new Command("CreateUser", true);
            cmd.AddParameter("lastname", entity.LastName);
            cmd.AddParameter("firstname", entity.FirstName);
            cmd.AddParameter("login", entity.Login);
            cmd.AddParameter("password", entity.Password);
            _connection.ExecuteNonQuery(cmd);

        }
    }
}
