using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<LibroMaterialDto>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<LibroMaterialDto>>
        {
            private readonly ContextoLibreria _contextoLibreria;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contextoLibreria, IMapper mapper)
            {
                _contextoLibreria = contextoLibreria;
                _mapper = mapper;
            }

            public async Task<List<LibroMaterialDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libros = await _contextoLibreria.LibreriaMaterial.ToListAsync();
                //var librosDto = _mapper.Map<List<LibreriaMaterial>, List<LibroMaterialDto>>(libros);
                var librosDto = _mapper.Map<List<LibroMaterialDto>>(libros);
                return librosDto;
            }
        }
    }
}
