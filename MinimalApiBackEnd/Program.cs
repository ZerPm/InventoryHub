using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var inventory = new List<string> { "Laptop", "Mouse", "Keyboard" };

app.MapGet("/api/inventory", () => Results.Ok(inventory));
app.MapPost("/api/inventory", (string item) =>
{
    inventory.Add(item);
    return Results.Ok(inventory);
});

app.Run();
