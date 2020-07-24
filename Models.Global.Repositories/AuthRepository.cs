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
            _connection = new Connection(SqlClientFactory.Instance, _CostringObj);
        }

        public UserGlobal Login(string login, string password)// A CHEQUER
        {
            Command cmd = new Command("LoginUser", true);
            cmd.AddParameter("login", login);
            cmd.AddParameter("password", password);
            return _connection.ExecuteReader(cmd, (reader) => new UserGlobal()
            {
                Id = (int)reader["Id"],
                LastName = reader["LastName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                Login = reader["Login"].ToString()
            }).SingleOrDefault();
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
