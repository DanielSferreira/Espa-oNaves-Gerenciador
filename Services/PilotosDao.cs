using System.Collections.Generic;
using System.Data.SqlClient;
using StarWarsManageShip.Models;

namespace StarWarsManageShip.Services
{
    public class PilotosDao : ISqlManageService
    {
        public PilotosDao(string str)
            : base(str) { }

        public List<Pilotos> Obter()
        {
            MyConn.Open();
            List<Pilotos> pilotos = new List<Pilotos>();
            SqlDataReader reader = Obter("select id, name from dbo.Pilotos");

            while (reader.Read())
                pilotos.Add(new Pilotos()
                {
                    Id = reader.GetInt32(0),
                    name = reader.GetString(1)
                });

            reader.Close();
            MyConn.Close();
            return pilotos;
        }

        public string ObterNomePiloto(int id)
        {
            string sql = $"select name from Pilotos where Id={id}";
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
        public bool insert(Pilotos p)
        {
            var sql = $"insert into Pilotos (Name) VALUES ('{p.name}');";
            return ExecuteSql(sql);
        }
    }
}