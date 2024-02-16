using System.Data.SqlClient;
using System.Reflection;
using Tienda_ApiRest.Modelos;

namespace Tienda_ApiRest.Servicios
{
	public class RepositorioProducto : IRepositorio<Producto>
	{
		private readonly string _StrSqlServer;
		private Mensaje _mensaje { get; set; }
		public RepositorioProducto()
		{
			_StrSqlServer = new ConexionSql().StrSqlServer;
			_mensaje = new Mensaje();
		}

		public async Task<Mensaje> Insertar(Producto modelo)
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

						_mensaje.Estado = 201;
						_mensaje.Descripcion = "Producto creado exitosamente";
						_mensaje.Entidad = modelo;

						return _mensaje;
					}
				}
			}
			catch(SqlException ex)
			{
				_mensaje.Estado = 500;
				_mensaje.Descripcion = ex.Message.ToString();
				_mensaje.Entidad = modelo;

				return _mensaje;
			}
		}
	}
}
