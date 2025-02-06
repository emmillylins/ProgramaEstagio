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
            //manutencao.JogoAdivinhacao();
            //manutencao.ProgramaLeitorNumeros();
            //manutencao.ProgramaValidarSenha();
            //manutencao.ProgramaValidarCPF();
            manutencao.ProgramaValidarCNPJ();

            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
