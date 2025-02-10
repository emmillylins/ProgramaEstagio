public class Podcast
{
    public Podcast(string nome, string apresentadorPodCast)
    {
        Nome = nome;
        ApresentadorPodCast = apresentadorPodCast;
        episodiosList = new();
    }

    public string Nome { get; }
    public string ApresentadorPodCast { get; }
    public int TotalEpsodios => episodiosList.Count;
    public List<Episodio> EpisodiosList => episodiosList;

    private readonly List<Episodio> episodiosList;

    public void AdicionarEpisodio(Episodio episodio)
    {
        episodiosList.Add(episodio);
    }
}

