using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using StarWarsManageShip.Models;

namespace StarWarsManageShip.Services
{
    public class PilotoNaveDao : ISqlManageService
    {
        public PilotoNaveDao(string str)
            : base(str) { }

        public List<PilotoNaves> Obter()
        {
            MyConn.Open();
            List<PilotoNaves> pilotosNaves = new List<PilotoNaves>();
            SqlDataReader reader = Obter("select * from PilotoNaves");

            try
            {
                while (reader.Read())
                    pilotosNaves.Add(new PilotoNaves()
                    {
                        Id = reader.GetInt32(0),
                        IdPiloto = reader.GetInt32(1),
                        IdNave = reader.GetInt32(2),
                        IdPlaneta = reader.GetInt32(3),
                        Autorizado = reader.GetBoolean(4)
                    });
            }
            finally
            {
                reader.Close();
                MyConn.Close();
            }
            return pilotosNaves;
        }

        public PilotoNaves ObterPeloID(int id)
        {
            MyConn.Open();
            PilotoNaves pilotoNaves = new PilotoNaves();
            SqlDataReader reader = Obter($"select * from PilotoNaves where id = {id}");

            try
            {
                while (reader.Read())
                    pilotoNaves = new PilotoNaves()
                    {
                        Id = reader.GetInt32(0),
                        IdPiloto = reader.GetInt32(1),
                        IdNave = reader.GetInt32(2),
                        IdPlaneta = reader.GetInt32(3),
                        Autorizado = reader.GetBoolean(4),
                    };
            }
            finally
            {
                reader.Close();
                MyConn.Close();
            }
            return pilotoNaves;
        }

        public bool insert(int idPiloto, int idNave,int idPlaneta, bool aut)
        {
            var sql = $"insert into PilotoNaves (idPiloto, idNave, idPlaneta, Autorizado) values ({idPiloto}, {idNave}, {idPlaneta}, {1});";
            if (find(idPiloto))
                return ExecuteSql(sql);

            return false;
        }
        public bool find(int idPiloto)
        {
            MyConn.Open();
            SqlDataReader reader = Obter($"select id from PilotoNaves where idPiloto = {idPiloto}");

            try
            { if (!reader.Read()) return true; }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message} \n foi encontrado um valor de pilotonave");
                return false;
            }
            finally
            {
                reader.Close();
                MyConn.Close();
            }
            return false;
        }

        public bool delete(int id)
        {
            var sql = $"DELETE FROM SWShipsManage.dbo.PilotoNaves WHERE Id={id};";

            return ExecuteSql(sql);
        }
    }
}