/* 
    O episódio deve ter um Número, um Título, uma Duracao, um Resumo, TotalConvidados e uma List<Convidado>.
*/
public class Episodio
{
    private static int contadorId;
    public int Numero = 0;
    public string? Titulo { get; }
    public int Duracao { get; }
    public string Resumo { get; }

    public List<Convidado> Convidados = [];

    public Episodio() {}

    public Episodio(string titulo, int duracao, string resumo) 
    {
        this.Numero =  ++contadorId;
        this.Titulo = titulo;
        this.Duracao = duracao;
        this.Resumo = resumo;
    }
    
}