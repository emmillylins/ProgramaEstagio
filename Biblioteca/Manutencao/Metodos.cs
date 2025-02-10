using Biblioteca.Classes;
using Biblioteca.Validacao;
using System.Globalization;


namespace Biblioteca.Manutencao
{

    #region Metodos
    public class Metodos
    {
        //O primeiro vai ser sempre o maior e o segundo vai ser sempre o menor.

        #region retonar numero maior
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
        #endregion

        #region Metodo Mostrar Usuario
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
        #endregion

        #region Metodo Cadastrar Usuario
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
        #endregion

        #region Metodo Depositar
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
        #endregion

        #region Metodo Sacar
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
        #endregion

        #region Metodo Cadastrar Produto
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
        #endregion

        #region Metodo calcular Valor total
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
        #endregion

        #region Metodo exibir lista de produtos
        public void ExibirListaProdutos(List<Produto> produtos)
        {
            foreach (Produto produto in produtos)
            {
                Console.WriteLine($"\n Nome do Produto: {produto.Nome}\nPreço: {produto.Preco}");
            }
        }
        #endregion

        #region Metodo Cadastrar aluno

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
        #endregion

        #region Metodo exibir alunos

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
        #endregion

        #region Metodo Buscar alunos por ID

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
        #endregion

        #region metodo para inserir numero na lista
        public void InserirNumeroLista(List<int> listaInteiros)
        {
            try
            {
                Console.WriteLine("\nInsira um número na lista: ");
                if (!int.TryParse(Console.ReadLine(), out int numeroInserido))
                {
                    Console.WriteLine("\nInsira apenas valores numéricos");
                    return;
                }
                listaInteiros.Add(numeroInserido);
                Console.WriteLine("\nNúmero inserido na lista!");
            }
            catch (Exception ex) { throw; }

        }
        #endregion

        #region metodo para mostrar o numero na lista e seus tipos 
        public void MostrarNumerosLista(List<int> listaInteiros)
        {
            try
            {
                if (listaInteiros.Count == 0)
                {
                    Console.WriteLine("\nNenhum número inserido na lista!");
                }
                else
                {

                    foreach (int numero in listaInteiros)
                    {

                        String sinal;
                        if (numero < 0)
                        {
                            sinal = "negativo";
                        }
                        else if (numero > 0)
                        {
                            sinal = "positivo";
                        }
                        else
                        {
                            sinal = "Zero";
                        }
                        Console.WriteLine($"{numero}, {sinal}");
                    }
                }
            }
            catch (Exception ex) { throw; }
        }

        #endregion

        #region metodo validar senha
        public void ValidarSenha()
        {
            try
            {
                var metodos = new Validacoes();

                Console.WriteLine("Insira sua senha: ");
                String? senha = Console.ReadLine();

                if (metodos.AutenticarSenha(senha))
                {
                    Console.WriteLine("Senha Cadastrada com sucesso com sucesso!");
                }
                else
                {

                    Console.WriteLine("\nSenha inválida.");
                    Console.WriteLine("\nA senha deve ter:");
                    Console.WriteLine("-Pelo menos 8 caracteres");
                    Console.WriteLine("-Pelo menos uma letra maiúscula");
                    Console.WriteLine("-Pelo menosuma letra minúscula");
                    Console.WriteLine("-Pelo menos uma caractere especial");
                }

            }
            catch (Exception ex) { throw; }

        }
        #endregion

