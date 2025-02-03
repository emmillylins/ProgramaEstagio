using Biblioteca.Manutencoes;

class Program
{
    static void Main()
    {
        try
        {
            var manutencao = new Manutencao();

            // manutencao.VerificaNumeroPrimo();
            // manutencao.ExibirNumParImpar();
            //manutencao.ListarNumerosPositivo();
            //manutencao.ExibeQtdMultiplosDeTres();
            manutencao.InformaNumeroMaiorMenor();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
