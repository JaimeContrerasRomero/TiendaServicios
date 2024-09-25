using Microsoft.EntityFrameworkCore;
using TiendaServicios.Apli.CarritoCompra.Modelo;

namespace TiendaServicios.Apli.CarritoCompra.Persistencia
{
    public class CarritoContexto: DbContext
    {
        public CarritoContexto(DbContextOptions<CarritoContexto> options) : base(options) { }

        public DbSet<CarritoSesion> CarritoSesion { get; set; }
        public DbSet<CarritoSesionDetalle> CarritoSesionDetalle { get; set; }
    }
}
