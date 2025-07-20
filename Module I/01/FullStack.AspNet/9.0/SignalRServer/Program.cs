using Microsoft.AspNetCore.SignalR;
using OpenTelemetry.Trace;
using SignalRServer;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Agregar servicios de SignalR
builder.Services.AddSignalR();

// Configuraci�n de OpenTelemetry para trazabilidad distribuida
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing =>
    {
        tracing.AddAspNetCoreInstrumentation();
        tracing.AddSource("Microsoft.AspNetCore.SignalR.Server");
        tracing.AddOtlpExporter(); // Exportador OpenTelemetry Protocol (OTLP)
    });

// Configuraci�n para soporte de serializaci�n JSON con tipos polim�rficos
builder.Services.Configure<JsonHubProtocolOptions>(o =>
{
    o.PayloadSerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

app.MapHub<ChatHub>("/chatHub");

app.MapGet("/", () => Results.Content("""
<!DOCTYPE html>
<html>
<head>
    <title>SignalR Chat</title>
</head>
<body>
    <h1>Chat con SignalR y Polimorfismo</h1>
    <div>
        <input id="userInput" placeholder="Ingresa tu nombre" />
        <input id="messageInput" placeholder="Escribe un mensaje" />
        <button onclick="sendMessage()">Enviar Mensaje</button>
    </div>
    <div>
        <h3>Enviar datos polim�rficos</h3>
        <select id="personType">
            <option value="JsonPersonExtended">JsonPersonExtended</option>
            <option value="JsonPersonExtended2">JsonPersonExtended2</option>
        </select>
        <input id="personName" placeholder="Nombre" />
        <input id="personExtra" placeholder="Edad o Ubicaci�n" />
        <button onclick="sendPolymorphicData()">Enviar Persona</button>
    </div>
    <ul id="messages"></ul>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/microsoft-signalr/8.0.7/signalr.min.js"></script>
    <script>
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("/chatHub")
            .build();

        // Recibir mensajes desde el servidor
        connection.on("ReceiveMessage", (user, message) => {
            const li = document.createElement("li");
            li.textContent = `${user}: ${message}`;
            document.getElementById("messages").appendChild(li);
        });

        connection.on("ReceivePersonInfo", (info) => {
            const li = document.createElement("li");
            li.textContent = `Informaci�n procesada: ${info}`;
            document.getElementById("messages").appendChild(li);
        });

        async function sendMessage() {
            const user = document.getElementById("userInput").value;
            const message = document.getElementById("messageInput").value;
            await connection.invoke("SendMessage", user, message);
        }

        async function sendPolymorphicData() {
            const personType = document.getElementById("personType").value;
            const personName = document.getElementById("personName").value;
            const personExtra = document.getElementById("personExtra").value;

            let person;
            if (personType === "JsonPersonExtended") {
                person = {
                    $type: "JsonPersonExtended",
                    Name: personName,
                    Age: parseInt(personExtra, 10)
                };
            } else if (personType === "JsonPersonExtended2") {
                person = {
                    $type: "JsonPersonExtended2",
                    Name: personName,
                    Location: personExtra
                };
            }

            await connection.invoke("ProcessPerson", person);
        }

        connection.start().catch(err => console.error(err));
    </script>
</body>
</html>
""", "text/html"));

app.Run();


// Contexto para la serializaci�n
[JsonSerializable(typeof(JsonPerson))]
[JsonSerializable(typeof(JsonPersonExtended))]
[JsonSerializable(typeof(JsonPersonExtended2))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }


//Nuevas Caracter�sticas Destacadas
//=================================
//1.- Soporte para Tipos Polim�rficos:

//La clase JsonPerson y sus derivados (JsonPersonExtended y JsonPersonExtended2) permiten manejar tipos polim�rficos en m�todos del hub.
//Esto es �til en escenarios donde diferentes tipos de datos necesitan ser procesados por un �nico m�todo del hub.

//2.- Trazabilidad Distribuida con OpenTelemetry:

//La configuraci�n de OpenTelemetry permite rastrear llamadas al hub en toda la aplicaci�n utilizando ActivitySource para SignalR.
//Esto facilita la depuraci�n y el monitoreo en sistemas distribuidos.

//3.- Compatibilidad con Native AOT:

//Permite generar binarios altamente optimizados y compactos, lo que mejora el rendimiento y reduce el tama�o de la aplicaci�n.
//Se utiliza la serializaci�n JSON con System.Text.Json Source Generator para garantizar la compatibilidad.

//4.- Mejoras de Rendimiento en SignalR:

//SignalR ahora soporta compresi�n nativa y AOT, lo que reduce la latencia en comunicaciones en tiempo real.