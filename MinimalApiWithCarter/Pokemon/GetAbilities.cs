using Carter;

namespace MinimalApiWithCarter.Pokemon;

public class GetAbilities() : CarterModule("pokemon")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/ability/{abilityName}", async (string abilityName) =>
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://pokeapi.co/api/v2/ability/{abilityName}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return Results.Ok(content);
        }).WithName("Get Ability");
    }
}