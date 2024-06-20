using Optativolll_Introduccion.Repositorios.Productos;
using optativolll_introducion.repositorios.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optativolll_Introduccion.Repositorios.DetalleFacturas
{
    internal class DetalleFactura
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int CantidadProducto { get; set; }
        public decimal Subtotal { get; set; }

        // Relaciones con Factura y Producto
        public Factura Factura { get; set; }
        public Producto Producto { get; set; }
    }
