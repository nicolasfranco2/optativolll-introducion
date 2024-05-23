using Npgsql;
using Dapper;
using optativolll_introducion.repositorios.Conexiones;
using Stripe.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
namespace optativolll_introducion.repositorios.Cliente
{
    public class ClienteRepository
    {

        IDbConnection conectionbd;
        

        public ClienteRepository(string connectionstring)
        {

            conectionbd = new ConexionBD(connectionstring).OpenConnection();
        }


        public bool add(Cliente cliente)
        {
            try
            {
                /* *************************
                 *   Metodo con Dapper
                 * *************************
                 */

                conectionbd.Execute("INSERT INTO public.cliente(nombre, apellido, documento, direccion, mail, celular, estado)" +
                    $"Values(@nombre, @apellido, @documento, @direccion, @mail, @celular, @estado)", cliente);

                return true;

                /**************************************************
                 *               Metodo sin Dapper
                 * *************************************************
                 * var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO public.cliente(id, idbanco, nombre, apellido, documento, direccion, mail, celular, estado))" +
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
                return true;*/

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public bool Delete(int id)
        {
            conectionbd.Execute($"DELETE FROM cliente WHERE id = {id}");

            return true;
        }

        /*
            try
            {
                using (var cmd = conectionbd.CreateCommand())
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
        */

        public bool Update(Cliente cliente)
        {
            try
            {
                conectionbd.Execute("UPDATE public.cliente SET idbanco=0, nombre='', apellido='', documento='', direccion='', mail='', celular='', estado=''WHERE id = @id", cliente);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
            public Cliente GetClienteById(int id)
            {
                try
                {
                    conectionbd.Open();
                    return conectionbd.QueryFirstOrDefault<Cliente>(
                        "SELECT * FROM cliente WHERE id = @Id",
                        new { Id = id }
                    );
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el cliente", ex);
                }
            } 
                /*
                public Cliente GetClienteById(int id)
                {
                    Cliente cliente = null;

                    try
                    {
                        using (var cmd = conectionbd.CreateCommand())
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


                /************************
                 *   Metodo con Dapper
                 * ***********************
                 */
                public IEnumerable<Cliente> list()
        {
            return conectionbd.Query<Cliente>("select * from cliente");
        }
    




            /************************
             *   Metodo sin Dapper
             * ***********************
             *
        {
            List<Cliente> cliente = new List<Cliente>();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT id, idbanco, nombre, apellido, documento, direccion, mail, celular, estado FROM public.cliente;";
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cliente.Add(new Cliente
                {
                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                    Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                    Documento = reader.GetString(reader.GetOrdinal("Documento")),
                    Mail = reader.GetString(reader.GetOrdinal("Mail")),
                    Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                    Celular = reader.GetString(reader.GetOrdinal("Celular")),
                    Estado = reader.GetString(reader.GetOrdinal("Estado"))
                });

            
            }


            return cliente;

        }*/
    }
}

