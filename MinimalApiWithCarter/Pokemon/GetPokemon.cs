using Carter;

namespace MinimalApiWithCarter.Pokemon;

public class GetPokemon() : CarterModule("pokemon")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/{pokemonName}", async (string pokemonName) =>
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return Results.Ok(content);
        }).WithName("Get Pokemon").WithSummary("Get a Pokemon by name");
    }
}