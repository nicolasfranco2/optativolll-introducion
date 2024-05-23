using Npgsql;
using optativolll_introducion.repositorios.Sucursal;
using System.Data;
using Dapper;
using optativolll_introducion.repositorios.Conexiones;
using optativolll_introducion.repositorios.Cliente;



namespace Examenp1.Reposiroty.sucursal
{
    public class SucursalRepository
    {
           IDbConnection conectionbd;

        public SucursalRepository(string connectionString)
        {
            conectionbd = new ConexionBD(connectionString).OpenConnection();
        }

        public bool Add(Sucursal sucursal)
        {
            conectionbd.Execute("NSERT INTO public.sucursal (id, descripcion, direccion, telefono, whatsapp, mail, estado)" +  
                $"Values(@descripcion, @direccion, @telefono, @whatsapp, @mail, @estado )", sucursal);

            return true;
        }

        public bool Delete(int id)
        {
            conectionbd.Execute($"DELETE FROM sucursal WHERE id = {id}");

            return true;
        }

        public bool Update(Sucursal sucursal)
        {
            conectionbd.Execute("UPDATE public.sucursal SET " +
                "descripcion=@nombre, " +
                "direccion=@direccion, "+
                "telefono==@telefono, " +
                "whatsapp=@whatsapp, " +
                "mail=@mail," + 
                "estado==@estado ", sucursal);
            return true;
        }

            public Sucursal GetSucursalById(int id)
        {
            string sql = "SELECT * FROM Sucursal WHERE id = @Id";
            Sucursal sucursal = conectionbd.QuerySingleOrDefault<Sucursal>(sql, new { Id = id });
            return sucursal;
        }

        public IEnumerable<Sucursal> List()
        {
            return conectionbd.Query<Sucursal>("select * from sucursal");
        }
    }
}