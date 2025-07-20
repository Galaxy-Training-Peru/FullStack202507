var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthorization();

// Optimizaci�n de entrega de archivos est�ticos
app.MapStaticAssets(); // Reemplaza a UseStaticFiles()

app.MapRazorPages()
   .WithStaticAssets();

app.Run();

//Reemplazo de UseStaticFiles con MapStaticAssets:

//MapStaticAssets realiza optimizaciones autom�ticas en tiempo de compilaci�n:
//Compresi�n(gzip en desarrollo; gzip y Brotli en producci�n).
//Generaci�n de ETags basados en el contenido (SHA-256).
//Configuraci�n de encabezados para un caching eficiente.
