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

        #region CaixaEletronico
        public double? Depositar()
        {
            try
            {
                Console.Write("\nDigite o valor a ser depositado: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double valor)
                    || valor < 0)
                {
                    Console.WriteLine($"\nDigite um valor válido.");
                    return null;
                }
                return valor;
            }
            catch (Exception) { throw; }
        }

        public List<double>? Sacar(List<double> saldo)
        {
            try
            {
                Console.Write("\nDigite o valor a ser sacado: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double saque)
                    || saque < 0)
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
            catch (Exception) { throw; }
        }
        #endregion

        #region produtos
        public Produto? CadastrarProduto()
        {
            try
            {
                var produto = new Produto();

                Console.Write("Digite o nome um produto: ");
                produto.Nome = Console.ReadLine();

                Console.Write("Digite o preço: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double preco)
                    || preco < 0)
                {
                    Console.WriteLine($"\nDigite um valor válido.");
                    return null;
                }
                produto.Preco = preco;

                return produto;
            }
            catch (Exception) { throw; }
        }

        public void ListarProdutos(List<Produto> produtos, double valorTotal)
        {
            try
            {
                int i = 1;

                Console.WriteLine("\nLista de produtos: ");
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"{i}° produto:\nNome: {produto.Nome}\nPreço: {produto.Preco}\n");
                    i++;
                }
                Console.WriteLine($"Valor total da compra: {valorTotal}");
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region GerenciarNotas
        public Aluno CadastrarAluno()
        {
            try
            {
                var aluno = new Aluno();

                Console.Write("Digite o nome um Aluno: ");
                aluno.Nome = Console.ReadLine();

                for (int i = 0; i < 4; i++)
                {
                    Console.Write($"Digite a {i + 1}° nota: ");

                    if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double nota)
                        || (nota < 0 || nota > 10))
                    {
                        Console.WriteLine($"\nA nota {i + 1} é inválida.");
                        i--;
                    }
                    else
                    {
                        aluno.Notas.Add(nota);
                    }
                }
                return aluno;
            }
            catch (Exception) { throw; }
        }

        //public void ExibirALunos(List<Aluno> alunos)
        //{
        //    try
        //    {
        //        int i = 1, b = 1;

        //        Console.WriteLine("\nLista de alunos cadastrados: ");
        //        foreach (var aluno in alunos)
        //        {
        //            Console.WriteLine($"{i}° aluno:\nNome: {aluno.Nome}n");
        //            foreach (var nota in aluno.Notas)
        //            {
        //                Console.WriteLine($""
        //            }
        //            i++;
        //        }
        //        Console.WriteLine($"Valor total da compra: {valorTotal}");
        //    }
        //    catch (Exception) { throw; }
        //}

        #endregion
    }
}
