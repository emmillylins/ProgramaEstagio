public class Convidado
{
    public string? Codigo { get; }
    public string? Nome { get; }

    public Convidado(string codigo, string nome)
    {
        this.Codigo = codigo;
        this.Nome = nome;
    }
}