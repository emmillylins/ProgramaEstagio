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

        string titulo;

        while (true)
        {
            Console.Write("Título: ");
            titulo = Console.ReadLine(); 

            if (!string.IsNullOrWhiteSpace(titulo))
            {
                break; 
            }

            Console.WriteLine("Digite um título válido.");
        }

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
                Console.WriteLine("Digite um número válido para a duração.");
            }
        }

        string resumo;

        while (true)
        {
            Console.Write("Resumo: ");
            resumo = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(resumo))
            {
                break;
            }

            Console.WriteLine("Digite um resumo válido.");
        }

        List<Convidado> listaConvidados = new List<Convidado>();

        string respostaConvidadoInserido;
        while (true)
        {
            Console.Write("Deseja adicionar um convidado? Digite sim ou não: ");
            respostaConvidadoInserido = Console.ReadLine()?.Trim().ToLower();

            if (respostaConvidadoInserido == "sim" || respostaConvidadoInserido == "não")
            {
                break;
            }

            Console.WriteLine("Resposta inválida. Digite apenas 'sim' ou 'não'.");
        }

        if (respostaConvidadoInserido == "sim")
        {
            bool continuarAdicionando = true;

            while (continuarAdicionando)
            {
                string nomeConvidado;
                do
                {
                    Console.Write("Digite o nome do convidado: ");
                    nomeConvidado = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(nomeConvidado))
                    {
                        Console.WriteLine("O nome do convidado não pode ser vazio.");
                    }
                } while (string.IsNullOrWhiteSpace(nomeConvidado));

                listaConvidados.Add(new Convidado(contadorCodigoConvidado++, nomeConvidado));

                while (true)
                {
                    Console.Write("Deseja adicionar mais um? Digite sim ou não: ");
                    string adicionarMaisConvidados = Console.ReadLine()?.Trim().ToLower();

                    if (adicionarMaisConvidados == "sim")
                    {
                        break; 
                    }
                    else if (adicionarMaisConvidados == "não")
                    {
                        continuarAdicionando = false;
                        break;
                    }

                    Console.WriteLine("Resposta inválida. Digite apenas sim ou não.");
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
