using Biblioteca.Manutencao;

class Program
{
    static void Main()
    {
        try
        {
            var manutencao = new Questoes();

            //manutencao.VerificaNumeroPrimo();
            //manutencao.ExibirNumParImpar();
            //manutencao.ListarNumerosPositivo();
            //manutencao.ExibeQtdMultiplosDeTres();
            //manutencao.InformaNumeroMaiorMenor();
            //manutencao.CaixaEletronico(3500.95);
            //manutencao.ListaProdutoPreco();
            //manutencao.GenrenciamentoALunos();

            // Formulário 3
            //manutencao.JogoAdivinhacao(); //1
            //manutencao.ClassificacaoNumeros(); //2
            //manutencao.CalculadoraAvancada(); //4
            //manutencao.SimuladorCaixaEletronico(); //6
            manutencao.GeradorTabuada(); //8

            Console.ReadKey();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
