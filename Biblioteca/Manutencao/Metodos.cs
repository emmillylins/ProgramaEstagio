using Biblioteca.Classes;
using System.Globalization;
using System.Text.RegularExpressions;


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

        //QUESTÃO 1: Como posso criar um jogo simples de adivinhação em C# onde o usuário tenha 5 tentativas para adivinhar um número secreto entre 1 e 100?

        //Regras:
        //Caso o palpite não seja um valor válido, não deve ser contado como tentativa
        //Se o palpite for maior que o número secreto: mostre uma mensagem personalizada;
        //Se o palpite for menor que o número secreto: mostre uma mensagem personalizada;
        public static int CriarNumeroSecreto()
        {
            //Permite gerar número aleatório no intervalo especificado.
            Random numeroRandomico = new Random();
            return numeroRandomico.Next(1, 101); //Número entre 1 e 100
        }

        // Método para verificar o palpite do jogador
        public static bool VerificarPalpite(int palpite, int numeroSecreto)
        {
            //compara se o palpite é maior que o número secreto
            if (palpite > numeroSecreto)
            {
                Console.WriteLine("O seu palpite é muito alto! Tente um número menor.");
                return false;
            }
            //compara se o palpite é maior que o número secreto
            else if (palpite < numeroSecreto)
            {
                Console.WriteLine("O seu palpite é muito baixo! Tente um número maior.");
                return false;
            }
            else
            {
                Console.WriteLine("Parabéns! Você acertou o número secreto!");
                return true;
            }
        }


        //QUESTÃO 2: Crie um programa que leia uma 
        //lista de números inteiros do usuário e classifique-os em positivos, negativos e zeros.

        //Método para ler e classificar os números digitados pelos usuários
        //serao identificados os números digitados e armazenados em suas respectivas listas
        public static void lerListaNumerosInteiros(
            List<int> positivos,
            List<int> negativos,
            List<int> zeros)
        {
            try
            {
                while (true)
                {
                    Console.Write("Digite um número (ou 'fim' para terminar): ");
                    string numeroDigitadoPeloUsuario = Console.ReadLine();

                    //Se o usuário digitar "fim", saímos do loop
                    if (numeroDigitadoPeloUsuario.ToLower() == "fim")
                    {
                        break;
                    }
                    //Tenta converter a entrada para um número inteiro
                    bool validacao = int.TryParse(numeroDigitadoPeloUsuario, out int numero);

                    if (validacao)
                    {
                        //Classifica o número conforme a sua natureza
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
                    else
                    {
                        //Caso o número seja inválido
                        Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
                    }
                }
            }
            catch (Exception) { throw; }
        }


        //QUESTÃO 3:  Validação de Senha:
        //Implemente um sistema de validação de senha que exige pelo menos 8 caracteres,
        //pelo menos uma letra maiúscula, uma letra minúscula e um caractere especial.
        //O programa deve informar se a senha fornecida atende aos critérios.
        //Regras: Utilize método para validar a senha inserida.
        //// Método que valida a senha com os critérios especificados
        public static bool ValidarSenha(string senha)
        {
            // Expressão regular para validar a senha
            // A senha deve:
            // - Ter no mínimo 8 caracteres
            // - Ter pelo menos uma letra maiúscula
            // - Ter pelo menos uma letra minúscula
            // - Ter pelo menos um caractere especial
            string padraoSenha = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{8,}$";

            // Usa regex para verificar se a senha atende ao padrão
            Regex regex = new Regex(padraoSenha);

            return regex.IsMatch(senha); 
            //o método IsMatch retorna um valor Booleano e é necessário informar,
            //neste caso, apenas o texto e a sintaxe da expressão regular
        }
        //NÃO FINALIZADA
        //Questão 4: Calculadora com Operações Avançadas:
        //Desenvolva uma calculadora que permita ao usuário realizar operações básicas(adição, subtração,
        // multiplicação, divisão) e operações avançadas(potenciação, raiz quadrada) com base em escolhas feitas
        //usando um menu e estruturas de controle(switch/case).

        static void CalculadoraAvancada()
        {

            try
            {
                while (true)
            {
                int numero;

                Console.Write("Digite um número entre 1 e 10 para gerar a tabuada: ");
                string input = Console.ReadLine();

                try
                {
                    // Tenta converter o input para um número inteiro
                    if (!int.TryParse(input, out numero))
                    {
                        throw new FormatException("Entrada inválida! Por favor, insira um número inteiro.");
                    }

                    // Verifica se o número está dentro do intervalo permitido
                    if (numero < 1 || numero > 10)
                    {
                        throw new ArgumentOutOfRangeException("O número deve estar entre 1 e 10.");
                    }

                    // Gerar e exibir a tabuada do número
                    Console.WriteLine($"Tabuada do {numero}:");
                    for (int i = 1; i <= 10; i++)
                    {
                        Console.WriteLine($"{numero} x {i} = {numero * i}");
                    }

                    // Pergunta se o usuário deseja gerar outra tabuada
                    Console.Write("Deseja gerar outra tabuada? (s/n): ");
                    string resposta = Console.ReadLine().ToLower();

                    if (resposta != "s")
                    {
                        Console.WriteLine("Programa encerrado.");
                        break;
                    }
                }
                catch (FormatException ex)
                {
                    // Captura exceção de formato e exibe mensagem
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    // Captura exceção caso o número não esteja no intervalo permitido
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    // Captura qualquer outra exceção não esperada
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                }
            }
            }catch (Exception) { throw; }
            
        }


        //NÃO FINALIZADA
        //QUESTÃO 5: Validação de CPF
        //Crie um programa que solicita ao usuário um CPF e valida se ele está no formato correto(11 dígitos numéricos). O programa deve permitir que o usuário tente novamente caso o formato esteja incorreto.Utilize tratamento de exceções para garantir que o CPF contenha apenas números e tenha o tamanho correto.

        //Regras de Validação de CPF
        //    O CPF deve ter 11 dígitos.
        //Os dois últimos dígitos são verificadores, calculados com base nos 9 primeiros dígitos. 
        //O cálculo dos dígitos verificadores é feito da seguinte forma: 

        //Para o primeiro dígito verificador: 
        //Multiplica-se cada um dos 9 primeiros dígitos por um peso que começa em 10 e diminui até 2. 
        //Soma-se os resultados.
        //O dígito verificador é o resto da divisão dessa soma por 11. Se o resto for menor que 2, o dígito é 0;
        //caso contrário, é 11 menos o resto.

        //Para o segundo dígito verificador: 
        //Multiplica-se cada um dos 10 primeiros dígitos(9 originais + primeiro dígito verificador) por um peso que começa em 11 e diminui até 2. 
        //Soma-se os resultados.
        //O dígito verificador é o resto da divisão dessa soma por 11. 
        //Se o resto for menor que 2, o dígito é 0; caso contrário, é 11 menos o resto.
        // Método para validar o formato do CPF

        public static bool ValidarCpfFormatado(string cpf)
        {
            try
            {
                //Verifica se o CPF contém exatamente 11 dígitos
                if (cpf.Length != 11) //length para o tamanho 
                {
                    Console.WriteLine("O CPF deve ter 11 dígitos.");
                    return false;
                }

                //Tenta converter o CPF para números, e verifica se é composto apenas por números
                if (!long.TryParse(cpf, out _))
                {
                    Console.WriteLine("O CPF deve conter apenas números.");
                    return false;
                }

                //Chama o método para validar os dois dígitos verificadores
                return VerificarDigitosVerificadores(cpf);
            }
            catch (Exception) { throw; }

        }

        //Método para calcular e verificar os dois dígitos verificadores
        public static bool VerificarDigitosVerificadores(string cpf)
        {
            try
            {
                //Pesos utilizados para o cálculo dos dígitos verificadores
                int[] pesosPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] pesosSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                //Calcula o primeiro dígito verificador
                int somaPrimeiroDigito = 0;
                for (int i = 0; i < 9; i++)
                {
                    somaPrimeiroDigito += (cpf[i] - '0') * pesosPrimeiroDigito[i]; //Converte cada caractere para seu valor numérico
                }
                //Calcula o primeiro dígito verificador com base no resto da divisão
                int primeiroDigitoVerificador = somaPrimeiroDigito % 11 < 2 ? 0 : 11 - (somaPrimeiroDigito % 11);

                // Calcula o segundo dígito verificador
                int somaSegundoDigito = 0;
                for (int i = 0; i < 10; i++)
                {
                    somaSegundoDigito += (cpf[i] - '0') * pesosSegundoDigito[i];
                }
                // Calcula o segundo dígito verificador com base no resto da divisão
                int segundoDigitoVerificador = somaSegundoDigito % 11 < 2 ? 0 : 11 - (somaSegundoDigito % 11);

                // Verifica se os dígitos verificadores calculados coincidem com os últimos dois dígitos do CPF
                return cpf[9] == (primeiroDigitoVerificador + '0') && cpf[10] == (segundoDigitoVerificador + '0');
            }
            catch (Exception) { throw; }

        }
        //Questão 6: Simulador de Caixa Eletrônico
        //Crie um simulador de caixa eletrônico que permite ao usuário sacar dinheiro.
        //O programa deve:
        //Solicitar o valor do saque.
        //Verificar se o valor é múltiplo de 10 (já que o caixa só trabalha com notas de 10, 20, 50 e 100).
        //Calcular a quantidade de notas necessárias para o saque, priorizando as notas de maior valor.
        //Tratar exceções para valores inválidos (negativos, não múltiplos de 10, etc.).




        //Questão 9: Validação de CNPJ
        //Crie um programa que valida um CNPJ(Cadastro Nacional da Pessoa Jurídica) de acordo com as regras oficiais.
        //O CNPJ deve ter 14 dígitos, e os dois últimos dígitos são verificadores, calculados com base nos 12 primeiros dígitos.
        //O programa deve permitir que o usuário insira o CNPJ e informe se ele é válido ou inválido.
        //Regras de Validação de CNPJ:
        //O CNPJ deve ter 14 dígitos.
        //Os dois últimos dígitos são verificadores, calculados com base nos 12 primeiros dígitos. 
        //O cálculo dos dígitos verificadores é semelhante ao do CPF, mas com pesos diferentes: 
        //Para o primeiro dígito verificador, os pesos são: 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2. 
        //Para o segundo dígito verificador, os pesos são: 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2

       

    }
}





//
