using System;
using System.Data.SqlClient;

namespace StarWarsManageShip.Services
{
    public abstract class ISqlManageService
    {
        protected SqlConnection MyConn;
        public ISqlManageService(string str)
        {
            MyConn = new SqlConnection(str);
        }
        protected SqlDataReader Obter(string sql)
        {
            try
            {
                SqlCommand command = new SqlCommand(sql, MyConn);
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (System.Exception)
            { return null; }

        }
        protected bool ExecuteSql(string sql)
        {
            try
            {
                MyConn.Open();
                SqlCommand command = new SqlCommand(sql, MyConn);
                command.ExecuteNonQuery();
            } catch (Exception e)
            { 
                Console.WriteLine($"Erro: {e.Message} \n Houve um erro com Sql {sql}");
                return false;
            } finally
            {
                MyConn.Close();
            }

            return true;
        }
    }
}