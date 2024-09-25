using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor.Persistencia
{
    public class ContextoAutor:DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options):base(options) { } //<-Inyección de dependencias

        public DbSet<AutorLibro> AutorLibro {  get; set; }

        public DbSet<GradoAcademico> GradoAcademico { get; set; }
    }
}
