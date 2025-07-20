using Microsoft.AspNetCore.Http.HttpResults;
using System;

var app = WebApplication.Create();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Ejemplo de InternalServerError
app.MapGet("/error", () => TypedResults.InternalServerError("Algo sali� mal."));

// Grupo de rutas con ProducesProblem
var todos = app.MapGroup("/todos")
    .ProducesProblem(StatusCodes.Status500InternalServerError); // Indica que todos los endpoints en este grupo pueden devolver ProblemDetails.

todos.MapGet("/", () => new Todo(1, "Crear una aplicaci�n de ejemplo", false));
todos.MapPost("/", (Todo todo) => Results.Ok(todo));

// Ejemplo de Problem con IEnumerable<KeyValuePair<string, object?>>
app.MapGet("/problem", () =>
{
    var extensiones = new List<KeyValuePair<string, object?>>
    {
        new("detalle", "Valor adicional"),
        new("soluci�n", "Revisar los par�metros enviados.")
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
//Los m�todos como InternalServerError y ProducesProblem hacen que el c�digo sea m�s intuitivo, legible y f�cil de mantener.

//2.- Estandarizaci�n y documentaci�n:
//Las mejoras en la generaci�n de OpenAPI facilitan la creaci�n de documentaci�n precisa para consumidores de la API.

//3.- Mayor flexibilidad:
//Con el soporte de IEnumerable<KeyValuePair>, puedes incluir informaci�n adicional en los errores, �til para depuraci�n avanzada o integraci�n con clientes que consumen la API.

//4.- Reducci�n de errores manuales:
//Estas caracter�sticas proporcionan un enfoque consistente para manejar errores y documentar comportamientos, lo que reduce la probabilidad de errores en la implementaci�n.

//4.- Integraci�n m�s sencilla con clientes y herramientas:
//Las APIs son m�s claras y expl�citas, lo que mejora la interoperabilidad con herramientas como Swagger, Postman o sistemas de monitoreo.
