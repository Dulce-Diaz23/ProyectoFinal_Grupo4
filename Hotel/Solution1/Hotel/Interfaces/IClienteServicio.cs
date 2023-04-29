using Modelos;

namespace Hotel.Interfaces
{
    public interface IClienteServicio
    {
        Task<Cliente> GetPorCodigo(string identidad);
        Task<bool> Nuevo(Cliente cliente);
        Task<bool> Actualizar(Cliente cliente);
        Task<bool> Eliminar(string identidad);
        Task<IEnumerable<Cliente>> GetLista();
    }
}
