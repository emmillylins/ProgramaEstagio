using Biblioteca.Classes;
using System.Globalization;

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


        public void MostrarUsuario(List<Usuario> usuarios)
        {
            try
            {
                if (usuarios.Count == 0)
                    Console.WriteLine("\nNenhum usuario cadastrado\n");
                else
                {
                    foreach (var usuario in usuarios)
                    {
                        Console.WriteLine($"\nUsuários cadastrados:" +
                            $"\nNome: {usuario.Nome}" +
                            $"\nEmail: {usuario.Email}" +
                            $"\nIdade: {usuario.Idade}");
                    }
                }
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
                if (!int.TryParse(Console.ReadLine(), out int idade))
                    Console.WriteLine("Digite uma idade válida.");
                else
                    usuario.Idade = idade;

                return usuario;
            }
            catch (Exception) { throw; }
        }

        public double? Depositar()
        {
            Console.Write("\nDigite o valor a ser depositado: ");

            if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double valor) || valor < 0)
            {
                Console.WriteLine($"\nDigite um valor válido.");
                return null;
            }
            return valor;
        }

        public List<double>? Sacar(List<double> saldo)
        {
            Console.Write("\nDigite o valor a ser sacado: ");

            if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double saque) || saque < 0)
            {
                Console.WriteLine($"\nDigite um valor válido.");
                return null;
            }

            var saldoComSaque = saldo.Sum() - saque;
            if (saldoComSaque < 0)
            {
                Console.WriteLine($"O saque: {saque} é menor do que o valor disponível: {saldo.Sum()}");
                return null;
            }
            else
                return [saldoComSaque];
        }
    }
}
