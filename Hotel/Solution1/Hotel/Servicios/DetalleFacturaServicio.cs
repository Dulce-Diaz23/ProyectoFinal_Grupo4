using Datos.Interfaces;
using Datos.Repositorios;
using Hotel.Interfaces;
using Modelos;

namespace Hotel.Servicios
{
    public class DetalleFacturaServicio : IDetalleFacturaServicio
    {
        private readonly Config _configuracion;
        private IDetalleFacturaRepositorio detalleFacturaRepositorio;

        public DetalleFacturaServicio(Config config)
        {
            _configuracion = config;
            detalleFacturaRepositorio = new DetalleFacturaRepositorio(config.CadenaConexion);
        }

        public async Task<bool> Nuevo(DetalleFactura detalleFactura)
        {
            return await detalleFacturaRepositorio.Nuevo(detalleFactura);
        }
    }
}
