namespace SignalRServer
{
    using Microsoft.AspNetCore.SignalR;
    using System.Text.Json.Serialization;

    // Hub con soporte para tipos polimórficos
    public class ChatHub : Hub
    {
        // Método para el chat básico
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        // Método para procesar objetos polimórficos
        public async Task ProcessPerson(JsonPerson person)
        {
            string info;
            if (person is JsonPersonExtended extended)
            {
                info = $"Nombre: {extended.Name}, Edad: {extended.Age}";
            }
            else if (person is JsonPersonExtended2 extended2)
            {
                info = $"Nombre: {extended2.Name}, Ubicación: {extended2.Location}";
            }
            else
            {
                info = $"Nombre: {person.Name}";
            }

            // Enviar la información procesada al cliente
            await Clients.All.SendAsync("ReceivePersonInfo", info);
        }
    }

    // Clases para tipos polimórficos
    [JsonPolymorphic]
    [JsonDerivedType(typeof(JsonPersonExtended), nameof(JsonPersonExtended))]
    [JsonDerivedType(typeof(JsonPersonExtended2), nameof(JsonPersonExtended2))]
    public class JsonPerson
    {
        public string Name { get; set; } = string.Empty;
    }

    public class JsonPersonExtended : JsonPerson
    {
        public int Age { get; set; }
    }

    public class JsonPersonExtended2 : JsonPerson
    {
        public string Location { get; set; } = string.Empty;
    }

}
