using Microsoft.AspNetCore.Http.HttpResults;
using System;

var app = WebApplication.Create();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Ejemplo de InternalServerError
app.MapGet("/error", () => TypedResults.InternalServerError("Algo salió mal."));

// Grupo de rutas con ProducesProblem
var todos = app.MapGroup("/todos")
    .ProducesProblem(StatusCodes.Status500InternalServerError); // Indica que todos los endpoints en este grupo pueden devolver ProblemDetails.

todos.MapGet("/", () => new Todo(1, "Crear una aplicación de ejemplo", false));
todos.MapPost("/", (Todo todo) => Results.Ok(todo));

// Ejemplo de Problem con IEnumerable<KeyValuePair<string, object?>>
app.MapGet("/problem", () =>
{
    var extensiones = new List<KeyValuePair<string, object?>>
    {
        new("detalle", "Valor adicional"),
        new("solución", "Revisar los parámetros enviados.")
    };

    return TypedResults.Problem(
        "Este es un error con extensiones personalizadas",
        extensions: extensiones
    );
});

app.Run();

// Registro de clase Todo
record Todo(int Id, string Title, bool IsCompleted);




//1.- Mejora de la experiencia del desarrollador:
//Los métodos como InternalServerError y ProducesProblem hacen que el código sea más intuitivo, legible y fácil de mantener.

//2.- Estandarización y documentación:
//Las mejoras en la generación de OpenAPI facilitan la creación de documentación precisa para consumidores de la API.

//3.- Mayor flexibilidad:
//Con el soporte de IEnumerable<KeyValuePair>, puedes incluir información adicional en los errores, útil para depuración avanzada o integración con clientes que consumen la API.

//4.- Reducción de errores manuales:
//Estas características proporcionan un enfoque consistente para manejar errores y documentar comportamientos, lo que reduce la probabilidad de errores en la implementación.

//4.- Integración más sencilla con clientes y herramientas:
//Las APIs son más claras y explícitas, lo que mejora la interoperabilidad con herramientas como Swagger, Postman o sistemas de monitoreo.
