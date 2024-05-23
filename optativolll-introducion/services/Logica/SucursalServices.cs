using Examenp1.Reposiroty.sucursal;
using optativolll_introducion.repositorios.Sucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optativolll_introducion.services.Logica
{
    public class SucursalServices
    {
        public SucursalRepository SucursalRepo;

        public SucursalServices(string connectionString)
        {
            SucursalRepo = new SucursalRepository(connectionString);
        }

        public void Insertar(Sucursal sucursal)
        {
            if (ValidarDatos(sucursal))
                SucursalRepo.Add(sucursal);
            else
                throw new Exception("Error en la validación de datos, favor corregir.");
        }

        public void EliminarSucursal(int id)
        {
            SucursalRepo.Delete(id);
        }

        public IEnumerable<Sucursal> GetAll()
        {
            return SucursalRepo.List();
        }

        private bool ValidarDatos(Sucursal sucursal)
        {

            return true;
        }
    }
}
