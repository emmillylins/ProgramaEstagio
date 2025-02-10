using Biblioteca.Classes;

public class Episodios
{
    public int Numero { get; set; }
    public string Titulo { get; set; }
    public double Duracao { get; set; }
    public string Resumo { get; set; }
    public List<Convidado> Convidados { get; set; }

    public Episodios(int numero, string titulo, double duracao, string resumo, List<Convidado> convidados)
    {
        Numero = numero;
        Titulo = titulo;
        Duracao = duracao;
        Resumo = resumo;
        Convidados = convidados; 
    }
}
