using System.Numerics;

namespace Biblioteca.Classes
{
    public class Episodio
    {
        //O resumo do episódio será concatenado com os valores de número, título, duração e convidados do episódio.
        
        public Episodio() { }

        public Episodio(int numero, string titulo, string resumo, double duracaoMinutos)
        {
            Numero = numero;
            Titulo = titulo;
            Resumo = resumo;
            DuracaoMinutos = duracaoMinutos;
        }

        public int Numero { get; }
        public string Titulo { get; }
        public string Resumo { get; }
        public double DuracaoMinutos { get; }
        public List<Convidado> Convidados = new();
    }
}
