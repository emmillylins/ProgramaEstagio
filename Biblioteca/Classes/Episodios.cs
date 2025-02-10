public class Episodio
{
    private List<Convidado> listaConvidados = new();
    public Episodio(int numero, string titulo, int duracao)
    {
        Numero = numero;
        Titulo = titulo;
        Duracao = duracao;
    }
    public int Numero { get; }
    public string Titulo { get; }
    public int Duracao { get; }
    public string Resumo
    {
        get
        {
            if (listaConvidados.Count > 0)
            {
                return $"Episódio {Numero}: {Titulo}. Duração: {Duracao} mins, " +
                       $"com a participação de: {string.Join(", ", listaConvidados.Select(c => c.Nome))}";
            }
            else
            {
                return $"Episódio {Numero}: {Titulo}. Duração: {Duracao} mins. Não há convidados.";
            }
        }
    }
    public void AdicionarConvidado(Convidado convidado)
    {
        listaConvidados.Add(convidado);
    }
}
