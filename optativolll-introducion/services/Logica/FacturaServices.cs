using optativolll_introducion.repositorios.Factura;

public class FacturaService
{
    private readonly FacturaRepository facturaRepository;

    public FacturaService(string connectionString)
    {
        facturaRepository = new FacturaRepository(connectionString);
    }

    public void AgregarFactura(Factura factura)
    {
        if (factura == null)
        {
            throw new ArgumentNullException(nameof(factura), "La factura no puede ser nula.");
        }

        facturaRepository.AgregarFactura(factura);
    }

    public void ActualizarFactura(Factura factura)
    {
        if (factura == null)
        {
            throw new ArgumentNullException(nameof(factura), "La factura no puede ser nula.");
        }

        facturaRepository.ActualizarFactura(factura);
    }

    public void EliminarFactura(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "El ID de la factura debe ser mayor que cero.");
        }

        facturaRepository.EliminarFactura(id);
    }

    public Factura ObtenerFactura(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "El ID de la factura debe ser mayor que cero.");
        }

        return facturaRepository.ObtenerFactura(id);
    }

    public List<Factura> ObtenerTodasFacturas()
    {
        return facturaRepository.ObtenerTodasFacturas();
    }
}
}