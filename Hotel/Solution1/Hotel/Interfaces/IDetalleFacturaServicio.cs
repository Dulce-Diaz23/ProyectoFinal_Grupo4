using Modelos;

namespace Hotel.Interfaces
{
    public interface IDetalleFacturaServicio
    {
        Task<bool> Nuevo(DetalleFactura detalleFactura);
    }
}
