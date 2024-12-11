using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEventosAPI.Models; // Asegúrate de que este sea el namespace correcto
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class CrearEventoModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CrearEventoModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [BindProperty]
    public Evento Evento { get; set; } = new Evento(); // Clase Evento importada desde la API

    public string? Message { get; set; } // Propiedad nullable para evitar el error de nulabilidad

    public async Task<IActionResult> OnPostAsync()
    {
        var client = _httpClientFactory.CreateClient("SistemaEventosAPI");
        var response = await client.PostAsJsonAsync("eventos", Evento);

        if (response.IsSuccessStatusCode)
        {
            Message = "Evento creado con éxito.";
            Evento = new Evento(); // Reinicia el formulario
        }
        else
        {
            Message = "Error al crear el evento.";
        }

        return Page();
    }
}
