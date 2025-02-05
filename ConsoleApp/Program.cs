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
            // manutencao.JogoNumeroAdvinhação();
            //manutencao.ListaNumeros();
            // manutencao.CadastrarSenha();
            //manutencao.CalculadoraAvancada();
            //manutencao.CaixaEletronico();
            manutencao.Tabuada();


            Console.ReadKey();
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
