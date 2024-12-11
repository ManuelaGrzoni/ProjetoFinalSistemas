using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class EventosModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EventosModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public List<Evento> Eventos { get; set; }

    public async Task OnGetAsync()
    {
        var client = _httpClientFactory.CreateClient("SistemaEventosAPI");
        Eventos = await client.GetFromJsonAsync<List<Evento>>("eventos");
    }

    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Ubicacion { get; set; }
    }
}
