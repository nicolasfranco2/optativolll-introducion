using Dapper;
using Optativolll_Introduccion.Repositorios.DetalleFacturas;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Optativolll_Introduccion.repositorios.Factura
{
    public class DetalleFacturaRepository
    {
        private readonly string _connectionString;

        public DetalleFacturaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Add(DetalleFactura detalleFactura)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO Detalle_factura 
                            (Id_Factura, Id_Producto, Cantidad_producto, Subtotal) 
                            VALUES 
                            (@Id_Factura, @Id_Producto, @Cantidad_producto, @Subtotal)";
                var result = connection.Execute(sql, detalleFactura);
                return result > 0;
            }
        }

        public IEnumerable<DetalleFactura> List()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Detalle_factura";
                return connection.Query<DetalleFactura>(sql).ToList();
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Detalle_factura WHERE Id = @Id";
                var result = connection.Execute(sql, new { Id = id });
                return result > 0;
            }
        }

        public bool Update(DetalleFactura detalleFactura)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE Detalle_factura 
                            SET Id_Factura = @Id_Factura, 
                                Id_Producto = @Id_Producto, 
                                Cantidad_producto = @Cantidad_producto, 
                                Subtotal = @Subtotal 
                            WHERE Id = @Id";
                var result = connection.Execute(sql, detalleFactura);
                return result > 0;
            }
        }

        public DetalleFactura GetDetalleFacturaById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Detalle_factura WHERE Id = @Id";
                return connection.QueryFirstOrDefault<DetalleFactura>(sql, new { Id = id });
            }
        }
    }
}
