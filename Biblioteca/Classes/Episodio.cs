namespace Biblioteca.Classes
{
    public class Episodio
    {
        public Episodio(int numero, string titulo, int duracao, string resumo, List<Convidado> convidado)
        {
            Numero = numero;
            Titulo = titulo;
            Duracao = duracao;
            Resumo = resumo;
            Convidado = convidado;
        }

        public int Numero { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public string Resumo { get; set; }
        public int TotalConvidados { get; set; }

        public List<Convidado> Convidado { get; set; } = [];
    }
}
