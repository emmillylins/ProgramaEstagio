using Biblioteca.Classes;
using Biblioteca.Validacao;
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

        // metodo para inserir numero na lista
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
        // metodo para mostrar o numero na lista e seus tipos 
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


        }
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

        #region METODOS PARA O DESAFIOS POO
        
        public void AdicionarEpisodio()
        {



        }


        public static void ExibirDetalhes(Podcasts podcats1)
        {
            try
            {
                Console.WriteLine(podcats1.NomePodcast, podcats1.ApresentadorPodcast);

                var episodios =  podcats1.Episodio.OrderBy(podcats1 = )





            }catch (Exception) { throw; }
          

           
        }



        #endregion
    }
}