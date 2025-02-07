namespace Biblioteca.Classes
{
    public class Convidado
    {
        public Convidado() { }
        public Convidado(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public int Codigo { get; }
        public string Nome { get; }
    }
}
