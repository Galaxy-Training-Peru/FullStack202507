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

// Optimización de entrega de archivos estáticos
app.MapStaticAssets(); // Reemplaza a UseStaticFiles()

app.MapRazorPages()
   .WithStaticAssets();

app.Run();

//Reemplazo de UseStaticFiles con MapStaticAssets:

//MapStaticAssets realiza optimizaciones automáticas en tiempo de compilación:
//Compresión(gzip en desarrollo; gzip y Brotli en producción).
//Generación de ETags basados en el contenido (SHA-256).
//Configuración de encabezados para un caching eficiente.
