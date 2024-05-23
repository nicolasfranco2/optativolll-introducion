using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optativolll_introducion.repositorios.Sucursal
{
    public class Sucursal
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string whatsapp { get; set; }
        public string mail { get; set; }
        public string estado { get; set; }

        public Sucursal()
        {
        }

        public Sucursal(int id, string descripcion, string direccion, string telefono, string whatsapp, string mail, string estado)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.direccion = direccion;
            this.telefono = telefono;
            this.whatsapp = whatsapp;
            this.mail = mail;
            this.estado = estado;
        }
    }
}
