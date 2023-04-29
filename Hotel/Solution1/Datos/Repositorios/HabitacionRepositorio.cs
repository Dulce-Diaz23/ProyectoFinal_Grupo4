using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
    public class HabitacionRepositorio : IHabitacionRepositorio
    {
        private string CadenaConexon;

        public HabitacionRepositorio(string _cadenaConexion)
        {
            CadenaConexon = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexon);
        }

        public async Task<bool> Actualizar(Habitacion habitacion)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"UPDATE habitacion SET Nombre=@Nombre, Descripcion=@Descripcion, TipoHabitacion=@TipoHabitacion, Existencia=@Existencia, Precio=@Precio, FechaCreacion=@FechaCreacion, Imagen=@Imagen
                             WHERE Codigo=@Codigo;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, habitacion));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public async Task<bool> Eliminar(int codigo)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"DELETE FROM habitacion WHERE Codigo=@Codigo;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { codigo }));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public async Task<IEnumerable<Habitacion>> GetLista()
        {
            IEnumerable<Habitacion> lista = new List<Habitacion>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM habitacion";
                lista = await conexion.QueryAsync<Habitacion>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public async Task<Habitacion> GetPorCodigo(int codigo)
        {
            Habitacion habitacion = new Habitacion();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM habitacion WHERE Codigo = @Codigo;";
                habitacion = await conexion.QueryFirstAsync<Habitacion>(sql, new { codigo });
            }
            catch (Exception ex)
            {
            }
            return habitacion;
        }

        public async Task<bool> Nuevo(Habitacion habitacion)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO habitacion (Codigo, Nombre, Descripcion, TipoHabitacion, Precio, Existencia, FechaCreacion, Imagen) 
                             VALUES (@Codigo, @Nombre, @Descripcion, @TipoHabitacion, @Precio, @Existencia, @FechaCreacion, @Imagen);";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, habitacion));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

    }
}
