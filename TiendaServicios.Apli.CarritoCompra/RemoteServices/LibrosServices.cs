using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;
using TiendaServicios.Apli.CarritoCompra.RemoteInterface;
using TiendaServicios.Apli.CarritoCompra.RemoteModel;

namespace TiendaServicios.Apli.CarritoCompra.RemoteServices
{
    public class LibrosServices : ILibrosService
    {
        public readonly IHttpClientFactory _httpClient;
        public readonly ILogger<LibrosServices> _logger;
        public LibrosServices(IHttpClientFactory httpClient , ILogger<LibrosServices> logger) 
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, LibroRemote Libro, string ErrorMessage)> GetLibro(Guid LibroId)
        {
            try
            {
                var cliente = _httpClient.CreateClient("Libros");
                var response = await cliente.GetAsync($"api/LibroMaterial/{LibroId}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<LibroRemote>(contenido, options);
                    return (true, resultado, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex) 
            {
                _logger?.LogError(ex.ToString()); 
                return (false, null, ex.Message.ToString());
            }
        }
    }
}
