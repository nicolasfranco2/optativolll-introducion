using optativolll_introducion.repositorios.Factura;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace optativolll_introducion.services.Logica
{
    public class FacturaServices
    {
        private FacturaRepository factura_reopo;

        public FacturaServices(string connectionstring)
        {


            factura_reopo = new FacturaRepository(connectionstring);


        }

        public bool Insertar_Factura(Factura factura) {
            if (ValidarDatos(factura))
            {
                return factura_reopo.add(factura);
            }
            else
            {
                throw new Exception("Error en la validacion de datos");
            }
        }
        public List<Factura> listado()
        {

            return factura_reopo.list();
        }

        public bool ValidarDatos(Factura factura)
        {
             
            if (factura == null)
                return false;
          
            if (string.IsNullOrEmpty(factura.NroFactura))
                return false;
            if (factura.FechaHora == DateTime.MinValue)
                return false;
            if (factura.Total == 0)
                return false;
            if (factura.TotalIva5 == 0)
               return false;
            if (factura.TotalIva10 == 0)
                return false;
            if (factura.TotalIva == 0)
                return false;
            if (string.IsNullOrEmpty(factura.TotalLetras))
                return false;
            if (string.IsNullOrEmpty(factura.Sucursal))
                return false;
           

            return true;


        }

    

    public bool EliminaFactura(int id)
    {
        var Cliente = factura_reopo.GetFacturaById(id);
        if (Cliente == null)
        {
            throw new ArgumentException($"No se puede eliminar el cliente con ID {id} porque no existe en la base de datos.");
        }
        return factura_reopo.Delete(id);
    }

    public bool ActualizarFactura(Factura factura)
    {
        // Verificar si el cliente existe antes de actualizarlo
        var clienteExistente = factura_reopo.GetFacturaById(factura.Id);
        if (clienteExistente == null)
        {
            throw new ArgumentException($"No se puede actualizar el cliente con ID {factura.Id} porque no existe en la base de datos.");
        }

        // Validar los datos del cliente
        if (!ValidarDatos(factura))
        {
            throw new ArgumentException("Error en la validación de los datos del cliente.");
        }

        // Actualizar el cliente en el repositorio
        return factura_reopo.Update(factura);
    }


    public Factura GetFacturaById(int id)
    {
        // Llamar al método correspondiente del repositorio para obtener el cliente por su ID
        return factura_reopo.GetFacturaById(id);
    }

}
}


