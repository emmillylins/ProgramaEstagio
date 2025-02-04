namespace Biblioteca.Classes
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<double> Notas { get; set; } = new();
    }
}
