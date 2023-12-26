namespace Tamagotchi;

class PokemonDetailsResult
{
    public required List<AbilityDetail> Abilities { get; set; }
    public required string Name { get; set; }
    public int Order { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
}

public class AbilityDetail
{
    public required Ability Ability { get; set; }
    public bool IsHidden { get; set; }
    public int Slot { get; set; }
}

public class Ability
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}