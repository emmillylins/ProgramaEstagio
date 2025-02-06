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


        #region usuario
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
        #endregion

        #region CaixaEletronico
        public double Depositar()
        {
            try
            {
                Console.Write("\nDigite o valor a ser depositado: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double valor)
                    || valor <= 0)
                {
                    Console.WriteLine($"\nDigite um valor válido.");
                    return 0;
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
                    Console.WriteLine($"{i}° produto:" +
                                    $"\nNome: {produto.Nome}" +
                                    $"\nPreço: {produto.Preco}\n");
                    i++;
                }
                Console.WriteLine($"Valor total da compra: {valorTotal}");
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region GerenciarNotas
        public void ExibeMediaAluno(double media)
        {
            try
            {
                Console.WriteLine($"Média do aluno: {media:F2}");
                Console.Write($"Situação: ");
                switch (media)
                {
                    case > 7:
                        Console.WriteLine("Aprovado");
                        break;
                    case < 7 and >= 5:
                        Console.WriteLine("Em recuperação");
                        break;
                    case < 5:
                        Console.WriteLine("Reprovado.");
                        break;
                    default:
                        Console.WriteLine("Valor inválido");
                        break;
                }
            }
            catch (Exception) { throw; }
        }

        public Aluno? CadastrarAluno()
        {
            try
            {
                var aluno = new Aluno();

                Console.Write("Digite o nome um aluno: ");
                aluno.Nome = Console.ReadLine();

                if (string.IsNullOrEmpty(aluno.Nome))
                {
                    Console.WriteLine("Aluno precisa ter um nome.");
                    return null;
                }
                else
                {
                    for (int i = 1; i < 5; i++)
                    {
                        Console.Write($"Digite a {i}° nota: ");

                        if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double nota)
                            || (nota < 0 || nota > 10))
                        {
                            Console.WriteLine($"\nA {i}º nota é inválida.");
                            i--;
                        }
                        else
                        {
                            aluno.Notas.Add(nota);
                        }
                    }
                }
                return aluno;
            }
            catch (Exception) { throw; }
        }

        public void ExibirALunos(List<Aluno> alunos)
        {
            try
            {
                int i = 1, b = 1;

                if (alunos.Count == 0)
                    Console.WriteLine("Não existem alunos cadastrado.");
                else
                {
                    Console.WriteLine("\nLista de alunos cadastrados: ");
                    foreach (var aluno in alunos)
                    {
                        Console.WriteLine($"\n{i}° aluno:\nNome: {aluno.Nome}\n");
                        foreach (var nota in aluno.Notas)
                        {
                            Console.WriteLine($"{b}º nota: {nota}");
                            b++;
                        }

                        double media = aluno.Notas.Average();
                        ExibeMediaAluno(media);

                        i++;
                    }
                }
            }
            catch (Exception) { throw; }
        }

        public void ExibirALunosPorId(List<Aluno> alunos)
        {
            try
            {
                int i = 1;

                while (true)
                {
                    Console.WriteLine("\nDigite o Id do aluno cadastrado: ");
                    if (!int.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var id))
                    {
                        Console.WriteLine("Digite um valor válido;");
                        break;
                    }

                    var aluno = alunos.Find(aluno => aluno.Id == id);
                    if (aluno is null)
                    {
                        Console.WriteLine($"Aluno de Id id não existente.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"\nNome do aluno: {aluno.Nome}");
                        foreach (var nota in aluno.Notas)
                        {
                            Console.WriteLine($"{i}º nota: {nota}");
                            i++;
                        }

                        double media = aluno.Notas.Average();
                        ExibeMediaAluno(media);
                    }
                }
            }
            catch (Exception) { throw; }
        }
        #endregion

        /// <summary>
        /// calcula números de acordo com a opção envidada. As opções são:
        /// 1 - Adição; 2 - Subtração; 3 - Multiplicação; 4 - Divisão; 5 - Potenciação; 6 - Raiz Quadrada;
        /// </summary>
        /// <param name="opcao"></param>
        public void CalculaNumeros(int opcao)
        {
            try
            {
                double num1, num2 = 0;
                Console.Write("Digite o primeiro número: ");

                if (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Entrada inválida!");
                    return;
                }

                if (opcao != 6) // Raiz quadrada só precisa de um número	
                {
                    Console.Write("Digite o segundo número: ");
                    if (!double.TryParse(Console.ReadLine(), out num2))
                    {
                        Console.WriteLine("Entrada inválida!");
                        return;
                    }
                }

                double resultado = 0;
                switch (opcao)
                {
                    case 1: 
                        resultado = num1 + num2; 
                        break;
                    case 2: 
                        resultado = num1 - num2; 
                        break;
                    case 3: 
                        resultado = num1 * num2; 
                        break;
                    case 4:
                        if (num2 == 0)
                        {
                            Console.WriteLine("Erro: divisão por zero não permitida.");
                            return;
                        }
                        resultado = num1 / num2;
                        break;
                    case 5:
                        resultado = Math.Pow(num1, num2);
                        break;
                    case 6:
                        resultado = Math.Sqrt(num1);
                        break;
                }
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (Exception) { throw; }
        }
    }
}
