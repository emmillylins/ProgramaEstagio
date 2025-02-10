using System.Globalization;
using Biblioteca.Classes;

public class Episodios
{
    public Episodios(int numero, string titulo, double duracao)
    {
        Numero = numero;
        Titulo = titulo;
        Duracao = duracao;
        Convidados = new List<Convidado>();
    }

    public int Numero { get; }
    public string Titulo { get; }
    public double Duracao { get; }
    public int TotalConvidados => Convidados.Count();
    public List<Convidado> Convidados = new List<Convidado>();

    public void AdicionarConvidado(Convidado convidado)
    {
        Convidados.Add(convidado);
    }
    

    public string Resumo
    {
        get
        {
            string convidados = Convidados.Any()
                ? string.Join(", ", Convidados.Select(c => c.Nome))
                : "Nenhum convidado";
            return $"Episódio {Numero}: {Titulo} ({Duracao} min) - Convidados: {convidados}";
        }
    }
}