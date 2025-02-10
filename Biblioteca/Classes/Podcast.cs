namespace Biblioteca.Classes;

public class Podcast
{
    public  List<Episodio> Episodios = new List<Episodio>();
    public string? Nome { get; }
    public string? Apresentador { get; }

    public Podcast() {}
    public Podcast(string nome, string apresentador) 
    {
        this.Nome = nome;
        this.Apresentador = apresentador;
    }

}
