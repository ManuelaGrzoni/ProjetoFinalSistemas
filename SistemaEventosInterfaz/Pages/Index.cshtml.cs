using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEventosInterfaz.Models; 
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class IndexModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public IndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public List<Evento> Eventos { get; set; } = new List<Evento>();

    public async Task OnGetAsync()
    {
        var client = _httpClientFactory.CreateClient("SistemaEventosAPI");
        Eventos = await client.GetFromJsonAsync<List<Evento>>("api/Eventos");
    }
}
