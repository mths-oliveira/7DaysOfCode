namespace Tamagotchi;

//Crie uma classe que representa um mascote e coloque os atributos com o mesmo nome e tipo de dados dos campos retornados no JSON;
public class PokemonResult
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}
