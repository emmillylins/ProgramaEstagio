namespace Biblioteca.Classes
{
    public class Podcast
    {
        private List<Epsodio> epsodios = new();

        public Podcast(string nome, string apresentador)
        {
            Nome = nome;
            Apresentador = apresentador;
        }

        public string Nome { get; }
        public string Apresentador { get; }

        public int DuracaoTotal => epsodios.Sum();
    }
}
