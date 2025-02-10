public class Convidado
{
    private static int contadorId;
    public string? Codigo { get; }
    public string? Nome { get; }

    public Convidado(string nome)
    {
        this.Codigo = $"CONV-{++contadorId}";
        this.Nome = nome;
    }
}