public class Podcast
{
    private List<Episodio> listaEpisodios = new();
    public Podcast(string nome, string apresentador)
    {
        Nome = nome;
        Apresentador = apresentador;
    }
    public string Nome { get; }
    public string Apresentador { get; }
    public int TotalEpisodios => listaEpisodios.Count;
    public void AdicionarEpisodio(Episodio episodio)
    {
        listaEpisodios.Add(episodio);
    }
    public Episodio BuscarEpisodioPorNumero(int numero)
    {
        return listaEpisodios.FirstOrDefault(e => e.Numero == numero)!;
    }
    public void ExibirDetalhes()
    {
        Console.WriteLine($"Podcast: {Nome}, Apresentador: {Apresentador}");
        foreach (var episodio in listaEpisodios.OrderBy(e => e.Numero))
        {
            Console.WriteLine(episodio.Resumo);
        }
        Console.WriteLine($"Total de episódios: {TotalEpisodios}");
        Console.ReadKey();
        Console.Clear();
    }
}
