﻿namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class LibroMaterialDto
    {
        public Guid? LibreriaMaterialId { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }
}
