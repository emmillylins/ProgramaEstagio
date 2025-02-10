//public class Convidado
//{
//    public Convidado(string nome)
//    {
//        Nome = nome;
//    }
//    public string Nome { get; }
//}

public class Convidado
{
    public string Nome { get; set; }
    public string Profissao { get; set; }

    public Convidado(string nome, string profissao)
    {
        Nome = nome;
        Profissao = profissao;
    }
}
