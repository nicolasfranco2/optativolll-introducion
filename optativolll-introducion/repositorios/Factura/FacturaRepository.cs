using Dapper;
using Npgsql;
using optativolll_introducion.repositorios.Conexiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optativolll_introducion.repositorios.Factura
{
    public class FacturaRepository
    {
        private IDbConnection connection;

        public FacturaRepository(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public void AgregarFactura(Factura factura)
        {
            try
            {
                string sql = "INSERT INTO Factura (IdCliente, NroFactura, FechaHora, Total, " +
                             "TotalIva5, TotalIva10, TotalIva, TotalLetras, Sucursal) " +
                             "VALUES (@IdCliente, @NroFactura, @FechaHora, @Total, @TotalIva5, " +
                             "@TotalIva10, @TotalIva, @TotalLetras, @Sucursal)";
                connection.Execute(sql, factura);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarFactura(Factura factura)
        {
            try
            {
                string sql = "UPDATE Factura SET IdCliente = @IdCliente, NroFactura = @NroFactura, " +
                             "FechaHora = @FechaHora, Total = @Total, TotalIva5 = @TotalIva5, " +
                             "TotalIva10 = @TotalIva10, TotalIva = @TotalIva, TotalLetras = @TotalLetras, " +
                             "Sucursal = @Sucursal WHERE Id = @Id";
                connection.Execute(sql, factura);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarFactura(int id)
        {
            try
            {
                string sql = "DELETE FROM Factura WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Factura ObtenerFactura(int id)
        {
            try
            {
                string sql = "SELECT * FROM Factura WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Factura>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Factura> ObtenerTodasFacturas()
        {
            try
            {
                string sql = "SELECT * FROM Factura";
                return connection.Query<Factura>(sql).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
