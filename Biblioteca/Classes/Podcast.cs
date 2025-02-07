
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
        private List<Epsodio> Epsodios = new();

        public int DuracaoTotal => Epsodios.Sum(epsodio => epsodio.DuracaoSegundos);
        public int TotalEpsodios => Epsodios.Max(epsodio => epsodio.Numero);
    }
}
