namespace Tienda_ApiRest.Servicios
{
	public class ConexionSql
	{
		public string StrSqlServer { get;}

		public ConexionSql()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.jeson")
				.Build();

			StrSqlServer = builder.GetSection("ConnectionStrings:StrSqlServer").Value;
		}
	}
}
