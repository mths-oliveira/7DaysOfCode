namespace Tamagotchi;

public class PokemonController
{
    public void Execute() {
        var menu = new Menu();
        var pokemonApiService = new PokemonApiService();
        var especiesDisponiveis = pokemonApiService.ObterEspeciesDisponiveis();
        var mascotesAdotados = new List<PokemonDetailsResult>();

        menu.MostrarMensagemDeBoasVindas();

        while (true)
        {
            menu.MostrarMenuPrincipal();
            int escolha = menu.ObterEscolhaDoJogador();

            switch (escolha)
            {
                case 1:
                    while (true)
                    {
                        menu.MostrarMenuDeAdocao();
                        escolha = menu.ObterEscolhaDoJogador();
                        switch (escolha)
                        {
                            case 1:
                                menu.MostrarEspeciesDisponiveis(especiesDisponiveis);
                                break;
                            case 2:
                                menu.MostrarEspeciesDisponiveis(especiesDisponiveis);
                                int indiceEspecie = menu.ObterEspecieEscolhida(especiesDisponiveis);
                                PokemonDetailsResult detalhes = pokemonApiService.ObterDetalhesDaEspecie(especiesDisponiveis[indiceEspecie]);
                                menu.MostrarDetalhesDaEspecie(detalhes);
                                break;
                            case 3:
                                menu.MostrarEspeciesDisponiveis(especiesDisponiveis);
                                indiceEspecie = menu.ObterEspecieEscolhida(especiesDisponiveis);
                                detalhes = pokemonApiService.ObterDetalhesDaEspecie(especiesDisponiveis[indiceEspecie]);
                                menu.MostrarDetalhesDaEspecie(detalhes);
                                if (menu.ConfirmarAdocao())
                                {
                                    mascotesAdotados.Add(detalhes);
                                    Console.WriteLine("Parabéns! Você adotou um " + detalhes.Name + "!");
                                    Console.WriteLine("──────────────");
                                    Console.WriteLine("────▄████▄────");
                                    Console.WriteLine("──▄████████▄──");
                                    Console.WriteLine("──██████████──");
                                    Console.WriteLine("──▀████████▀──");
                                    Console.WriteLine("─────▀██▀─────");
                                    Console.WriteLine("──────────────");
                                }
                                break;
                            case 4:
                                break;
                        }
                        if (escolha == 4)
                        {
                            break;
                        }
                    }
                    break;
                case 2:
                    menu.MostrarMascotesAdotados(mascotesAdotados);
                    break;
                case 3:
                    Console.WriteLine("Obrigado por jogar! Até a próxima!");
                    return;
            }
        }
    }
}