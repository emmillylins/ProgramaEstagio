using Biblioteca.Manutencao;

class Program
{
    static void Main()
    {
        try
        {
            var questoes = new Questoes();

            questoes.GerarPodcast();
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.ReadKey();
        }
    }
}
