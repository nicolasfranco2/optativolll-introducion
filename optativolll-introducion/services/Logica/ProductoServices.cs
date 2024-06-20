using Optativolll_Introduccion.Repositorios.Productos;
using Optativolll_Introduccion.Repositorios;

namespace optativolll_introducion.services.Logica
{
    public class ProductoServices
    {
        private ProductoRepository productoRepo;

        public ProductoServices(string connectionString)
        {
            productoRepo = new ProductoRepository(connectionString);
        }

        public bool Insertar(Producto producto)
        {
            if (ValidarDatos(producto))
            {
                return productoRepo.Add(producto);
            }
            else
            {
                throw new Exception("Error en la validación de datos");
            }
        }

        public IEnumerable<Producto> GetAll()
        {
            return productoRepo.List();
        }

        private bool ValidarDatos(Producto producto)
        {
            if (producto == null)
                return false;
            if (string.IsNullOrEmpty(producto.Descripcion))
                return false;
            if (producto.CantidadMinima < 0)
                return false;
            if (producto.CantidadStock < 0)
                return false;
            if (producto.PrecioCompra < 0)
                return false;
            if (producto.PrecioVenta < 0)
                return false;
            if (string.IsNullOrEmpty(producto.Categoria))
                return false;
            if (string.IsNullOrEmpty(producto.Marca))
                return false;
            if (string.IsNullOrEmpty(producto.Estado))
                return false;

            return true;
        }

        public bool EliminarProducto(int id)
        {
            return id > 0 ? productoRepo.Delete(id) : false;
        }

        public bool Update(Producto producto)
        {
            return ValidarDatos(producto) ? productoRepo.Update(producto) : throw new Exception("Error en la validación de datos");
        }

        public Producto GetProductoById(int id)
        {
            return productoRepo.GetProductoById(id);
        }
    }
}
