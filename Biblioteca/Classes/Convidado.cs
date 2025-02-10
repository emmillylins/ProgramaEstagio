using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biblioteca.Classes
{
    public class Convidado
    {
        public Convidado() { }
        public Convidado(string nome, int Codigo)
        {
            this.Nome = nome;
            this.Codigo = Codigo;
        }
        public string Nome { get; set; }
        public int Codigo { get; set; }

        public string Resumo => $"Nome do convidado: {Nome}";
    }
}

