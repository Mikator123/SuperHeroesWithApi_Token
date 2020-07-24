using Model.Interfaces;
using Models.Global.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ToolBoxDB;

namespace Models.Global.Repositories
{
    public class SuperHeroRepository : ICRUDRepository<SuperHeroGlobal>
    {
        public Connection _connection;
        public ConnectionStringObj _CoStringObj;
        public SuperHeroRepository()
        {
            _CoStringObj = new ConnectionStringObj(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBNEW;Integrated Security=True;");
            _connection = new Connection(SqlClientFactory.Instance, _CoStringObj);
        }

        public void Create(SuperHeroGlobal entity)
        {
            Command cmd = new Command("CreateSuperHero", true);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("strenght", entity.Strenght);
            cmd.AddParameter("intelligence", entity.Intelligence);
            cmd.AddParameter("stamina", entity.Stamina);
            cmd.AddParameter("charism", entity.Charism);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Delete(int id)
        {
            Command cmd = new Command("DeleteSuperHero", true);
            cmd.AddParameter("id", id);
            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<SuperHeroGlobal> GetAll()
        {
            Command cmd = new Command("SELECT * FROM SuperHeroes");
            return _connection.ExecuteReader(cmd, (reader) => new SuperHeroGlobal()
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Strenght = (int)reader["Strenght"],
                Intelligence = (int)reader["Intelligence"],
                Stamina = (int)reader["Stamina"],
                Charism = (int)reader["Charism"],
            });
        }

        public SuperHeroGlobal GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM SuperHeroes WHERE id = @id");
            cmd.AddParameter("id", id);
            return _connection.ExecuteReader(cmd, (reader) => new SuperHeroGlobal()
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Strenght = (int)reader["Strenght"],
                Intelligence = (int)reader["Intelligence"],
                Stamina = (int)reader["Stamina"],
                Charism = (int)reader["Charism"],
            }).SingleOrDefault();
        }

        public void Update(SuperHeroGlobal entity)
        {
            Command cmd = new Command("UpdateSuperHeroes", true);
            cmd.AddParameter("name", entity.Name);
            cmd.AddParameter("strenght", entity.Strenght);
            cmd.AddParameter("intelligence", entity.Intelligence);
            cmd.AddParameter("stamina", entity.Stamina);
            cmd.AddParameter("charism", entity.Charism);
            _connection.ExecuteNonQuery(cmd);
        }
    }
}
