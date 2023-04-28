using Datos.Interfaces;
using Datos.Repositorios;
using Hotel.Interfaces;
using Modelos;

namespace Hotel.Servicios
{
    public class HabitacionServicio : IHabitacionServicio
    {
        private readonly Config _configuracion;
        private IHabitacionRepositorio habitacionRepositorio;

        public HabitacionServicio(Config config)
        {
            _configuracion = config;
            habitacionRepositorio = new HabitacionRepositorio(config.CadenaConexion);
        }

        public async Task<bool> Actualizar(Habitacion habitacion)
        {
            return await habitacionRepositorio.Actualizar(habitacion);
        }

        public async Task<bool> Eliminar(int codigo)
        {
            return await habitacionRepositorio.Eliminar(codigo);
        }

        public async Task<IEnumerable<Habitacion>> GetLista()
        {
            return await habitacionRepositorio.GetLista();
        }

        public async Task<Habitacion> GetPorCodigo(int codigo)
        {
            return await habitacionRepositorio.GetPorCodigo(codigo);
        }

        public async Task<bool> Nuevo(Habitacion habitacion)
        {
            return await habitacionRepositorio.Nuevo(habitacion);
        }
    }
}
