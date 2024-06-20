using Dapper;
using Optativolll_Introduccion.Repositorios.Productos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Optativolll_Introduccion.Repositorios
{
    public class ProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Add(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO Productos 
                            (Descripcion, CantidadMinima, CantidadStock, PrecioCompra, PrecioVenta, Categoria, Marca, Estado) 
                            VALUES 
                            (@Descripcion, @CantidadMinima, @CantidadStock, @PrecioCompra, @PrecioVenta, @Categoria, @Marca, @Estado)";
                var result = connection.Execute(sql, producto);
                return result > 0;
            }
        }

        public IEnumerable<Producto> List()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Productos";
                return connection.Query<Producto>(sql).ToList();
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Productos WHERE Id = @Id";
                var result = connection.Execute(sql, new { Id = id });
                return result > 0;
            }
        }

        public bool Update(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE Productos 
                            SET Descripcion = @Descripcion, 
                                CantidadMinima = @CantidadMinima, 
                                CantidadStock = @CantidadStock, 
                                PrecioCompra = @PrecioCompra, 
                                PrecioVenta = @PrecioVenta, 
                                Categoria = @Categoria, 
                                Marca = @Marca, 
                                Estado = @Estado 
                            WHERE Id = @Id";
                var result = connection.Execute(sql, producto);
                return result > 0;
            }
        }

        public Producto GetProductoById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Productos WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Producto>(sql, new { Id = id });
            }
        }
    }
}
