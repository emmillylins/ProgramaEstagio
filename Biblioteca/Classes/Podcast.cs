namespace Biblioteca.Classes
{
    class Podcast
    {
        public Podcast(string apresentador, string nome, int totalEpisodios, List<Episodio> episodios)
        {
            Apresentador = apresentador;
            Nome = nome;
            TotalEpisodios = totalEpisodios;
            Episodios = episodios;
        }

        public string Apresentador { get; set; }
        public string Nome { get; set; }

        public int TotalEpisodios { get; set; }
        public List<Episodio> Episodios { get; set; }
    }
}
