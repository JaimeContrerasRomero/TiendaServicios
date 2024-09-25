using MediatR;
using TiendaServicios.Apli.CarritoCompra.Modelo;
using TiendaServicios.Apli.CarritoCompra.Persistencia;

namespace TiendaServicios.Apli.CarritoCompra.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public DateTime FechaCreacionSesion { get; set; }
            public List<string> ProductoLista { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CarritoContexto _contexto;

            public Manejador(CarritoContexto contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSesion { FechaCreacion = request.FechaCreacionSesion };
                _contexto.CarritoSesion.Add(carritoSesion);
                var result = await _contexto.SaveChangesAsync();
                if (result == 0)
                {
                    throw new Exception("Error en la insersion del carrito de compra");
                }
                int id = carritoSesion.CarritoSesionId;

                foreach (var item in request.ProductoLista)
                {
                    var detalle = new CarritoSesionDetalle { FechaCreacion = DateTime.Now, CarritoSesionId = id, ProductoSeleccionado = item };
                    _contexto.CarritoSesionDetalle.Add(detalle);
                }
                result = await _contexto.SaveChangesAsync();
                if (result > 0)
                    return Unit.Value;
                throw new Exception("Error en la insersion en el detalle del carrito de compra");

            }
        }
    }
}
