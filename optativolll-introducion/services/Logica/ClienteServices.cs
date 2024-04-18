using optativolll_introducion.repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace optativolll_introducion.services.Logica
{
    public class ClienteServices
    {
        private ClienteRepository clienterepo;
        public ClienteServices(string connectionstring)
        {


            clienterepo = new ClienteRepository(connectionstring);


        }
        public bool Insertar(Cliente cliente)
        {
            if (ValidarDatos(cliente))
            {
                return clienterepo.add(cliente);
            }
            else
            {
                throw new Exception("Error en la validacion de datos");
            }
        }

        public List<Cliente> listado()
        {

            return clienterepo.list();
        }

        private bool ValidarDatos(Cliente cliente)
        {

            if (cliente == null)
                return false;
            if (string.IsNullOrEmpty(cliente.Nombre))
                return false;
            if (string.IsNullOrEmpty(cliente.Apellido) && cliente.Nombre.Length < 2)
                return false;
            if (string.IsNullOrEmpty(cliente.Documento))
                return false;
            if (string.IsNullOrEmpty(cliente.Mail))
                return false;

            if (string.IsNullOrEmpty(cliente.Direccion))
                return false;


            if (string.IsNullOrEmpty(cliente.Celular))
                return false;
            if (string.IsNullOrEmpty(cliente.Estado))
                return false;



            return true;
        }
        public bool EliminarCliente(int id)
        {
            var Cliente = clienterepo.GetClienteById(id);
            if (Cliente == null)
            {
                throw new ArgumentException($"No se puede eliminar el cliente con ID {id} porque no existe en la base de datos.");
            }
            return clienterepo.Delete(id);
        }
        public bool ActualizarCliente(Cliente cliente)
        {
            // Verificar si el cliente existe antes de actualizarlo
            var clienteExistente = clienterepo.GetClienteById(cliente.Id);
            if (clienteExistente == null)
            {
                throw new ArgumentException($"No se puede actualizar el cliente con ID {cliente.Id} porque no existe en la base de datos.");
            }

            // Validar los datos del cliente
            if (!ValidarDatos(cliente))
            {
                throw new ArgumentException("Error en la validación de los datos del cliente.");
            }

            // Actualizar el cliente en el repositorio
            return clienterepo.Update(cliente);
        }


        public Cliente GetClienteById(int id)
        {
            // Llamar al método correspondiente del repositorio para obtener el cliente por su ID
            return clienterepo.GetClienteById(id);
        }

    }
}