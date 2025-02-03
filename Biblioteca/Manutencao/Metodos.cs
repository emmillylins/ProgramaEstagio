using Biblioteca.Classes;

namespace Biblioteca.Manutencao
{
    public class Metodos
    {
        //O primeiro vai ser sempre o maior e o segundo vai ser sempre o menor.
        public (double, double) RetornaNumeroMaiorMenor(List<double> listaNumeros)
        {
            try
            {
                double maior = 0, menor = 0;

                maior = listaNumeros.Max();
                menor = listaNumeros.Min();

                return (maior, menor);
            }
            catch (Exception) { throw; }
        }

        public Usuario CadastrarUsuario()
        {
            var usuario = new Usuario();
            try
            {
                Console.Write("Digite um nome: ");
                usuario.Nome = Console.ReadLine();

                Console.Write("Digite um email: ");
                usuario.Email = Console.ReadLine();

                Console.Write("Digite uma idade: ");
                if (!int.TryParse(Console.ReadLine(), out int numero))
                    Console.WriteLine("Digite uma idade válida.");

                return usuario;
            }
            catch (Exception) { throw; }
        }
    }
}
