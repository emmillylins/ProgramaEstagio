using System.Text;

public class Episodio
{
    public Episodio(int numero, int duracao, string titulo)
    {
        Numero = numero;
        Duracao = duracao;
        Titulo = titulo;
        convidadosList = new();
    }

    public int Numero { get; }
    public int Duracao { get; }
    public string Titulo { get; }
    public string Resumo => $"Episódio {Numero}: {Titulo} com duração de {new TimeSpan(0, 0, 0, 0, Duracao)} com a participação de {RetornarConvidados()}.";
    public List<Convidado> ConvidadosList => convidadosList;
    public int TotalConvidados => convidadosList.Count;

    private readonly List<Convidado> convidadosList;

    public void AdicionarConvidado(Convidado convidado)
    {
        convidadosList.Add(convidado);
    }

    string RetornarConvidados()
    {
        //O StringBuilder é usado para construir strings de forma mais eficiente, especialmente
        //quando há muitas concatenações, já que ele evita a criação de múltiplas instâncias de strings,
        //o que aconteceria se usássemos a operação + repetidamente.
        StringBuilder retorno = new StringBuilder();
        //Para cada convidado, é acessado o seu nome
       //(presumivelmente por meio de convidado.Nome),
        //e esse nome é adicionado ao StringBuilder (retorno), seguido de uma vírgula e um espaço.
        foreach (var convidado in convidadosList)
            retorno.Append($"{convidado.Nome}, ");
        if (retorno.Length > 0)
            //Se houver convidados (a lista não estiver vazia), a função retorna a string construída, mas com o último caractere (vírgula e espaço) removido.
            //Isso é feito utilizando o método Substring(0, retorno.Length - 2), que pega a substring do início até o comprimento da string menos 2 caracteres.
            return retorno.ToString().Substring(0, retorno.Length - 2); //Remove vírgula e espaço extra no final
        else
            return "nenhum convidado neste episódio.";
    }
}

