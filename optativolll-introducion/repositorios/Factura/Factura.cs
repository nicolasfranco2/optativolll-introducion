using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optativolll_introducion.repositorios.Factura
{
    public class Factura
    {
        //Propiedades
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string NroFactura { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Total { get; set; }
        public decimal TotalIva5 { get; set; }
        public decimal TotalIva10 { get; set; }
        public decimal TotalIva { get; set; }
        public string TotalLetras { get; set; }
        public string Sucursal { get; set; }

        // Constructor por defecto
        public Factura()
        {
        }

        // Constructor con parámetros
        public Factura(int id, int idCliente, string nroFactura, DateTime fechaHora, decimal total, decimal totalIva5, decimal totalIva10, decimal totalIva, string totalLetras, string sucursal)
        {
            Id = id;
            IdCliente = idCliente;
            NroFactura = nroFactura;
            FechaHora = fechaHora;
            Total = total;
            TotalIva5 = totalIva5;
            TotalIva10 = totalIva10;
            TotalIva = totalIva;
            TotalLetras = totalLetras;
            Sucursal = sucursal;
        }
    }
}
