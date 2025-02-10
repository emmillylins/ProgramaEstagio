namespace Biblioteca.Classes
{
    public class Podcast
    {
        public Podcast()
        {

        }
        public Podcast(string apresentador, string nome)
        {
            Apresentador = apresentador;
            Nome = nome;
        }

        public string Apresentador { get; set; }
        public string Nome { get; set; }
        public int TotalEpisodios { get; set; }
        public List<Episodio> Episodios { get; set; }
    }
}
