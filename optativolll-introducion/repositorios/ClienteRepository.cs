using Npgsql;
using optativolll_introducion.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using optativolll_introducion.repositorios;
namespace optativolll_introducion.repositorios
{
    public class ClienteRepository
    {
        NpgsqlConnection connection;

        public ClienteRepository(string connectionstring)
        {

            connection = new ConexionBD(connectionstring).OpenConnection();
        }


        public bool add(Cliente cliente)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "insert into Cliente (nombre, apellido,documento,mail,celular,estado,direccion)" +
                    $"Values(" +
                    $"'{cliente.Nombre}'," +
                    $"'{cliente.Apellido}'," +
                    $"'{cliente.Documento}'," +
                    $"'{cliente.Mail}'," +
                    $"'{cliente.Direccion}'," +
                    $"'{cliente.Celular}'," +
                    $"'{cliente.Estado}')";
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public bool Delete(int id)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM cliente WHERE id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(Cliente cliente)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE cliente SET nombre = @Nombre, apellido = @Apellido, documento = @Documento, mail = @Mail, celular = @Celular, estado = @Estado, direccion = @Direccion WHERE id = @Id";
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@Documento", cliente.Documento);
                    cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                    cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
                    cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                    cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("@Id", cliente.Id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Devuelve true si se actualizó al menos una fila
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente GetClienteById(int id)
        {
            Cliente cliente = null;

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM cliente WHERE id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                                Documento = reader.GetString(reader.GetOrdinal("Documento")),
                                Mail = reader.GetString(reader.GetOrdinal("Mail")),
                                Celular = reader.GetString(reader.GetOrdinal("Celular")),
                                Estado = reader.GetString(reader.GetOrdinal("Estado")),
                                Direccion = reader.GetString(reader.GetOrdinal("Direccion"))
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cliente;
        }
        public List<Cliente> list()
        {
            List<Cliente> cliente = new List<Cliente>();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "select * from cliente";
            var list = cmd.ExecuteReader();

            while (list.Read())
            {
                cliente.Add(new Cliente {
                    Nombre = list.GetString(1),
                    Apellido = list.GetString(2),
                    Documento = list.GetString(3),
                    Mail = list.GetString(4),
                    Direccion = list.GetString(5),
                    Celular = list.GetString(5),
                    Estado = list.GetString(6)
                });
            
            
            }


            return cliente;

        }
    }
}

