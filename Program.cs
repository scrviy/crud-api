using System.Dynamic;
using Microsoft.OpenApi.Models;
using PokeAPI.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PokeAPI",
        Description = "Consumindo e retornando pokedéx",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PokeAPI V1");
});

app.MapGet("/pokemons/{id}", (int id) => PokeDB.GetPokemon(id));
app.MapGet("/pokemons", () => PokeDB.GetPokemon());

app.MapPost("/pokemons", (Pokemon pokemon) => PokeDB.CreatePokemon(pokemon));

app.MapPut("/pokemons", (Pokemon pokemon) => PokeDB.UpdatePokemon(pokemon));

app.MapDelete("/pokemons/{id}", (int id) => PokeDB.RemovePokemon(id));

app.Run();