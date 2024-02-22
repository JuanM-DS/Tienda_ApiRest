using System.Data.SqlClient;
using Tienda_ApiRest.Modelos;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tienda_ApiRest.Servicios
{
	public class RepositorioCategoria : IRepositorio<Categoria>
	{
		private readonly string? _StrSqlServer;
		public RepositorioCategoria(ConexionSql strSqlServer)
		{
			_StrSqlServer = strSqlServer.StrSqlServer;
		}

		public async Task<bool> Actualizar(Categoria modelo)
		{
            using (var con = new SqlConnection(_StrSqlServer))
            {
                using (var cmd = new SqlCommand("sp_ActualizarCategoria", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCategoria", modelo.Id);
                    cmd.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);
                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return true;
                }
            }
        }

		/*Busca una categoria por un id*/
		public async Task<Categoria> BuscarPorId(int id)
		{
			try
			{
				var categoria = new Categoria();

				using (var con = new SqlConnection(_StrSqlServer))
				{
					using (var cmd = new SqlCommand("sp_BuscarCategoria", con))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@Id", id);
						con.OpenAsync().Wait();
						using (var rd = await cmd.ExecuteReaderAsync())
						{
							if (rd.HasRows)
							{
								while (rd.Read())
								{
									categoria.Id = Convert.ToInt32(rd["IdCategoria"]);
									categoria.Nombre = rd["Nombre"].ToString();
									categoria.Descripcion = rd["Descripcion"].ToString();
								}
							}
						}
					}
				}
				return categoria;
			}
			catch
			{
				return null;
			}
		}

        /*Metodo para eliminar el producto*/
        public async Task<bool> Eliminar(int id)
        {
            try
            {
                using (var con = new SqlConnection(_StrSqlServer))
                {
                    using (var cmd = new SqlCommand("sp_EliminarCategoria", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCategoria", id);
                        con.OpenAsync().Wait();
                        cmd.ExecuteNonQueryAsync().Wait();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*Metodo encargado de listar las Categorias que tenemos en la base de datos*/
        public async Task<bool> Insertar(Categoria modelo)
		{
            try
            {
                using (var con = new SqlConnection(_StrSqlServer))
                {
                    using (var cmd = new SqlCommand("sp_AggCategoria", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);
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

		public async Task<List<Categoria>?> Listar()
		{
			var Lista = new List<Categoria>();
			try
			{
				using (var con = new SqlConnection(_StrSqlServer))
				{
					using (var cmd = new SqlCommand("sp_Listarcategorias", con))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						await con.OpenAsync();
						using (var rd = await cmd.ExecuteReaderAsync())
						{
							if (rd.HasRows)
							{
								while (rd.Read())
								{
									var miCategoria = new Categoria();
									miCategoria.Id = Convert.ToInt32(rd["IdCategoria"]);
									miCategoria.Nombre = rd["Nombre"].ToString();
									miCategoria.Descripcion = rd["Descripcion"].ToString();

									Lista.Add(miCategoria);
								}
							}
						}
					}
				}
				return Lista;
			}
			catch
			{
				return null;
			}
		}
	}
}
