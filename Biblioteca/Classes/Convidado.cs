namespace Biblioteca.Classes
{
    public class Convidado
    {
        public Convidado() { }
        public Convidado(int contador, string nome)
        {
            Codigo = contador;
            Nome = nome;
        }

        public int Codigo { get; }
        public string Nome { get; }
    }
}
