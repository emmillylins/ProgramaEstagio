
using Biblioteca.Classes;
public class Podcasts
{
    public Podcasts(string nomePodcast, string apresentadorPodcast)
    {
        NomePodcast = nomePodcast;
        ApresentadorPodcast = apresentadorPodcast;
        ListaEpisodios = new List<Episodios>();
    }

    public string NomePodcast { get; }
    public string ApresentadorPodcast { get; }
    public int TotalEpisodios => ListaEpisodios.Count();
    public List<Episodios> ListaEpisodios = [];
    public void AdicionarEpisodio(Episodios episodio)
    {
        ListaEpisodios.Add(episodio);
    }
}
