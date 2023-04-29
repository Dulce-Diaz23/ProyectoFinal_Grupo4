using Modelos;

namespace Datos.Interfaces
{
    public interface IDetalleFacturaRepositorio
    {
        Task<bool> Nuevo(DetalleFactura detalleFactura);
    }
}
