

namespace Biblioteca.Classes
{

   
    public class Episodios
    {
        public Episodios(int numero, string titulo, int duracao, string resumo, int totalConvidados, List<Convidado> convidados)
        {
            this.numero = numero;
            Titulo = titulo;
            Duracao = duracao;
            Resumo = resumo;
            TotalConvidados = totalConvidados;
            Convidados = convidados;
        }

        public int numero { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public string Resumo { get; set; }
        public int TotalConvidados { get; set; }
        public List<Convidado> Convidados { get; set; } = [];
    }
}
