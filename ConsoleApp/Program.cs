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


            //QUESTIONARIO 3

            //manutencao.JogoNumeroAdvinhação();
            //manutencao.ListaNumeros();
            //manutencao.CadastrarSenha();
            //manutencao.CalculadoraAvancada();
            //manutencao.CaixaEletronico();
            //manutencao.Tabuada();
            //manutencao.JogoForca();
            //manutencao.Cpf();
            //manutencao.Cnpj();
            manutencao.GerarPodcast();

            Console.ReadKey();




        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
