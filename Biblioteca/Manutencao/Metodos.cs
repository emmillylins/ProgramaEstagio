using Biblioteca.Classes;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace Biblioteca.Manutencao
{
    public class Metodos
    {
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
            try
            {
                Usuario usuario = new Usuario();
                Console.WriteLine("Insira seu nome: ");
                usuario.Nome = Console.ReadLine();

                Console.Write("Insira seu E-mail: ");
                usuario.Email = Console.ReadLine();

                Console.Write("Insira sua senha: ");
                usuario.Senha = Console.ReadLine();

                Console.Write("Insira sua idade: ");
                if (!int.TryParse(Console.ReadLine(), out var idade))
                {
                    throw new Exception("Insira apenas valores numéricos!");
                }
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
        public Produto? CadastrarProduto()
        {
            try
            {
                Produto meuProduto = new Produto();

                Console.Write("Insira o nome do produto: ");
                meuProduto.Nome = Console.ReadLine();

                if (string.IsNullOrEmpty(meuProduto.Nome))
                {
                    Console.WriteLine("O nome do produto não pode ser nulo");
                    return null;
                }
                else
                {
                    Console.Write("Insira o preço do produto: ");

                    if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var preco))
                    {
                        Console.WriteLine("Insira o preco válido para o produto.");
                        return null;
                    }

                    else if (preco <= 0)
                    {
                        Console.WriteLine("O preço do produto não pode ser igual ou menor que zero");
                        return null;
                    }

                    meuProduto.Preco = preco;


                    return meuProduto;
                }
            }
            catch (Exception) { throw; }

        }
        public double CalcularValorTotal(List<Produto> produtos)
        {
            try
            {
                if (produtos.Count == 0)
                {
                    Console.WriteLine("Não há produtos na lista.");
                    return 0;
                }
                else
                {
                    double valorTotal = 0;
                    foreach (Produto produto in produtos)
                    {
                        valorTotal = valorTotal + produto.Preco;
                    }
                    return valorTotal;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ExibirListaProdutos(List<Produto> produtos)
        {
            foreach (Produto produto in produtos)
            {
                Console.WriteLine($"\n Nome do Produto: {produto.Nome}\nPreço: {produto.Preco}");
            }
        }
        public Aluno? CadastrarAluno()
        {
            try
            {
                Aluno aluno = new();
                Console.Clear();

                Console.Write("Digite o nome do aluno: ");
                aluno.Nome = Console.ReadLine();
                if (string.IsNullOrEmpty(aluno.Nome))
                {
                    Console.WriteLine("O aluno precisa ter um nome");
                    return null;
                }

                for (var i = 1; i < 5; i++)
                {
                    Console.WriteLine($"Digite a {i}° nota");
                    if (!double.TryParse(Console.ReadLine()!, CultureInfo.InvariantCulture, out var nota) || nota < 0 || nota > 10)
                    {
                        Console.WriteLine("Digite uma nota válida");
                        i--;
                    }
                    else
                    {
                        aluno.Notas.Add(nota);
                    }
                }

                return aluno;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void ExibirAlunos(List<Aluno> listaAlunos)
        {
            Console.WriteLine("\nLista de Alunos:");
            foreach (Aluno aluno in listaAlunos)
            {
                Console.WriteLine($"Id do aluno: {aluno.Id}");
                Console.WriteLine($"Nome do aluno: {aluno.Nome}");
                Console.WriteLine("\nNotas: ");
                foreach (double nota in aluno.Notas)
                {
                    Console.WriteLine($"Nota: {nota}");
                }

                var media = aluno.Notas.Average();
                Console.WriteLine($"Media: {media}");

                switch (media)
                {
                    case >= 7:
                        Console.WriteLine("Aprovado");
                        break;
                    case >= 5 and < 7:
                        Console.WriteLine("Recuperação");
                        break;
                    case < 5:
                        Console.WriteLine("Reprovado");
                        break;
                }
            }
        }
        public void BuscaAlunoPorId(List<Aluno> alunos)
        {
            Console.WriteLine("\nBusca aluno pelo seu Id.");
            Console.WriteLine("Digite o id do aluno que você deseja buscar: ");
            if (!int.TryParse(Console.ReadLine(), out var id) || id <= 0)
            {
                Console.WriteLine("Insira um id válido");
                return;
            }

            var aluno = alunos.Find(aluno => aluno.Id == id);
            if (aluno == null)
            {
                Console.WriteLine("O aluno não foi encontrado.");
                return;
            }

            Console.WriteLine($"Aluno: {aluno.Nome}");
            var i = 1;
            foreach (double nota in aluno.Notas)
            {
                Console.WriteLine($"{i}° Nota: {nota}");
                i++;
            }

            var media = aluno.Notas.Average();
            Console.WriteLine($"Média: {media}");
            switch (media)
            {
                case >= 7:
                    Console.WriteLine("Aprovado");
                    break;
                case > 5 and < 7:
                    Console.WriteLine("Recuperação");
                    break;
                case < 5:
                    Console.WriteLine("Reprovado");
                    break;
            }
        }
        public void ExibirMenu()
        {
            Console.WriteLine("\nSelecione uma opcao abaixo: ");
            Console.WriteLine("1 - Insira numero(s) inteiro(s)");
            Console.WriteLine("2 - Classificação dos numeros");
            Console.WriteLine("3 - Sair\n");
            Console.Write("Digite a opção escolhida: ");
        }
        public bool ValidarSenha(string senha)
        {
            if (senha.Length < 8)
            {
                Console.WriteLine("Precisa ter ao menos 8 caracteres");
                return false;
            }
            if (!senha.Any(char.IsUpper))
            {
                Console.WriteLine("Precisa ter ao menos uma letra maiuscula");
                return false;
            }
            if (!senha.Any(char.IsLower))
            {
                Console.WriteLine("Precisa ter ao menos uma letra minuscula");
                return false;
            }
            if (!senha.Any(c => !char.IsLetterOrDigit(c)))
            {
                Console.WriteLine("Precisa ter caracteres especiais");
                return false;
            }
            return true;
        }
        public void ExibirMenuCalculadora()
        {
            Console.WriteLine("Calculadora avançada com Operações Avançadas");
            Console.WriteLine("Escolha abaixo o tipo de operação desejada: ");
            Console.WriteLine("1 - Adição");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Potenciação");
            Console.WriteLine("6 - Raiz Quadrada");
            Console.WriteLine("7 - Sair");
            Console.Write("\nEntrar no menu: ");
        }
        public double MenuCalculadoraSoma(List<double> lista)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Menu Adição");

                for (int i = 0; i < 2; i++)
                {
                    Console.Write($"Digite o {i + 1}º numero: ");
                    if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var num))
                    {
                        Console.WriteLine("Digite apenas numeros validos");
                        i--;
                        continue;
                    }
                    lista.Add(num);
                }
                return lista.Sum();
            }
            catch (Exception) { throw; }
        }
        public double MenuCalculadoraSubtracao(List<double> lista)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Menu Subtração");

                for (int i = 0; i < 2; i++)
                {
                    Console.Write($"Digite o {i + 1}º numero: ");
                    if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var num))
                    {
                        Console.WriteLine("Digite apenas numeros validos");
                        i--;
                        continue;
                    }
                    lista.Add(num);
                }
                double resultadoSubtracao = lista[0] - lista[1];
                return resultadoSubtracao;
            }
            catch (Exception) { throw; }
        }
        public double MenuCalculadoraMultiplicacao(List<double> lista)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Menu Multiplicação");

                for (int i = 0; i < 2; i++)
                {
                    Console.Write($"Digite o {i + 1}º numero: ");
                    if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var num))
                    {
                        Console.WriteLine("Digite apenas numeros validos");
                        i--;
                        continue;
                    }
                    lista.Add(num);
                }
                double resultadoMultiplicacao = lista[0] * lista[1];
                return resultadoMultiplicacao;
            }
            catch (Exception) { throw; }
        }
        public double MenuCalculadoraDivisao(List<double> lista)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Menu Divisão");

                for (int i = 0; i < 2; i++)
                {
                    Console.Write($"Digite o {i+1}º numero: ");
                    if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var num))
                    {
                        Console.WriteLine("Digite apenas numeros validos");
                        i--;
                        continue;
                    }
                    lista.Add(num);
                }

                if (lista[1] == 0)
                {
                    Console.WriteLine("O numero nao pode ser divisivel por zero");
                    return double.NaN;
                }

                double resultadoDivisao = lista[0] / lista[1];
                return resultadoDivisao;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                return double.NaN; // Return NaN in case of an unexpected exception
            }
        }
        public double MenuCalculadoraPotenciacao(List<double> lista)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Menu Potenciação");
                Console.WriteLine("Sendo o 1º numero a base e o 2º numero o expoente");

                for (int i = 0; i < 2; i++)
                {
                    Console.Write($"Digite o {i + 1}º numero: ");
                    if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var num))
                    {
                        Console.WriteLine("Digite apenas numeros validos");
                        i--;
                        continue;
                    }
                    lista.Add(num);
                }
                double resultadoPotenciacao = Math.Pow(lista[0], lista[1]);
                return resultadoPotenciacao;
            }
            catch (Exception) { throw; }
        }
        public double MenuCalculadoraRaizQuadrada(List<double> lista)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Menu Raiz Quadrada");

                for (int i = 0; i < 1; i++)
                {
                    Console.Write($"Digite o {i + 1}º numero: ");
                    if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var num) || num < 0)
                    {
                        Console.WriteLine("Digite apenas numeros validos e positivos");
                        i--;
                        continue;
                    }
                    lista.Add(num);
                }
                double resultadoRaizQuadrada = Math.Sqrt(lista[0]);
                return resultadoRaizQuadrada;
            }
            catch (Exception) { throw; }
        }
        public int SacarCedulas(double saldoAtual)
        {
            Console.WriteLine("Digite o valor do saque: ");
            Console.WriteLine("(Multiplos de 10)");

            if (!int.TryParse(Console.ReadLine(), out var valorSaque) || valorSaque <= 0 || valorSaque % 10 != 0)
            {
                Console.WriteLine("Valor invalido, favor digite um valor valido e positivo");
                return 0;
            }

            if (valorSaque > saldoAtual)
            {
                Console.WriteLine("Saldo insuficiente");
                return 0;
            }

            Metodos metodos = new Metodos();
            metodos.CalcularNotas(valorSaque);

            return valorSaque;
        }
        public void CalcularNotas(int valorSaque)
        {
            List<int> notas = new List<int> { 100, 50, 20, 10 };

            Console.WriteLine("Notas disponiveis");

            for (int i = 0; i < notas.Count; i++)
            {
                int quantidade = valorSaque / notas[i];

                valorSaque = valorSaque - (quantidade * notas[i]);

                if (quantidade > 0)
                {
                    Console.WriteLine($"{quantidade} notas de {notas[i]} reais");
                }
            }
        }
    }
}
