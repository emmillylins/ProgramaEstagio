

namespace Biblioteca.Classes
{

   
    class Episodios
    {
        
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public string Resumo { get; set; }
        public List<Convidado> Convidados { get; set; } = [];
    }
}
