using Tienda_ApiRest.Compartir;
using Tienda_ApiRest.Modelos;
using Tienda_ApiRest.Servicios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Inyeccion de dependencias
builder.Services.AddScoped<Microsoft.Extensions.Configuration.ConfigurationBuilder>(); // Configuración de ámbito
builder.Services.AddScoped<IRepositorio<Producto>, RepositorioProducto>();
builder.Services.AddScoped<IRepositorio<Categoria>, RepositorioCategoria>();
builder.Services.AddScoped<ConexionSql>();
builder.Services.AddScoped<RespuestaDto>();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
		builder => builder.WithOrigins("http://127.0.0.1:5500")
						  .AllowAnyHeader()
						  .AllowAnyMethod());
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseRouting();
app.UseCors("AllowSpecificOrigin"); // Agrega el middleware CORS antes de UseEndpoints

app.MapControllers();
app.Run();
