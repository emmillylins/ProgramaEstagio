using Biblioteca.Classes;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;


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
        public Produto CadastrarProduto()
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

        public Aluno CadastrarAluno()
        {
            try
            {
                Aluno aluno = new();
                Console.Clear();

                Console.Write("Digite o nome do aluno: ");
                aluno.Nome = Console.ReadLine();
                if(string.IsNullOrEmpty(aluno.Nome))
                {
                    Console.WriteLine("O aluno precisa ter um nome");
                    return null;
                }

                for(var i = 1; i < 5; i++)
                {
                    Console.WriteLine($"Digite a {i}° nota");
                    if(!double.TryParse(Console.ReadLine()!, CultureInfo.InvariantCulture, out var nota) || nota < 0 || nota > 10)
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
            foreach(Aluno aluno in listaAlunos)
            {
                Console.WriteLine($"Id do aluno: {aluno.Id}");
                Console.WriteLine($"Nome do aluno: {aluno.Nome}");
                Console.WriteLine("\nNotas: ");
                foreach(double nota in aluno.Notas)
                {
                    Console.WriteLine($"Nota: {nota}");
                }

                var media = aluno.Notas.Average();
                Console.WriteLine($"Media: {media}");

                switch(media)
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
            if(!int.TryParse(Console.ReadLine(), out var id) || id <= 0)
            {
                Console.WriteLine("Insira um id válido");
                return;
            }

            var aluno = alunos.Find(aluno => aluno.Id == id);
            if(aluno == null)
            {
                Console.WriteLine("O aluno não foi encontrado.");
                return;
            }

            Console.WriteLine($"Aluno: {aluno.Nome}");
            var i = 1;
            foreach(double nota in aluno.Notas) 
            {
                Console.WriteLine($"{i}° Nota: {nota}");
                i++;
            }

            var media = aluno.Notas.Average();
            Console.WriteLine($"Média: {media}");
            switch(media)
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
    
        public (int?, int?) PegaDoisNumeros()
        {
            int num1, num2;
            while (true) 
            {
                Console.Write("\nDigite o primeiro número: ");
                if(!int.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Digite um valor numérico válido");
                    continue;
                }
                Console.Write("Digite o segundo número: ");
                if(!int.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Digite um valor numérico válido");
                    continue;
                }
                break;
            }

            return (num1, num2);
        }

        public void Potencialização()
        {
            int num1, num2;
            while(true) 
            {
                Console.Write("Digite o número a ser elevado / numero base: ");
                if(!int.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Digite um valor numérico válido");
                    continue;
                }

                Console.Write("Digite a potência: ");
                if(!int.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Digite um valor numérico válido");
                    continue;
                }

                break;
            }

            var resultado = Math.Pow(num1, num2);

            Console.WriteLine($"O número {num1} elevado a {num2}° é {resultado}");            
        }

        public void Radiciação()
        {
            int num1, num2;
            while(true)
            {
                Console.Write("Digite o número / radical: ");
                if(!int.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Digite um valor numérico válido");
                    continue;
                }

                Console.Write("Digite o indice: ");
                if(!int.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Digite um valor numérico válido");
                    continue;
                }

                break;
            }

            var resultado = Math.Sqrt(num1 / num2);

            Console.WriteLine($"O número {num1} elevado a {num2}° é {resultado}");            
        }

        public int CalculaDigitoVerificador(int peso, string cadeiaDeCaracteres)
        {
            try
            {
                List<int> resultado = []; // lista para armazenar a multiplicação do dígito pelo peso.
            
                for(int i = 0; i < cadeiaDeCaracteres.Length; i++) 
                {
                    var numeroInteiro = int.Parse(cadeiaDeCaracteres[i].ToString());
                    var resultadoMultiplicacaoDigitoPeso = numeroInteiro * peso;
                    resultado.Add(resultadoMultiplicacaoDigitoPeso);
                    peso--;
                }      

                var resto = resultado.Sum() % 11; 
                
                return (resto < 2) ? 0 : 11 - resto;
            }
            catch (Exception) { throw; }
            
        }

        #region Métodos referentes ao desafio da alura de orientação a objetos
        public void AdicionarEpisodio(Podcast podcast)
        {
            try
            {
                Console.Clear();
                var condicao = true;

                string tituloEpisodio = "";
                int duracaoEpisodio = 0;
                string resumoEpisodio = "";

                while(condicao) 
                {
                    Console.WriteLine($"Adicione um Episodio ao podcast {podcast.Nome}: ");
                    
                    Console.Write($"\nAdicione um título ao episódio {podcast.Nome}: ");
                    tituloEpisodio = Console.ReadLine()!;
                    if(tituloEpisodio == null || tituloEpisodio.Length < 3)
                    {
                        Console.WriteLine("É necessario cadastrar um titulo com mais de 3 caracteres");
                        continue;
                    }
                    
                    Console.Write("Qual a duração do episódio que deseja adicionar - (minutos): ");
                    if(!int.TryParse(Console.ReadLine(), out duracaoEpisodio) || duracaoEpisodio <= 0)
                    {
                        Console.WriteLine("A duração precisa ser um valor numérico maior que zero");
                        continue;
                    }

                    Console.Write($"Adicione um resumo ao episódio {podcast.Nome}: ");
                    resumoEpisodio = Console.ReadLine()!;

                    condicao = false;
                }

                Episodio episodio = new(tituloEpisodio!, duracaoEpisodio, resumoEpisodio);

                podcast.Episodios.Add(episodio);

                Console.WriteLine("Deseja adicionar um convidado ao podcast? (Sim - Não)");
                var resposta = Console.ReadLine()!;

                if(resposta.ToLower() == "sim")
                {
                    AdicionaConvidado(episodio);
                }

                Console.WriteLine($"Episódio {episodio.Titulo} adicionado ao Podcast {podcast.Nome}");        
            }
            catch (Exception) { throw; }
            
        }

        public void ExibirDetalhes(Podcast podcast) 
        {
            Console.WriteLine($"Podcast: {podcast.Nome}. Apresentador: {podcast.Apresentador}");
            Console.WriteLine($"Total de episódios: {podcast.Episodios.Count}");

            var listEpisodiosOrdenada = podcast.Episodios.OrderBy(e => e.Numero).ToList();
            foreach(Episodio episodio in listEpisodiosOrdenada) 
            {
                Console.WriteLine($"{episodio.Titulo}");
                Console.WriteLine($"Ficha técnica - Resumo: {episodio.Resumo} - Número: {episodio.Numero} - Título: {episodio.Titulo} - Duração: {episodio.Duracao}");
                foreach(Convidado convidado in episodio.Convidados)
                {
                    Console.WriteLine($"Convidado: {convidado.Nome} - Código: {convidado.Codigo}");
                }
            }            
        }

        public void AdicionaConvidado(Episodio episodio)
        {
            try
            {
                int quantidadeConvidado = 0;
                var condicao = true;
                if(episodio == null)
                {
                    throw new Exception("Episódio não foi encontrado");
                }

                Console.Write("Digite a quantidade de convidados que voce deseja adicionar: ");
                while(condicao) 
                {
                    if (!int.TryParse(Console.ReadLine(), out quantidadeConvidado) || quantidadeConvidado <= 0)
                    {
                        Console.WriteLine("Digite um valor numérico válido e maior que zero para a quantidade de convidados.");
                        continue;
                    }

                    condicao = false;

                }

                for (int i = 0; i < quantidadeConvidado; i++)
                {
                    Console.Write("Digite o nome do convidado: ");
                    var convdidadoNome =  Console.ReadLine()!;

                    Convidado convidado = new(convdidadoNome);

                    episodio.Convidados.Add(convidado);

                    Console.WriteLine($"O convidado {convidado.Nome} foi adicionado ao episodio {episodio.Titulo}");
                }

            } catch { throw; }
        }



        #endregion
    }
}
