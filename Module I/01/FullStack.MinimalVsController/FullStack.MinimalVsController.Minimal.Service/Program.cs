using FullStack.MinimalVsController.Minimal.Service.Application;
using FullStack.MinimalVsController.Minimal.Service.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapGet("/people", (IPersonService personService) =>
//{
//    return personService.GetPeople();
//});

//app.MapGet("/people", () =>
//{
//    return "Hello World";
//});


app.RegisterPeopleEndpoints();
app.UseHttpsRedirection();
app.Run();
