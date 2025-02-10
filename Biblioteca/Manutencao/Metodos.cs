using Biblioteca.Classes;
using System.ComponentModel.Design;
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

        #region Calculadora Avançada
        public void Soma()
        {
            // Lista para armazenar os números inseridos
            List<double> numeros = [];

            // Solicitando os números e armazenando na lista
            for (int i = 1; i < 3; i++)
            {

                Console.WriteLine($"\nInforme o {i}º número:");
                Console.Write("Número: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double numeroInserido))
                {
                    Console.WriteLine("Informe um valor válido");
                }
                else
                {
                    numeros.Add(numeroInserido);
                }
            }

            double soma = numeros.Sum();
            Console.WriteLine($"{numeros[0]} + {numeros[1]} = {soma}");
        }

        public void Subtracao()
        {
            // Lista para armazenar os números inseridos
            List<double> numeros = [];

            // Solicitando os números e armazenando na lista
            for (int i = 1; i < 3; i++)
            {

                Console.WriteLine($"\nInforme o {i}º número:");
                Console.Write("Número: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double numeroInserido))
                {
                    Console.WriteLine("Informe um valor válido");
                }
                else
                {
                    numeros.Add(numeroInserido);
                }
            }

            double subtracao = numeros[0] - (numeros[1]);
            Console.WriteLine($"{numeros[0]} - {numeros[1]} = {subtracao}");
        }

        public void Multiplicacao()
        {
            // Lista para armazenar os números inseridos
            List<double> numeros = [];

            // Solicitando os números e armazenando na lista
            for (int i = 1; i < 3; i++)
            {

                Console.WriteLine($"\nInforme o {i}º número:");
                Console.Write("Número: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double numeroInserido))
                {
                    Console.WriteLine("Informe um valor válido");
                }
                else
                {
                    numeros.Add(numeroInserido);
                }
            }

            double multiplicacao = numeros[0] * (numeros[1]);
            Console.WriteLine($"{numeros[0]} x {numeros[1]} = {multiplicacao}");
        }

        public void Divisao()
        {
            // Lista para armazenar os números inseridos
            List<double> numeros = [];

            // Solicitando os números e armazenando na lista
            for (int i = 1; i < 3; i++)
            {

                Console.WriteLine($"\nInforme o {i}º número:");
                Console.Write("Número: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double numeroInserido))
                {
                    Console.WriteLine("Informe um valor válido");
                }
                else
                {
                    numeros.Add(numeroInserido);
                }
            }

            double divisao = numeros[0] / numeros[1];
            Console.WriteLine($"{numeros[0]} / {numeros[1]} = {divisao}");
        }

        public void Potenciacao()
        {
            // Lista para armazenar os números inseridos
            List<double> numeros = [];

            // Solicitando os números e armazenando na lista
            for (int i = 1; i < 3; i++)
            {

                Console.WriteLine($"\nInforme o {i}º número:");
                Console.Write("Número: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double numeroInserido))
                {
                    Console.WriteLine("Informe um valor válido");
                }
                else
                {
                    numeros.Add(numeroInserido);
                }
            }

            double potenciacao = Math.Pow(numeros[0], numeros[1]);
            Console.WriteLine($"{numeros[0]} ^ {numeros[1]} = {potenciacao}");
        }

        public void Raiz()
        {
            Console.WriteLine($"\nInforme o número:");
            Console.Write("Número: ");

            if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double numeroInserido))
            {
                Console.WriteLine("Informe um valor válido");
            }
            else
            {
                double raizQuadrada = Math.Sqrt(numeroInserido);
                Console.WriteLine($"Raiz quadrada de {numeroInserido} = {raizQuadrada}");
            }
        }

#endregion

        #region Método Questão 8
        public void ExibeTabuada()
        {
            try
            {
                // Solicitando o número ao usuário
                Console.WriteLine("Informe o número desejado.");
                Console.Write("Número: ");

                // Convertendo o número para inteiro
                if (!int.TryParse(Console.ReadLine(), out var numeroInserido) || numeroInserido > 10 || numeroInserido < 1)
                {
                    Console.WriteLine("Valor informado inválido! Insira um número inteiro de 1 a 10.");
                }
                else
                {
                    // Exibindo a tabuada do número escolhido
                    Console.WriteLine($"Tabuada do {numeroInserido}");
                    for (int i = 1; i < 11; i++)
                    {
                        Console.WriteLine($"{i} x {numeroInserido} = {i * numeroInserido}");
                    }
                }
            }
            catch (Exception) { throw; }
        }

        #endregion

        #region Métodos do Podcast

        #region Adicionar Episódio
        public void AdicionarEpisodio(Podcast podcast)
        {
            try
            {
                Console.WriteLine("\nAdicionar Episódio.");

                while (true)
                {
                    Console.WriteLine("\nInfome o número do episódio:");
                    Console.Write("Número: ");

                    if (!int.TryParse(Console.ReadLine(), out var numeroInserido) || numeroInserido < 1)
                    {
                        Console.WriteLine("\nValor inserido inválido!");
                    }
                    else
                    {
                        if (podcast.Episodios.Any(e => e.Numero == numeroInserido))
                        {
                            Console.WriteLine("\nNúmero do episódio já inserido!");
                        }
                        else
                        {
                            while (true)
                            {
                                // Solicitando título
                                Console.WriteLine($"\nInforme o título do episódio #{numeroInserido}");
                                Console.Write("Título: ");

                                string? tituloInserido = Console.ReadLine();

                                if (!string.IsNullOrEmpty(tituloInserido))
                                {
                                    while (true)
                                    {
                                        // Solicitando resumo
                                        Console.WriteLine("\nInforme o resumo do episódio.");
                                        Console.Write("Resumo: ");

                                        string? resumoInsrido = Console.ReadLine();

                                        if (!string.IsNullOrEmpty(resumoInsrido))
                                        {
                                            while (true)
                                            {
                                                // Solicitando duracao minutos
                                                Console.WriteLine("\nInforme a duração do episódio em minutos: ");
                                                Console.Write("Duração: ");

                                                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture,out var duracaoInserida))
                                                {
                                                    Console.WriteLine("\nValor inserido para a duração inválido!");
                                                }
                                                else
                                                {
                                                    Episodio episodio = new(numeroInserido, tituloInserido, resumoInsrido, duracaoInserida);

                                                    // Contador para Id do convidado
                                                    int contador = 1;

                                                    while (true)
                                                    {
                                                        Console.WriteLine("\nDeseja adicionar convidado? \nPara SIM digite: s \nPara NÃO digite: n");
                                                        Console.Write("Resposta: ");

                                                        string opcaoInserida = Console.ReadLine().ToLower();

                                                        switch (opcaoInserida)
                                                        {
                                                            case "s":
                                                                AdicionarConvidados(episodio, contador);
                                                                contador++;
                                                                break;
                                                            case "n":
                                                                podcast.Episodios.Add(episodio);
                                                                return;
                                                            default:
                                                                Console.WriteLine("Opção inserida inválida!");
                                                                break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("O resumo não pode ser nulo!");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nO título não pode ser nulo!");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Exibir Detalhes
        public void ExibirDetalhes(Podcast podcast)
        {
            try
            {
                Console.WriteLine($"\nPodcast: {podcast.Nome}, apresentado por: {podcast.Apresentador}");

                // Verificação da quantidade de epsodios do podcast
                if (podcast.TotalEpsodios == 0)
                {
                    Console.WriteLine("Esse podcast ainda não possui episódios!");
                }
                else
                {
                    foreach (var ep in podcast.Episodios.OrderBy(e => e.Numero))
                    {
                        if (ep.Convidados.Count == 0)
                        {
                            Console.WriteLine($"\nResumo: {ep.Resumo}. \nEpisódio: #{ep.Numero}, Título: {ep.Titulo}, Duração: {ep.DuracaoMinutos}min");
                            Console.WriteLine("O episódio não possui convidados!");
                        }
                        else
                        {
                            Console.WriteLine($"\nResumo: {ep.Resumo}. \nEpisódio: #{ep.Numero}, Título: {ep.Titulo}, Duração: {ep.DuracaoMinutos}min");
                            Console.WriteLine("Convidados:");

                            //Exibindo lista de convidados e ordenando pelo código
                            foreach (var convidado in ep.Convidados.OrderBy(convidado => convidado.Codigo))
                            {
                                Console.WriteLine($"{convidado.Codigo}: {convidado.Nome}");
                            }
                        }
                    }
                    
                    Console.WriteLine($"\nTotal de Episódios: {podcast.TotalEpsodios}");
                    Console.WriteLine($"Duração total do {podcast.Nome}: {podcast.DuracaoTotal} minutos.");
                }
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Adicionar Convidados
        public void AdicionarConvidados(Episodio episodio, int contador)
        {
            try
            {
                Console.WriteLine("\nInforme o nome do convidado");
                Console.Write("Nome: ");

                string nomeInserido = Console.ReadLine();

                if (!string.IsNullOrEmpty(nomeInserido))
                {
                    if (episodio.Convidados.Any(c => c.Nome.Equals(nomeInserido, StringComparison.OrdinalIgnoreCase)))
                        Console.WriteLine("O convidado já foi adicionado!");
                    else
                    {
                        // Estânciando um novo convidado
                        Convidado convidado = new(contador,nomeInserido);
                        // Adicionando o convidado criado a lista de convidados
                        episodio.Convidados.Add(convidado);

                        Console.WriteLine($"\nConvidado, {nomeInserido}, adicionado com sucesso!");
                    }
                }
                else
                {
                    Console.WriteLine("O nome do convidado não pode ser nulo!");
                    return;
                }
            }
            catch (Exception) { throw; }
        }
        #endregion

        #endregion
    }
}
