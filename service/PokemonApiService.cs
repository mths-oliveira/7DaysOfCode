using System.Text.Json;
using RestSharp;

namespace Tamagotchi;

public class PokemonApiService
    {
        public List<PokemonResult> ObterEspeciesDisponiveis()
        {
            // Obter a lista de espécies de Pokémons
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if(response.Content == null) throw new Exception();

            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var pokemonEspeciesResposta = JsonSerializer.Deserialize<PokemonSpeciesResult>(response.Content, options);

            if(pokemonEspeciesResposta == null) throw new Exception();

            return pokemonEspeciesResposta.Results;
        }

        public PokemonDetailsResult ObterDetalhesDaEspecie(PokemonResult especie)
        {
            // Obter as características do Pokémon escolhido
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{especie.Name}");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if(response.Content == null) throw new Exception();

            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<PokemonDetailsResult>(response.Content, options);
            
            if(result == null) throw new Exception();

            return result;
        }
    }