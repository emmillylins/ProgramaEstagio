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
            //manutencao.SistemaLogin();

            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
