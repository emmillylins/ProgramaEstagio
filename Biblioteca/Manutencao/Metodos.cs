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


        // metodo cadastrar usuário
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

        // Método listar Usuário

        public void MostrarUsuario(List<Usuario> usuarios)
        {
            try
            {

                foreach (var usuario in usuarios)
                {
                    Console.WriteLine(@$"nome: {usuario.Nome}
                                        E-mail: {usuario.Email}
                                        Senha: {usuario.Senha}
                                        Idade: {usuario.Idade}"
                                        );
                }
                if (usuarios.Count == 0)
                {
                    Console.WriteLine("Nenhum usuario cadastrado");
                }

            }
            catch (Exception) { throw; }

        }

        internal int? Depositar => throw new NotImplementedException();

        internal List<double> Sacar(List<double> saldos)
        {
            throw new NotImplementedException();
        }

        internal Produto CadastrarProduto()
        {
            throw new NotImplementedException();
        }

        internal void ListarProdutos(List<Produto> produtos, double valorTotal)
        {
            throw new NotImplementedException();
        }


        public double? Depositando()
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
            catch (Exception) { throw;  }
        }

        public List<double>? Sacando(List<double> saldo)
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

        public Produto? CadastrandoProduto()
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

        public void ListandoProdutos(List<Produto> produtos, double valorTotal)
        {
            try
            {
                int i = 0;

                Console.WriteLine("\nLista de produtos: ");
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"{i + 1}° produto:\nNome: {produto.Nome}\nPreço: {produto.Preco}\n");
                    i++;
                }
                Console.WriteLine($"Valor total da compra: {valorTotal}");
            }
            catch (Exception) { throw; }
        }
    }
}
