
namespace Biblioteca.Classes
{
    public class Podcast
    {
        public Podcast() { }
        public Podcast(string nome, string apresentador)
        {
            Nome = nome;
            Apresentador = apresentador;
        }

        public string Nome { get; }
        public string Apresentador { get; }
        public List<Episodio> Episodios = new();
        public double DuracaoTotal => Episodios.Sum(epsodio => epsodio.DuracaoMinutos);
        public int TotalEpsodios => Episodios.Count(epsodio => epsodio.Numero != 0);        

    }
}
