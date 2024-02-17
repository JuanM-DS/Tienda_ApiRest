using System.Data.SqlClient;
using Tienda_ApiRest.Modelos;

namespace Tienda_ApiRest.Servicios
{
	public class RepositorioProducto : IRepositorio<Producto>
	{
		private readonly string _StrSqlServer;
		private Respuesta _Respuesta { get; set; }
		public RepositorioProducto(ConexionSql strSqlServer, Respuesta mensaje)
		{
			_StrSqlServer = strSqlServer.StrSqlServer;
			_Respuesta = mensaje;
		}

		/* Metodo encargado de insertar los productos en la base de datos*/
		public async Task<Respuesta> Insertar(Producto modelo)
		{
			try
			{
				using (var con = new SqlConnection(_StrSqlServer))
				{
					using (var cmd = new SqlCommand("sp_AggProductos", con))
					{
						cmd.CommandType = System.Data.CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@Nombre", modelo.Nombre);
						cmd.Parameters.AddWithValue("@Precio", modelo.Precio);
						cmd.Parameters.AddWithValue("@Unidades", modelo.Unidades);
						cmd.Parameters.AddWithValue("@IdCategoria", modelo.IdCategoria);
						await con.OpenAsync();
						await cmd.ExecuteNonQueryAsync();

						_Respuesta.Estado = TipoRespuestaHttp.ok;
						_Respuesta.Mensaje = "Producto creado exitosamente";
						_Respuesta.Entidad = modelo;

						return _Respuesta;
					}
				}
			}
			catch(SqlException ex)
			{
				_Respuesta.Estado = TipoRespuestaHttp.InternalServerError;
				_Respuesta.Mensaje = ex.Message.ToString();
				_Respuesta.Entidad = modelo;

				return _Respuesta;
			}
		}
	}
}
