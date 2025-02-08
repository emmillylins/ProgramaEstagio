namespace Biblioteca.Classes.QuestaoDoMestre
{
    public class Episodio
    {
        public Episodio() { }

        public Episodio(int numero, string titulo, double duracao, string resumo)
        {
            Numero = numero;
            Titulo = titulo;
            Duracao = duracao;
            Resumo = resumo;
        }

        public int Numero { get; set; }
        public string Titulo { get; set; }
        public double Duracao { get; set; }
        public string Resumo { get; set; }
        public int TotalConvidados { get; set; }
        public List<Convidado> Convidados { get; set; } = [];
    }
}
