using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Npgsql;


namespace optativolll_introducion.repositorios.Conexiones
{

    public class ConexionBD
    {
        //private string conncetionString =
        //"Host=localhost;Username=postgres;Password=steamat10;Database=optativoI;Port=5432";
        private string connectionString;
        public ConexionBD(string connectionString)
        {


            this.connectionString = connectionString;

        }

        // Método para establecer una conexión 
        public NpgsqlConnection OpenConnection()
        {
            try
            {
                var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

