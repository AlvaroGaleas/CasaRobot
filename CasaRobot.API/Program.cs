using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Aplicacion.ServiciosImpl;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//1.-Leer cadena de conexion a la base de datos del archivo de setting
var conexionBD = builder.Configuration.GetConnectionString("ConexionCasaRobot");
//2.-Configuracion del dbcontext con la base de datos
builder.Services.AddDbContext<CasaRobot2Context>(options => options.UseSqlServer(conexionBD));

//3.-Configurar los servicios
builder.Services.AddScoped<IClientesServicio, ClientesServicioImpl>();
builder.Services.AddScoped<ICostosServicio, CostosServicioImpl>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
