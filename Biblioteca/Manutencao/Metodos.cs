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

        public double Depositar()
        {
            try
            {
                Console.WriteLine("Favor informar o valor a depositar");
                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var saldo) || saldo <= 0)
                {
                    Console.WriteLine("Favor, inserir valor numérico válido");
                };
                return saldo;
            }
            catch (Exception) { throw; }
        }
        public double Sacar(List<double> saldo)
        {
            try
            {

                Console.WriteLine("Por favor informar o saldo a sacar: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var saque) || saque < 0)
                {
                    Console.WriteLine("Favor inserir valor numérico válido");
                    return 0;

                }
                else if (saque <= saldo.Sum())
                {
                    return saque;
                }
                else
                {
                    Console.WriteLine($"O saque {saque} é maior do que o saldo disponivel {saldo.Sum():F2}");
                    return 0;
                }
            }
            catch (Exception) { throw; }
        }

        public int GerarNumero()
        {
            try
            {
                Random random = new Random();
                int numeroSecreto = random.Next(1, 101);
                return numeroSecreto;
            }
            catch (Exception) { throw; }
        }
        public void ClassificarNumeros(List<int> listaNumeros)
        {
            List<int> positivos = new List<int>();
            List<int> negativos = new List<int>();
            List<int> zeros = new List<int>();

            foreach (var numero in listaNumeros)
            {
                if (numero > 0)
                {
                    positivos.Add(numero);
                }
                else if (numero < 0)
                {
                    negativos.Add(numero);
                }
                else
                {
                    zeros.Add(numero);
                }
            }

            Console.WriteLine("\nClassificação dos números:");
            Console.WriteLine("Positivos: " + string.Join(", ", positivos));
            Console.WriteLine("Negativos: " + string.Join(", ", negativos));
            Console.WriteLine("Zeros: " + string.Join(", ", zeros));
        }

        public bool ValidacaoSenhas(string senhaInserida)
        {
            string caracteresPermitidos = "@#/.!')<>(&%$*+-?`´[]^~;:";

            if (senhaInserida.Length < 8)
            {
                Console.WriteLine("Sua senha precisa ter no mínimo 8 caracteres.");
                return false;
            }

            if (!senhaInserida.Any(char.IsUpper))
            {
                Console.WriteLine("Sua senha precisa ter pelo menos uma letra maiúscula.");
                return false;
            }

            if (!senhaInserida.Any(char.IsLower))
            {
                Console.WriteLine("Sua senha precisa ter pelo menos uma letra minúscula.");
                return false;
            }

            if (!senhaInserida.Any(c => caracteresPermitidos.Contains(c)))
            {
                Console.WriteLine("Sua senha precisa ter pelo menos um caractere.");
                return false;
            }
            return true;

        }

        public void AdicionarEpisódio()
        {

        }

        public void ExibirDetalhes(Podcast podcast)
        {
            try
            {
                Console.WriteLine($"Nome do podcast: {podcast.Nome} - Apresentador: {podcast.Apresentador}\n");
                var episodios = podcast.Episodios.OrderBy(e => e.Numero).ToList();

                if (episodios.Count == 0)
                {
                    Console.WriteLine("Não existem episódios neste podcast.");
                    return;
                }

                foreach (var episodio in episodios)
                {
                    Console.WriteLine("");
                }

            }
            catch (Exception) { throw; }
        }

        public void AdicionarConvidados()
        {
            try
            {
                Console.WriteLine("Insira o nome do convidado: ");
                string nomeConvidado = Console.ReadLine();

                if 
            }
            catch (Exception) { throw; }
        }
    }
}
