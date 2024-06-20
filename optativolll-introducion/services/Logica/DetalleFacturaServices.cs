using Optativolll_Introduccion.repositorios.Factura;
using Optativolll_Introduccion.Repositorios;
using Optativolll_Introduccion.Repositorios.DetalleFacturas;
using System;
using System.Collections.Generic;

namespace optativolll_introducion.services.Logica
{
    public class DetalleFacturaServices
    {
        private readonly DetalleFacturaRepository detalleFacturaRepo;

        public DetalleFacturaServices(string connectionString)
        {
            detalleFacturaRepo = new DetalleFacturaRepository(connectionString);
        }

        public bool Insertar(DetalleFactura detalleFactura)
        {
            if (ValidarDatos(detalleFactura))
            {
                return detalleFacturaRepo.Add(detalleFactura);
            }
            else
            {
                throw new Exception("Error en la validación de datos");
            }
        }

        public IEnumerable<DetalleFactura> GetAll()
        {
            return detalleFacturaRepo.List();
        }

        private bool ValidarDatos(DetalleFactura detalleFactura)
        {
            if (detalleFactura == null)
                return false;
            if (detalleFactura.Id_Factura <= 0)
                return false;
            if (detalleFactura.Id_Producto <= 0)
                return false;
            if (detalleFactura.Cantidad_producto <= 0)
                return false;
            if (detalleFactura.Subtotal < 0)
                return false;

            return true;
        }

        public bool EliminarDetalleFactura(int id)
        {
            return id > 0 ? detalleFacturaRepo.Delete(id) : false;
        }

        public bool Update(DetalleFactura detalleFactura)
        {
            return ValidarDatos(detalleFactura) ? detalleFacturaRepo.Update(detalleFactura) : throw new Exception("Error en la validación de datos");
        }

        public DetalleFactura GetDetalleFacturaById(int id)
        {
            return detalleFacturaRepo.GetDetalleFacturaById(id);
        }
    }
}
