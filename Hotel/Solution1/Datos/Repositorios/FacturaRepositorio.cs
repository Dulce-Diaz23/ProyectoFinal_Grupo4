using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
    public class FacturaRepositorio : IFacturaRepositorio
    {
        private string CadenaConexion;

        public FacturaRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<int> Nueva(Factura factura)
        {
            int idFactura = 0;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO factura (IdentidadCliente, Fecha, CodigoUsuario, ISV, Descuento, SubTotal, Total) 
                               VALUES (@IdentidadCliente, @Fecha, @CodigoUsuario, @ISV, @Descuento, @SubTotal, @Total); SELECT LAST_INSERT_ID()";
                idFactura = Convert.ToInt32(await conexion.ExecuteScalarAsync(sql, factura));
            }
            catch (Exception ex)
            {
            }
            return idFactura;
        }

        public async Task<IEnumerable<Factura>> GetLista()
        {
            IEnumerable<Factura> lista = new List<Factura>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM factura;";
                lista = await conexion.QueryAsync<Factura>(sql);
            }
            catch (Exception ex)
            {

            }
            return lista;
        }
    }
}
