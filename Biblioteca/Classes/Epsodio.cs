namespace Biblioteca.Classes
{
    public class Epsodio
    {
        //O resumo do episódio será concatenado com os valores de número, título, duração e convidados do episódio.
        
        public Epsodio() { }
        public Epsodio(int numero, string titulo, int duracaoSegundos)
        {
            Numero = numero;
            Titulo = titulo;
            DuracaoSegundos = duracaoSegundos;
        }

        public int Numero { get; }
        public string Titulo { get; }
        public int DuracaoSegundos { get; }
        private List<Convidado> Convidados = new();
    }
}
