using RestSharp;
using System.Text.Json;

namespace Tamagotchi;

public class Program
{
    static void Main(string[] args)
    {
        //Criar o código C# que executará uma requisição HTTP do tipo GET.
        var client = new  RestClient("https://pokeapi.co/api/v2/pokemon/");
        var request = new RestRequest("", Method.Get);

        //Executar a requisição e pegar a resposta (o JSON)
        var response =  client.Execute(request);

        // Verificar status da requisição
        if(response.StatusCode != System.Net.HttpStatusCode.OK) 
        {   
            Console.WriteLine(response.ErrorMessage);
            return;
        } 

        // Verificar se a requisição tem conteúdo
        if(response.Content == null) return;

        //Converta o resultado da API neste objeto criado;
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var pokemonEspeciesResponse = JsonSerializer.Deserialize<PokemonSpeciesResult>(response.Content, options);

        // Verificar se a conversão foi realizada com sucesso
        if(pokemonEspeciesResponse == null) return; 
        
        Console.WriteLine("Escolha um Tamagotchi:");
        for (int i = 0; i < pokemonEspeciesResponse.Results.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pokemonEspeciesResponse.Results[i].Name}");
        }

        int escolha;

        while (true)
        {
            Console.WriteLine("\n");
            Console.Write("Escolha um número: ");
            if (!int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= pokemonEspeciesResponse.Results.Count)
            {
                Console.WriteLine("Escolha inválida. Tente novamente.");
            }
            else
                break;
        }

        client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{escolha}");
        request = new RestRequest("", Method.Get);
        response = client.Execute(request);

        // Verificar status da requisição
        if(response.StatusCode != System.Net.HttpStatusCode.OK) 
        {   
            Console.WriteLine(response.ErrorMessage);
            return;
        } 

        // Verificar se a requisição tem conteúdo
        if(response.Content == null) return;

        var pokemonDetalhes = JsonSerializer.Deserialize<PokemonDetailsResult>(response.Content, options);

        // Verificar se a conversão foi realizada com sucesso
        if(pokemonDetalhes == null) return; 

        var pokemonEscolhido = pokemonEspeciesResponse.Results[escolha - 1];

        // Mostrar as características ao jogador
        Console.WriteLine("\n");
        Console.WriteLine($"Você escolheu {pokemonEscolhido.Name}!");
        Console.WriteLine($"Detalhes:");
        Console.WriteLine($"- Nome: {pokemonEscolhido.Name}");
        Console.WriteLine($"- Peso: {pokemonDetalhes.Weight}");
        Console.WriteLine($"- Altura: {pokemonDetalhes.Height}");

        Console.WriteLine("\nHabilidades do Mascote: ");

        foreach (var abilityDetail in pokemonDetalhes.Abilities)
        {
            Console.WriteLine("Nome da Habilidade: " + abilityDetail.Ability.Name);
        }

        Console.WriteLine("\n");
    }
}