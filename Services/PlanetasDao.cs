using System.Collections.Generic;
using System.Data.SqlClient;
using StarWarsManageShip.Models;

namespace StarWarsManageShip.Services
{
    public class PlanetasDao : ISqlManageService
    {
        public PlanetasDao(string str)
            : base(str) { }

        public List<Planetas> Obter()
        {
            MyConn.Open();
            List<Planetas> planetas = new List<Planetas>();
            SqlDataReader reader = Obter("select id, name from dbo.Planetas");

            while (reader.Read())
                planetas.Add(new Planetas()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });

            reader.Close();
            MyConn.Close();
            return planetas;
        }
        public string ObterNomePlaneta(int id)
        {
            string sql = $"select name from dbo.Planetas where Id={id}";
            string res = "";
            SqlDataReader reader;
            try
            {
                MyConn.Open();
                reader = Obter(sql);
                while (reader.Read())
                    res = reader.GetString(0);
                reader.Close();
            }
            catch (System.Exception e) { System.Console.WriteLine($" Erro em ObterPiloto: {e.Message} \n SQL: {sql}"); }
            finally { MyConn.Close(); }
            return res;
        }
        public bool insert(Planetas p)
        {
            var sql = $"INSERT INTO Planetas (Name) VALUES ('{p.Name}');";
            return ExecuteSql(sql);
        }
    }
}