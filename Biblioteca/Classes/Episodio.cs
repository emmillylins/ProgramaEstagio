namespace Biblioteca.Classes
{
    public class Episodio
    {
        public Episodio()
        {

        }
        public Episodio(int numero, string titulo)
        {
            this.Numero = numero;
            this.Titulo = titulo;
        }

        public int Numero { get; set; }
        public string Titulo { get; set; }

        public int Duracao { get; set; }

        public int TotalConvidados { get; set; }

        public List<Convidado> Convidados { get; set; } = [];

        public string Resumo => $"Episódio {Numero} - {Titulo} - {Duracao} segundos";
    }
}
