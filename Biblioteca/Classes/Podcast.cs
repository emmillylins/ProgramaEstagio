using Biblioteca.Classes;

public class GerarPodcast
{
    public string nome = "Sem Lógica";
    public string apresentador = "Clara";
    public int TotalEpisodios = 0;

    public List<Episodios> Episodios { get; set; } = new List<Episodios>();

    // Variável estática para auto-incremento do Código
    private static int contadorCodigoConvidado = 1;

    public void AdicionarEpisodio()
    {
        Console.WriteLine("Adicione um novo episódio ao podcast!");
        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        double duracao;
        while (true)
        {
            Console.Write("Duração (em minutos): ");
            string duracaoInserida = Console.ReadLine();

            if (double.TryParse(duracaoInserida, out duracao) && duracao > 0)
            {
                break; // Sai do loop se o valor for válido
            }
            else
            {
                Console.WriteLine("Erro: Digite um número válido para a duração.");
            }
        }

        Console.Write("Resumo: ");
        string resumo = Console.ReadLine();

        List<Convidado> listaConvidados = new List<Convidado>();

        Console.Write("Deseja adicionar um convidado? Digite sim ou não: ");
        string respostaConvidadoInserido = Console.ReadLine().ToLower();

        if (respostaConvidadoInserido == "sim")
        {
            while (true)
            {
                Console.Write("Digite o nome do convidado: ");
                string nomeConvidado = Console.ReadLine();

                listaConvidados.Add(new Convidado(contadorCodigoConvidado++, nomeConvidado));

                Console.Write("Deseja adicionar mais um? Digite sim ou não: ");
                string adicionarMaisConvidados = Console.ReadLine().ToLower();

                if (adicionarMaisConvidados == "não")
                {
                    break;
                }
            }
        }

        // Cria o novo episódio e adiciona à lista
        Episodios novoEpisodio = new Episodios(TotalEpisodios + 1, titulo, duracao, resumo, listaConvidados);
        Episodios.Add(novoEpisodio);
        TotalEpisodios++;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Podcast {nome} - Apresentado por {apresentador}!");

        foreach (Episodios episodio in Episodios.OrderBy(e => e.Numero))
        {
            Console.WriteLine($"Episódio {episodio.Numero} - {episodio.Titulo}");
            Console.WriteLine($"Duração: {episodio.Duracao} minutos");
            Console.WriteLine($"Resumo: {episodio.Resumo}");
            if (episodio.Convidados.Count > 0)
            {
                Console.WriteLine("Convidados:");
                foreach (var convidado in episodio.Convidados)
                {
                    Console.WriteLine($"  - {convidado.Codigo}: {convidado.Nome}");
                }
            }
            else
            {
                Console.WriteLine("Sem convidados neste episódio.");
            }

            Console.WriteLine();  // Linha em branco para separar os episódios
        }

        Console.WriteLine($"Este podcast possui {TotalEpisodios} episódios.");
    }
}
