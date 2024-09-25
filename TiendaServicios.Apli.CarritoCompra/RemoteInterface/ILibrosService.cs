using TiendaServicios.Apli.CarritoCompra.RemoteModel;

namespace TiendaServicios.Apli.CarritoCompra.RemoteInterface
{
    public interface ILibrosService
    {
        Task<(bool resultado, LibroRemote Libro, string ErrorMessage)> GetLibro(Guid LibroId);
    }
}
