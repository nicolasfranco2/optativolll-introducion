using Npgsql;
using optativolll_introducion.repositorios.Conexiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optativolll_introducion.repositorios.Factura
{
    public class FacturaRepository
    {
        NpgsqlConnection connection;


        public FacturaRepository(string coconnectionstring)
        {

            connection = new ConexionBD(coconnectionstring).OpenConnection();
        }

        public bool add(Factura factura)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO public.factura (nro_factura, fecha_hora, total, total_iva5, total_iva10, total_iva, total_letras, sucursal) " +
                    "VALUES (@NroFactura, @FechaHora, @Total, @TotalIva5, @TotalIva10, @TotalIva, @TotalLetras, @Sucursal)";
                cmd.Parameters.AddWithValue("@NroFactura", factura.NroFactura);
                cmd.Parameters.AddWithValue("@FechaHora", factura.FechaHora);
                cmd.Parameters.AddWithValue("@Total", factura.Total);
                cmd.Parameters.AddWithValue("@TotalIva5", factura.TotalIva5);
                cmd.Parameters.AddWithValue("@TotalIva10", factura.TotalIva10);
                cmd.Parameters.AddWithValue("@TotalIva", factura.TotalIva);
                cmd.Parameters.AddWithValue("@TotalLetras", factura.TotalLetras);
                cmd.Parameters.AddWithValue("@Sucursal", factura.Sucursal);
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
        public bool Update(Factura factura)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE factura SET nro_factura = @NroFactura, fecha_hora = @FechaHora, total = @Total, total_iva5 = @TotalIva5, total_iva10 = @TotalIva10, total_iva = @TotalIva, total_letras = @TotalLetras, sucursal = @Sucursal WHERE id = @Id";
                    cmd.Parameters.AddWithValue("@NroFactura", factura.NroFactura);
                    cmd.Parameters.AddWithValue("@FechaHora", factura.FechaHora);
                    cmd.Parameters.AddWithValue("@Total", factura.Total);
                    cmd.Parameters.AddWithValue("@TotalIva5", factura.TotalIva5);
                    cmd.Parameters.AddWithValue("@TotalIva10", factura.TotalIva10);
                    cmd.Parameters.AddWithValue("@TotalIva", factura.TotalIva);
                    cmd.Parameters.AddWithValue("@TotalLetras", factura.TotalLetras);
                    cmd.Parameters.AddWithValue("@Sucursal", factura.Sucursal);
                    cmd.Parameters.AddWithValue("@Id", factura.Id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Devuelve true si se actualizó al menos una fila
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Factura GetFacturaById(int id)
        {
            Factura factura = null;

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
                            factura = new Factura
                            (

                        id: reader.GetInt32(reader.GetOrdinal("Id")),
                        idCliente: reader.GetInt32(reader.GetOrdinal("IdCliente")),
                        nroFactura: reader.GetString(reader.GetOrdinal("NroFactura")),
                        fechaHora: reader.GetDateTime(reader.GetOrdinal("FechaHora")),
                        total: reader.GetDecimal(reader.GetOrdinal("Total")),
                        totalIva5: reader.GetDecimal(reader.GetOrdinal("TotalIva5")),
                        totalIva10: reader.GetDecimal(reader.GetOrdinal("TotalIva10")),
                        totalIva: reader.GetDecimal(reader.GetOrdinal("TotalIva")),
                        totalLetras: reader.GetString(reader.GetOrdinal("TotalLetras")),
                        sucursal: reader.GetString(reader.GetOrdinal("Sucursal"))
                         );
                        }
                    }
                }
            }


            catch (Exception ex)
            {
                throw ex;
            }

            return factura;
        }



        public List<Factura> list()
        {

            List<Factura> factura = new List<Factura>();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "select * from factura";
            var list = cmd.ExecuteReader();

            while (list.Read())
            {
                factura.Add(new Factura
                {
                    NroFactura = list.GetString(2),
                    FechaHora = list.GetDateTime(3),
                    Total = list.GetDecimal(4),
                    TotalIva5 = list.GetDecimal(5),
                    TotalIva10 = list.GetDecimal(6),
                    TotalIva = list.GetDecimal(7),
                    TotalLetras = list.GetString(8),
                    Sucursal = list.GetString(9)
                });


            }
            return factura;

        }
    }
}
