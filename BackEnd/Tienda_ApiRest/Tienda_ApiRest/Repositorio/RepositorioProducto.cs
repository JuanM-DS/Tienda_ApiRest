using System.Data.SqlClient;
using Tienda_ApiRest.Modelos;

namespace Tienda_ApiRest.Servicios
{
	public class RepositorioProducto : IRepositorio<Producto>
	{
		private readonly string? _StrSqlServer;
		public RepositorioProducto(ConexionSql strSqlServer)
		{
			_StrSqlServer = strSqlServer.StrSqlServer;
		}

		/* Metodo encargado de insertar los productos en la base de datos*/
		public async Task<bool> Insertar(Producto modelo)
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

						return true;
					}
				}
			}
			catch
			{
				return false;
			}
		}

		public Task<List<Producto>> Listar()
		{
			throw new NotImplementedException();
		}
	}
}
