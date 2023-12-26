namespace Tamagotchi;

public class Program
{
    static void Main(string[] args)
    {
        var pokemonController = new PokemonController();
        pokemonController.Execute();
    }
}