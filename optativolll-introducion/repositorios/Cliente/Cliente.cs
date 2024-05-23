using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace optativolll_introducion.repositorios.Cliente
{
    public class Cliente
    {
        public int Id { get; set; }
        public int IdBanco { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Mail { get; set; }

        public string Direccion { get; set; }

        public string Celular { get; set; }
        public string Estado { get; set; }

        public Cliente()
        {
        }
        public Cliente(int id, int idBanco, string nombre, string apellido, string documento, string mail, string celular, string estado, string direccion)
        {
            Id = id;
            IdBanco = idBanco;
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Mail = mail;
            Direccion = direccion;
            Celular = celular;
            Estado = estado;
            Direccion = direccion;
        }
    }
}


