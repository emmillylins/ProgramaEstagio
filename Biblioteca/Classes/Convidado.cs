public class Convidado
{
    private static int contador = 1;
    public Convidado(string nome)
    {
        Id = contador++;
        Nome = nome;
    }
    public int Id { get; }
    public string Nome { get; }
}
