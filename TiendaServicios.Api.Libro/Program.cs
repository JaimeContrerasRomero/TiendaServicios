using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//Inyeccion de dependencias
builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());

builder.Services.AddDbContext<ContextoLibreria>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDB"));
});

builder.Services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
builder.Services.AddAutoMapper(typeof(Consulta.Ejecuta));
//Fin Inyeccion de dependencias

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
