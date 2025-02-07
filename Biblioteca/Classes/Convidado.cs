using System;
using System.Collections.Generic;
namespace Biblioteca.Classes
{
    public class Convidado
    {
        public Convidado(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}
