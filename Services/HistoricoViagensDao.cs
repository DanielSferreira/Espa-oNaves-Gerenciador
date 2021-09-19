using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using StarWarsManageShip.Models;

namespace StarWarsManageShip.Services
{
    public class HistoricoViagensDao : ISqlManageService
    {
        public HistoricoViagensDao(string str)
            : base(str) { }

        public List<HistoricoViagens> Obter()
        {
            List<HistoricoViagens> hv = new List<HistoricoViagens>();
            MyConn.Open();
            SqlDataReader reader = Obter("select * from HistoricoViagens");

            while (reader.Read())
                hv.Add(new HistoricoViagens()
                {
                    Id = reader.GetInt32(0),
                    IdPiloto = reader.GetInt32(1),
                    IdNave = reader.GetInt32(2),
                    dtSaida = reader.GetDateTime(3),
                    dtChegada = reader.GetDateTime(4),
                    IdPlaneta = reader.GetInt32(5)
                });

            reader.Close();
            MyConn.Close();
            return hv;
        }

        public bool insert(int idPiloto, int idNave, int IdPlaneta, DateTime dataSaida, DateTime dataChegada = new DateTime())
        {
            var sql = $"insert into HistoricoViagens (idPiloto, idNave, dtSaida, dtChegada, IdPlaneta) values ({idPiloto}, {idNave}, '{dataSaida}', '{dataChegada}', {IdPlaneta});";
            return ExecuteSql(sql);
        }
        public bool update(int id, DateTime dataChegada)
        {
            var sql = $"UPDATE HistoricoViagens SET dtChegada='{dataChegada}' WHERE IdPiloto={id} and dtSaida = (select MAX(dtSaida) from HistoricoViagens as hv) ;";
            return ExecuteSql(sql);
        }
    }
}