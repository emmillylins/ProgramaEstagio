namespace Biblioteca.Classes
{
    public class Convidado
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        // Construtor
        public Convidado(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }
    }
}
