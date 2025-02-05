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
            // manutencao.ListaProdutoPreco();
            //manutencao.GenrenciamentoALunos();
            //manutencao.JogoAdvinhacao();
            //manutencao.LerListaNumeros();
            //manutencao.LerListaNumeros();
            manutencao.CalculadoraAvancada();
            Console.ReadKey();
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
