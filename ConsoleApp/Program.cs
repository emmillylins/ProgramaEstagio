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
            // manutencao.CalculadoraAvancada();//Questao 4
            //manutencao.ValidarCpf(); //Questão 5
            //manutencao.SimularSaque();//Questão 6 
            //manutencao.JogoDaForca(); //Questão 7 
            //manutencao.GeradorTabuadaPersonalizada(); //Questão 8
            //manutencao.ValidacaoDeCNPJ(); //Questão 9 
           


            manutencao.CriarPodCast();


            Console.ReadKey();

        }
        catch (Exception){ throw; }
        
    }
}
