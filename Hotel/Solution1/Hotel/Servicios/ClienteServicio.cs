using Datos.Interfaces;
using Datos.Repositorios;
using Hotel.Interfaces;
using Hotel.Pages.MisUsuarios;
using Modelos;

namespace Hotel.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly Config _configuracion;
        private IClienteRepositorio clienteRepositorio;

        public ClienteServicio(Config config)
        {
            _configuracion = config;
            clienteRepositorio = new ClienteRepositorio(config.CadenaConexion);
        }

        public async  Task<bool> Actualizar(Cliente cliente)
        {
            return await clienteRepositorio.Actualizar(cliente);
        }

        public async Task<bool> Eliminar(string identidad)
        {
            return await clienteRepositorio.Eliminar(identidad);
        }

        public async Task<IEnumerable<Cliente>> GetLista()
        {
            return await clienteRepositorio.GetLista();
        }

        public async Task<Cliente> GetPorCodigo(string identidad)
        {
            return await clienteRepositorio.GetPorCodigo(identidad);
        }

        public async Task<bool> Nuevo(Cliente cliente)
        {
            return await clienteRepositorio.Nuevo(cliente);
        }
    }
}
