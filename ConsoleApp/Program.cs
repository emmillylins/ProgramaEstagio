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
            //manutencao.JogoAdvinharNumero();
            //manutencao.ClassificarListaNumero();
            //manutencao.VerificaSenha();
            //manutencao.CalculadoraAvancada();
            //manutencao.ValidarCpf();
            //manutencao.SimuladorCaixaEletronico();
            //manutencao.JogoForca();
            //manutencao.GeradorTabuada();
            
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


}
