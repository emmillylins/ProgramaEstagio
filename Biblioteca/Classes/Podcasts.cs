

namespace Biblioteca.Classes
{
    public class Podcasts
    {
        public Podcasts(string nomePodcast, string apresentadorPodcast)
        {
            NomePodcast = nomePodcast;
            ApresentadorPodcast = apresentadorPodcast;
           
        }

        public string NomePodcast { get; set; }
        public string ApresentadorPodcast { get; set; }
        public int TotalEpisodios { get; set; }
        public List<Episodios> Episodio { get; set; } = [];





    }


}
