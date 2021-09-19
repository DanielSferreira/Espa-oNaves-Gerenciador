using System.Collections.Generic;
using System.Data.SqlClient;
using StarWarsManageShip.Models;

namespace StarWarsManageShip.Services
{
    public class NavesEspaciaisDao : ISqlManageService
    {
        public NavesEspaciaisDao(string str)
            : base(str) { }

        public List<NavesEspaciais> Obter()
        {
            MyConn.Open();
            List<NavesEspaciais> navesEspaciais = new List<NavesEspaciais>();
            SqlDataReader reader = Obter("select id, model from NavesEspaciais");

            while (reader.Read())
                navesEspaciais.Add(new NavesEspaciais()
                {
                    Id = reader.GetInt32(0),
                    Model = reader.GetString(1)
                });

            reader.Close();
            MyConn.Close();
            return navesEspaciais;
        }

        public bool insert(NavesEspaciais n)
        {
            var sql = $"INSERT INTO NavesEspaciais(Name, Model) VALUES ('{n.Name}', '{n.Model}');";

            return ExecuteSql(sql);
        }

        internal string ObterNomeNave(int idNave)
        {
            string res = "";
            string sql = $"select model from NavesEspaciais where id={idNave}";
            SqlDataReader reader;
            try
            {

                MyConn.Open();
                reader = Obter(sql);
                while (reader.Read())
                    res = reader.GetString(0);
                reader.Close();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine($" Erro em ObterPiloto: {e.Message} \n SQL: {sql}");
                res = "Erro";
            }
            finally
            {
                MyConn.Close();
            }
            return res;
        }
    }
}