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

            //forms3
            //manutencao.CriarJogoAdivinhacao(); //Questão 1
            //manutencao.LeiaListaNumerosInteiros(); //Questão 2
            //manutencao.ProgramaDeValidarSenha(); //Questão 3
            //manutencao.ProgramaDeValidarSenha(); //Questão 4


            Console.ReadKey();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}