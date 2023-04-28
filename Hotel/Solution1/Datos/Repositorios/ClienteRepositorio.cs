using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private string CadenaConexion;

        public ClienteRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }
        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<bool> Actualizar(Cliente cliente)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"UPDATE cliente SET Nombre = @Nombre,Direccion= @Direccion,Email= @Email,
                             Telefono=@Telefono WHERE Identidad=@Identidad;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, cliente));
            }
            catch (Exception ex)
            {

            }
            return resultado;
        }

        public async Task<bool> Eliminar(string Identidad)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"DELETE FROM cliente WHERE Identidad=@Identidad;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { Identidad }));
            }
            catch (Exception ex)
            {

            }
            return resultado;
        }

        public async Task<IEnumerable<Cliente>> GetLista()
        {
            IEnumerable<Cliente> lista = new List<Cliente>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM cliente;";
                lista = await conexion.QueryAsync<Cliente>(sql);
            }
            catch (Exception ex)
            {

            }
            return lista;
        }

        public async Task<Cliente> GetPorCodigo(string Identidad)
        {
            Cliente cli = new Cliente();

            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM cliente WHERE Identidad = @Identidad; ";

                cli = await conexion.QueryFirstAsync<Cliente>(sql, new { Identidad });
            }
            catch (Exception ex)
            {
            }
            return cli;
        }

        public async Task<bool> Nuevo(Cliente cliente)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO cliente (Identidad,Nombre,Direccion,Email,Telefono) 
                                VALUES (@Identidad,@Nombre,@Direccion,@Email,@Telefono);";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, cliente));
            }
            catch (Exception ex)
            {

            }
            return resultado;
        }

        

    }
}
