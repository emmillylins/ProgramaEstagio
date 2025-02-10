namespace Biblioteca.Classes
{
    public class Podcast
    {
        public Podcast()
        {
        }
        public Podcast(string nome, string descricao)
        {
            this.Nome = nome;
            this.Descricao = descricao;
        }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int TotalEpisodios { get; set; }
        public string Apresentador { get; set; }
        public List<Episodio> Episodios { get; set; } = [];

        public string Resumo => $"Podcast {Nome} - {Descricao}";
    }
}
