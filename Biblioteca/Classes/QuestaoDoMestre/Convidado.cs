namespace Biblioteca.Classes.QuestaoDoMestre
{
    public class Convidado
    {
        public Convidado() { }

        public Convidado(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}
