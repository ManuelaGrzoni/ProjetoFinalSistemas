var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor
builder.Services.AddRazorPages();

// Configura el cliente HTTP para la API
builder.Services.AddHttpClient("SistemaEventosAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7089/"); 
});

var app = builder.Build();

// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
