namespace Tamagotchi;

public class PokemonSpeciesResult
{
    public required int Count { get; set; }
    public required string Next { get; set; }
    public required string Previous { get; set; }
    public required List<PokemonResult> Results { get; set; }
}
