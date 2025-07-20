using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Agregar soporte para OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

// Configurar endpoints para documentos OpenAPI
app.MapOpenApi();

// Endpoint simple de ejemplo
app.MapGet("/hello/{name}", (string name) => $"Hello, {name}!")
   .WithTags("Saludo")
   .WithOpenApi(operation =>
   {
       operation.Summary = "Endpoint para saludar a un usuario.";
       operation.Description = "Devuelve un mensaje personalizado basado en el nombre proporcionado.";
       return operation;
   });

// Otro endpoint de ejemplo
app.MapPost("/calculate", (int a, int b) => Results.Ok(new { Result = a + b }))
   .WithTags("Cálculos")
   .WithOpenApi(operation =>
   {
       operation.Summary = "Suma dos números.";
       operation.Description = "Toma dos enteros como parámetros y devuelve su suma.";
       return operation;
   });

app.Run();

//https://localhost:7041/openapi/v1.json