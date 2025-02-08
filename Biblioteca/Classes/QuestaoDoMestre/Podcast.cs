using Biblioteca.Classes.QuestaoDoMestre;

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

        public string Nome { get; set; }
        public string Apresentador { get; set; }
        public int TotalEpisodios { get; set; }
        public List<Episodio> Episodios { get; set; } = [];

    }
}
