using Biblioteca.Manutencao;

class Program
{
    static void Main()
    {
        try
        {
            var manutencao = new Questoes();

            #region Formulário #2
            //manutencao.VerificaNumeroPrimo();
            //manutencao.ExibirNumParImpar();
            //manutencao.ListarNumerosPositivo();
            //manutencao.ExibeQtdMultiplosDeTres();
            //manutencao.InformaNumeroMaiorMenor();
            //manutencao.CaixaEletronico(3500.95);
            //manutencao.ListaProdutoPreco();
            //manutencao.GenrenciamentoALunos();
            #endregion

            #region Formulário 3
            //manutencao.JogoAdivinhacao(); //1
            //manutencao.ClassificacaoNumeros(); //2
            //manutencao.VerificaSenha(); //3
            //manutencao.CalculadoraAvancada(); //4
            //manutencao.VerificaCPF(); //5
            //manutencao.SimuladorCaixaEletronico(); //6
            //manutencao.GeradorTabuada(); //8

            #endregion

            #region Desafio do Mestre (Alura)
            manutencao.GestaoPodcast();
            #endregion

            Console.ReadKey();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadKey();
        }
    }
}
