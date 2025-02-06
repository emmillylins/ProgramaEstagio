using Biblioteca.Manutencao;

class Program
{
    static void Main()
    {
        try
        {
            var manutencao = new Questoes();

            manutencao.JogoForca();
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