        #region metodos calculadora
        public double? Soma()
        {
            try
            {
                Console.WriteLine("Insira o primeiro numero para a soma: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var primeiroNumero))
                {
                    Console.WriteLine("Insira apenas valores númericos");
                    return null;
                }
                Console.WriteLine("Insira o segundo numero para a soma: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var segundoNumero))
                {
                    Console.WriteLine("Insira apenas valores númericos");
                    return null;
                }
                var soma = primeiroNumero + segundoNumero;

                Console.WriteLine($"O resultado da operação é: {soma}");
                return soma;
            }
            catch (Exception ex) { throw; }
        }

        public double? Subtração()
        {
            try
            {
                Console.WriteLine("Insira o primeiro numero para a subtração: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var primeiroNumero))
                {
                    Console.WriteLine("Insira apenas valores númericos");
                    return null;
                }
                Console.WriteLine("Insira o segundo numero para a subtração: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var segundoNumero))
                {
                    Console.WriteLine("Insira apenas valores númericos");
                    return null;
                }
                var subtracao = primeiroNumero - segundoNumero;

                Console.WriteLine($"O resultado da operação é: {subtracao}");
                return subtracao;

            }
            catch (Exception ex) { throw; }
        }

        public double? Divisao()
        {
            try
            {

                Console.WriteLine("Insira o dividendo para a divisão: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var primeiroNumero))
                {
                    Console.WriteLine("Insira apenas valores númericos");
                    return null;
                }
                Console.WriteLine("Insira o divisor para a divisão: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var segundoNumero))
                {
                    Console.WriteLine("Insira apenas valores númericos");
                    return null;
                }
                var divisao = primeiroNumero / segundoNumero;

                Console.WriteLine($"O resultado da operação é: {divisao}");
                return divisao;
            }
            catch (Exception e) { throw; }
        }
        public double? Multiplicacao()
        {
            try
            {


                Console.WriteLine("Insira o primeiro numero para a multiplicação: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var primeiroNumero))
                {
                    Console.WriteLine("Insira apenas valores númericos");
                    return null;
                }
                Console.WriteLine("Insira o segundo numero para a multiplicação: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var segundoNumero))
                {
                    Console.WriteLine("Insira apenas valores númericos");
                    return null;
                }
                var multiplicacao = primeiroNumero * segundoNumero;

                Console.WriteLine($"O resultado da operação é: {multiplicacao}");
                return multiplicacao;
            }
            catch (Exception e) { throw; }
        }



        public double? Potenciacao()
        {
            try
            {
                Console.WriteLine("Insira a base: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var primeiroNumero))
                {
                    Console.WriteLine("Insira apenas valores númericos");
                    return null;
                }
                Console.WriteLine("Insira o expoente: ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var segundoNumero))
                {
                    Console.WriteLine("Insira apenas valores númericos");
                    return null;
                }
                var potenciacao = Math.Pow(primeiroNumero, segundoNumero);

                Console.WriteLine($"O resultado da operação é: {potenciacao}");
                return potenciacao;
            }
            catch (Exception) { throw; }

        }
        public double? RaizQuadradada()
        {
            try
            {
                Console.WriteLine("Insira um numero para realizar a operação ");

                if (!double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out var primeiroNumero))
                {
                    Console.WriteLine("Insira apenas valores númericos");
                    return null;
                }

                var resultadoRaizQuadrada = Math.Sqrt(primeiroNumero);

                Console.WriteLine($"O resultado da operação é: {resultadoRaizQuadrada}");
                return resultadoRaizQuadrada;
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region metodo tabuada
        public void Tabuada()
        {
            try
            {

                if (!int.TryParse(Console.ReadLine(), out int numeroTabuada) || numeroTabuada > 10 || numeroTabuada <= 0)
                {
                    Console.WriteLine("\nInsira apenas valores numéricos e dentro do escolpo solicitado!!");
                    return;
                }

                for (int i = 1; i < 11; i++)
                {

                    Console.WriteLine($"{numeroTabuada}  X  {i} = {numeroTabuada * i}");
                }
            }
            catch (Exception) { throw; }

            #endregion
        }
        #region metodo validar entada usuario
        public void ValidarEntradaUsuario()
        {
            var metodos = new Validacoes();
            var valida = new Metodos();
            try
            {
                Console.WriteLine("Insira tentativa! ");
                String? tentativa = Console.ReadLine();

                if (metodos.limitarLetras(tentativa))
                {
                    Console.WriteLine("Insira apenas uma palavra por vez!!");
                }
                else
                {
                    Console.WriteLine("Boaaa");
                }

            }
            catch (Exception) { throw; }


        }
        #endregion

        #region Validar CPF/CNPJ
        public void ValidarCpf(String cpf)
        {


            try
            {

                int[] multiplicadorPrimerioDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2, };
                int[] multiplicadorSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, };
                String noveDigitosCpf;
                String digito;
                int resto = 0;
                int soma = 0;
                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");
                if (cpf.Distinct().Count() == 1)
                {

                    throw new Exception("Insira apenas CPF válidos");
                }


                noveDigitosCpf = cpf.Substring(0, 9);


                if (cpf.Length != 11)
                {
                    throw new Exception("Insira um CPF válido!!");
                }


                for (int i = 0; i < 9; i++)
                {

                    soma += (int.Parse(noveDigitosCpf[i].ToString())) * multiplicadorPrimerioDigito[i];
                }

                resto = soma % 11;

                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }

                digito = resto.ToString();
                noveDigitosCpf = noveDigitosCpf + digito;

                soma = 0;
                for (int i = 0; i < 10; i++)
                {

                    soma += int.Parse(noveDigitosCpf[i].ToString()) * multiplicadorSegundoDigito[i];
                }

                resto = soma % 11;

                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }

                noveDigitosCpf = noveDigitosCpf + resto;


                if (cpf == noveDigitosCpf)
                {

                    Console.WriteLine("O CPF inserido é válido");
                }
                else
                {
                    Console.WriteLine("O CPF inserido é inválido");
                }

            }
            catch (Exception) { throw; }
        }

        public void ValidarCnpj(string cnpj)
        {


            int[] multiplicadorPrimerioDigito = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadorSegundoDigito = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            String tempcnpj;
            String digito;
            int resto = 0;
            int soma = 0;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "");


            if (cnpj.Distinct().Count() == 1)
            {

                throw new Exception("Insira um CNPJ válido!!");
            }


            tempcnpj = cnpj.Substring(0, 12);
            soma = 0;


            if (cnpj.Length != 14)
            {
                throw new Exception("Insira um CNPJ válido!!");
            }


            for (int i = 0; i < 12; i++)
            {

                soma += (int.Parse(tempcnpj[i].ToString())) * multiplicadorPrimerioDigito[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempcnpj = tempcnpj + digito;

            soma = 0;
            for (int i = 0; i < 13; i++)
            {

                soma += int.Parse(tempcnpj[i].ToString()) * multiplicadorSegundoDigito[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            tempcnpj = tempcnpj + resto;


            if (cnpj == tempcnpj)
            {

                Console.WriteLine("O inserido CNPJ é válido");
            }
            else
            {
                Console.WriteLine("O inserido CNPJ é inválido");
            }


        }
        #endregion

        #region METODOS PARA O DESAFIOS POO

        #region Adicionar Episodio 
        public void AdicionarEpisodio(Podcasts podcasts)
        {
            try
            {


                while (true)
                {
                    Console.WriteLine("\nDigite o número do episódio (ou 0 para sair):");

                    if (!int.TryParse(Console.ReadLine(), out int numeroEpisodio) || numeroEpisodio < 0 || podcasts.ListaEpisodios.Any(podcasts => podcasts.Numero == numeroEpisodio))
                    {
                        Console.WriteLine("Entrada Inválida. Tente novamente!");
                        continue;
                    }


                    if (numeroEpisodio == 0)
                    {
                        break;
                    }

                    Console.WriteLine("Digite o título do episódio:");
                    string tituloEpisodio = Console.ReadLine()!;

                    if (string.IsNullOrEmpty(tituloEpisodio))
                    {
                        Console.WriteLine("O titulo não pode ser nulo! ");
                        break;
                    }

                    Console.WriteLine("Digite a duração do episódio (em minutos):");


                    if (!double.TryParse(Console.ReadLine(),CultureInfo.InvariantCulture, out double duracaoEpisodio) || duracaoEpisodio < 0)
                    {
                        Console.WriteLine("Duração inválida. Tente novamente.");
                        continue;
                    }

                    Episodios novoEpisodio = new Episodios(numeroEpisodio, tituloEpisodio, duracaoEpisodio);

                    int contador = 1;
                    while (true)
                    {
                        Console.WriteLine("\nDeseja inserir convidados?");
                        Console.WriteLine("1 - SIM\n2 - NÃO");

                        if (!int.TryParse(Console.ReadLine(), out int opcao) || opcao < 1 || opcao > 2)
                        {
                            Console.WriteLine("Opção inválida! Digite 1 ou 2.");
                            continue;
                        }

                        if (opcao == 2)
                        {
                            break;
                        }


                        while (true)
                        {
                            Console.Write("\nCódigo do convidado (ou 0 para parar): ");

                            if (!int.TryParse(Console.ReadLine(), out int codigo))
                            {
                                Console.WriteLine("Código inválido. Tente novamente.");
                                continue;
                            }

                            if (codigo == 0)
                            {
                                break;
                            }

                            Console.Write("Nome do convidado: ");
                            string nomeConvidado = Console.ReadLine()!;
                            if (string.IsNullOrEmpty(nomeConvidado))
                            {
                                Console.WriteLine("O nome do convidado não pode ser nulo! ");
                                break;
                            }
                            else
                            {

                                novoEpisodio.AdicionarConvidado(new Convidado(contador, nomeConvidado));
                                contador++;
                            }

                            break;
                        }


                       
                    }
                    podcasts.AdicionarEpisodio(novoEpisodio);
                    Console.WriteLine("Episódio adicionado com sucesso!");
                }
            }
            catch (Exception ex) { throw; }
            }
        #endregion

        #region Exibir Detalhes
        public void ExibirDetalhes(Podcasts podcasts)
        {
            try
            {
                Console.WriteLine($"Podcast: {podcasts.NomePodcast}");
                Console.WriteLine($"Apresentador: {podcasts.ApresentadorPodcast}");
                Console.WriteLine("Episódios:");


                foreach (var episodio in podcasts.ListaEpisodios)
                {
                    Console.WriteLine(episodio.Resumo);
                }

                Console.WriteLine($"Total de Episódios: {podcasts.ListaEpisodios.Count()}");

            }
            catch (Exception) { throw; }



        }
        #endregion



        #endregion

        #endregion

    }
}