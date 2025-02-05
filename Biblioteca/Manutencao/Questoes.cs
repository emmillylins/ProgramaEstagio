using Biblioteca.Classes;
using Biblioteca.Validacao;
using Microsoft.VisualBasic;
using System.Drawing;
using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Intrinsics.X86;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace Biblioteca.Manutencao
{
    public class Questoes
    {
        public void VerificaNumeroPrimo()
        {
            try
            {
                var validacoes = new Validacoes();

                Console.Write("Digite um número: ");

                if (!int.TryParse(Console.ReadLine(), out int numero) || numero < 1)
                {
                    throw new Exception("Número inválido. Digite apenas numeros inteiros e positivos");
                }

                if (validacoes.ValidaNumeroPrimo(numero))
                {
                    Console.WriteLine($"{numero} é um número primo.");
                }
                else
                {
                    Console.WriteLine($"{numero} não é um número primo.");
                }
            }
            catch (Exception) { throw; }
        }

        //Questão de João Gabriel
        // Escreva um programa C# que solicite ao usuário 5 números inteiros 
        // O programa deve armazenar esses números em uma lista e, ao final,
        // exibir os números pares e a soma dos números ímpares
        public void ExibirNumParImpar()
        {
            try
            {
                var validacoes = new Validacoes();


                List<string> ordem = ["primeiro", "segundo", "terceiro", "quarto", "quinto"];
                List<int> numerosPares = [];
                List<int> numerosImpares = [];

                Console.WriteLine("Programa para listar números pares e somar números ímpares.");

                for (int i = 0; i < ordem.Count; i++)
                {
                    Console.WriteLine($"Informe o {ordem[i]} número: ");
                    var numeroInserido = Console.ReadLine();

                    if (!int.TryParse(numeroInserido, out var numero))
                    {
                        throw new Exception($"O {ordem[i]} número é um valor inválido! \n Valor inserido: {numeroInserido}");
                    }

                    if (validacoes.ValidaNumeroParImpar(numero))
                    {
                        numerosPares.Add(numero);
                    }
                    else
                    {
                        numerosImpares.Add(numero);
                    }
                }

                int somaNumerosImpares = numerosImpares.Sum();

                Console.WriteLine("Números pares:");
                foreach (int numero in numerosPares)
                {
                    Console.WriteLine(numero);
                }
                Console.WriteLine($"Soma dos números ímpares: {somaNumerosImpares}");
            }
            catch (Exception) { throw; }
        }

        //Questão de Elton
        //Escreva um program em C# que solicita ao usuário 7 números inteiros e armazene
        // apenas os números positivos em uma lista.
        // Se um número negativo for inserido ele deve ser ignorado e o programa deve solicitar
        // um novo número no lugar, utilize um loop for para receber os 7 números válidos.
        public void ListarNumerosPositivo()
        {
            Console.WriteLine("Program que lista somente 7 números pares digitados pelo usuário.");
            try
            {
                Validacoes validacoes = new();
                List<string> ordem = ["primeiro", "segundo", "terceiro", "quarto", "quinto", "sexto", "sétimo"];
                List<int> numerosInteiros = [];

                for (int i = 0; i < ordem.Count; i++)
                {
                    Console.Write($"Digite o {ordem[i]} número: ");
                    if (!int.TryParse(Console.ReadLine(), out int numero))
                    {
                        Console.WriteLine("Digite somente números inteiros.");
                        i--;
                    }
                    if (numero > 0)
                    {
                        numerosInteiros.Add(numero);
                    }
                }
                Console.WriteLine("Os números positivos são: ");
                foreach (int numero in numerosInteiros) { Console.WriteLine(numero); }
            }
            catch (Exception) { throw; }
        }

        // Questão de Vanessa
        //Escreva um programa que solicite ao usuario 5 números inteiros
        // Determine quantos deles são múltiplo de 3
        public void ExibeQtdMultiplosDeTres()
        {
            var validacoes = new Validacoes();
            try
            {
                List<int> numerosMultiplos = [];
                var qtdNumerosMultiplos = 0;

                Console.WriteLine("Programa que determina quantos números são múltiplos de três.");

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Digite um número inteiro: ");
                    var numeroDigitados = Console.ReadLine();

                    if (!int.TryParse(numeroDigitados, out var numero))
                    {
                        throw new Exception("Número inválido.");
                    }
                    bool verificaMultiploDeTres = validacoes.ValidaMultiplosDeTres(numero);

                    if (verificaMultiploDeTres == true) qtdNumerosMultiplos++;
                }
                Console.WriteLine($"Quantidade de números múltiplos: {qtdNumerosMultiplos}");
            }
            catch (Exception) { throw; }
        }

        // Questão de Clara
        //Escreva um programa que solicite ao usuário 5 números e informe qual é o maior digitado
        //  e qual é o menor digitado
        //  Caso o número não seja válido, ele deve pedir novamente.
        public void InformaNumeroMaiorMenor()
        {
            try
            {
                var metodos = new Metodos();
                var numeros = new List<double>();

                Console.WriteLine("Programa que informa qual dos números é o maior e qual é o menor.");

                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"Insira o {i + 1}° número: ");

                    var numeroInserido = Console.ReadLine();

                    if (!double.TryParse(numeroInserido, CultureInfo.InvariantCulture, out var numero))
                    {
                        Console.WriteLine("Digite apenas números.");
                        i--;
                    }

                    if (numeros.Count > 1)
                    {
                        if (numero == numeros.Last())
                        {
                            Console.WriteLine("O número atual não pode ser igual ao número anterior.");
                            i--;
                        }
                    }
                    numeros.Add(numero);
                }

                (double maior, double menor) = metodos.RetornaNumeroMaiorMenor(numeros);

                Console.WriteLine($"\nO maior número foi {maior} e o menor número foi {menor}");
            }
            catch (Exception) { throw; }
        }

        //Crie um programa que exiba um menu interativo com as seguintes opções:
        //1 - Cadastrar usuário
        //2 - Listar usuários cadastrados
        //3 - Sair
        //O programa deve validar as opções digitadas e permitir que o usuário cadastre nomes em uma lista até escolher a opção de sair.

        public void MenuInterativo()
        {
            try
            {
                Console.WriteLine("Menu interativo para cadastro de usuários!");

                List<Usuario> usuarios = new List<Usuario>();
                var metodos = new Metodos();

                while (true)
                {
                    Console.WriteLine(@"1 - Cadastrar usuário
2 - Listar usuários cadastrados
3 - Sair");

                    var usuarioInserido = Console.ReadLine();

                    if (!int.TryParse(usuarioInserido, out int opcao))
                    {
                        Console.WriteLine("Escolha uma opção válida!");
                        continue;
                    }

                    switch (opcao)
                    {
                        case 1:
                            usuarios.Add(metodos.CadastrarUsuario());
                            break;
                        case 2:
                            metodos.MostrarUsuario(usuarios);
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Digite um valor válido");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }


        //Sistema de Login com Tentativas Limitadas
        //Crie um programa que simule um sistema de login.
        //O usuário deve fornecer um nome de usuário e senha.
        //O programa deve validar se as credenciais correspondem a um usuário pré-cadastrado.
        //O usuário tem no máximo 3 tentativas antes de ser bloqueado.
        //Caso o usuário insira valores inválidos (ex.: campo vazio), deve ser exibida uma mensagem de erro
        //sem descontar tentativas.
        public void SistemaLogin()
        {
            try
            {
                int tentativas = 3;
                var validacoes = new Validacoes();

                Console.WriteLine("Sistema de login.");

                for (int i = 0; i < tentativas; i++)
                {
                    Console.Write("Insira seu nome de usuário: ");
                    string nomeUsuario = Console.ReadLine();

                    if (string.IsNullOrEmpty(nomeUsuario))
                    {
                        Console.WriteLine("O usuário não pode ser nulo.");
                        i--;
                    }
                    else
                    {

                        Console.Write("Insira sua senha: ");
                        var senha = Console.ReadLine();

                        if (string.IsNullOrEmpty(senha))
                        {
                            Console.WriteLine("A senha não pode ser nula.");
                            i--;
                        }

                        if (validacoes.ValidaUsuarioExistente(nomeUsuario, senha))
                        {
                            Console.WriteLine("Login efetuado com sucesso.");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Login ou senha inválidos.");
                        }
                    }
                }
                Console.WriteLine("Número de tentativas excedido.");
            }
            catch (Exception) { throw; }
            ;
        }


        //Caixa Eletrônico Simples
        //Desenvolva um programa que simule um caixa eletrônico.
        //O usuário começa com um saldo inicial.
        //Ele pode escolher entre as opções:
        //1 - Depositar
        //2 - Sacar
        //3 - Ver saldo
        //4 - Sair
        //Os saques devem ser permitidos apenas se houver saldo suficiente.
        //O programa deve tratar entradas inválidas e continuar rodando até o usuário escolher a opção de sair.

        public void CaixaEletronico(double saldoInicial)
        {
            try
            {
                Console.WriteLine("Caixa Eletrônico Simples");
                List<double> saldo = new List<double>();
                saldo.Add(saldoInicial);
                var metodos = new Metodos();

                while (true)
                {
                    Console.WriteLine("\nEscolher as opções abaixo: ");
                    Console.WriteLine("1 - Depositar");
                    Console.WriteLine("2 - Sacar");
                    Console.WriteLine("3 - Ver saldo");
                    Console.WriteLine("4 - Sair");


                    if (!int.TryParse(Console.ReadLine(), out int opcao))
                    {
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                    }
                    ;
                    switch (opcao)
                    {
                        case 1:
                            double deposito = metodos.Depositar();
                            saldo.Add(deposito);
                            Console.WriteLine($"Saldo depositado: {deposito:F2}");
                            break;
                        case 2:
                            double saque = metodos.Sacar(saldo);
                            if (saque == 0)
                            {
                                Console.WriteLine("Nenhum saque foi efetuado");
                                break;
                            }
                            else
                            {
                                double saldoRestante = saldo.Sum() - saque;
                                saldo = new List<double> { saldoRestante };

                                Console.WriteLine($"Saldo Disponivel apos o saque: {saldoRestante:F2}");
                                break;
                            }
                        case 3:
                            Console.WriteLine($"Saldo Disponivel: {saldo.Sum():F2}");
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("\nDigite uma opção válida");
                            break;
                    }
                }
            }
            catch (Exception) { throw; }
        }

        //Cadastro de Produtos com Preços e Cálculo de Total
        //Crie um programa que permita cadastrar produtos com nome e preço.        
        //O usuário pode cadastrar quantos produtos desejar.
        //Ao final, o programa deve exibir a lista de produtos cadastrados e o valor total da compra.
        //O programa deve validar entradas inválidas (ex.: nome vazio, preço inválido).
        //Não deve permitir preços negativos.

        public void ListaProdutoPreco()
        {
            try
            {
                Console.WriteLine("Cadastro de Produtos e seus preços, realizando o cálculo total");
                var metodos = new Metodos();
                var produto = new Produto();
                List<Produto> produtos = new List<Produto>();
                double valorTotal = 0;

                while (true)
                {
                    Console.WriteLine("\nSelecione a opção: ");
                    Console.WriteLine("1 - Cadastrar produto\n2 - Sair");
                    Console.Write("\nSua opção: ");

                    if (!int.TryParse(Console.ReadLine(), out var opcao))
                    {
                        Console.WriteLine("\nInsira uma opção válida.");
                    }

                    switch (opcao)
                    {
                        case 1:
                            //todo metodo que retorna algo precisa de uma atribuiçao
                            produto = metodos.CadastrarProduto();
                            if (produto != null)
                            {
                                produtos.Add(produto);
                            }
                            break;
                        case 2:
                            //chamar metodo de exibir nome dos produtos
                            metodos.ExibirListaProdutos(produtos);
                            valorTotal = metodos.CalcularValorTotal(produtos);
                            Console.WriteLine($"O valor total de itens é {valorTotal:F2}");
                            return;
                        default:
                            Console.WriteLine("\nInsira uma opção válida!");
                            break;
                    }
                }
            }
            catch (Exception) { throw; }
        }


        //Gerenciamento de Alunos e Notas
        //Crie um sistema de gerenciamento de alunos e notas.
        //O sistema deve permitir:
        //1. Cadastro de Alunos: O usuário poderá cadastrar alunos informando o nome e adicionar suas 4 notas.
        //(cada aluno inserido terá id gerado automaticamente)
        //2. Exibição de todos Alunos e Médias: O sistema deve exibir a lista de alunos cadastrados, mostrar suas 4 notas e a média.
        //3. Exibição de um aluno específico, passando o id dele, mostrar suas 4 notas e a média
        //4. Sair
        //O sistema deve calcular a média do aluno e exibir se ele está
        //Aprovado(média ≥ 7), Recuperação(média entre 5 e 6.9) ou Reprovado(média < 5).
        //Validação: O sistema deve impedir a inserção de notas negativas ou acima de 10.

        public void GenrenciamentoALunos()
        {
            try
            {
                Console.WriteLine("Gerenciamento de Alunos e notas");
                List<Aluno> listaAlunos = [];
                Metodos metodos = new();
                var i = 1;
                while (true)
                {
                    Console.WriteLine("\nEscolha uma opção");
                    Console.WriteLine("1 - Cadastrar aluno");
                    Console.WriteLine("2 - Exibir alunos e médias");
                    Console.WriteLine("3 - Exibir aluno por id");
                    Console.WriteLine("4 - Sair");

                    if (!int.TryParse(Console.ReadLine(), out var opcao))
                    {
                        Console.WriteLine("Insira uma opção válida!");

                    }

                    switch (opcao)
                    {
                        case 1:
                            var alunoCadastrado = metodos.CadastrarAluno();
                            if (alunoCadastrado != null)
                            {
                                alunoCadastrado.Id = i;
                                i++;
                                listaAlunos.Add(alunoCadastrado);
                            }
                            break;
                        case 2:
                            metodos.ExibirAlunos(listaAlunos);
                            break;
                        case 3:
                            metodos.BuscaAlunoPorId(listaAlunos);
                            break;
                        case 4:
                            return;
                    }

                }
            }
            catch (Exception) { throw; }
        }
        // Questão 1: Como posso criar um jogo simples de adivinhação em C# onde o usuário tenha 5 tentativas para adivinhar um número secreto entre 1 e 100?
        // Regras:
        // Caso o palpite não seja um valor válido, não deve ser contado como tentativa
        // Se o palpite for maior que o número secreto: mostre uma mensagem personalizada;
        // Se o palpite for menor que o número secreto: mostre uma mensagem personalizada;
        public void JogoAdivinhacao()
        {
            try
            {
                //Criando variáveis com o número de tentativas, estaciando o objeto "randomico" para poder utilizar o método random e por fim gerando o número secreto de 1 a 100.
                int numeroTentativas = 5;
                Random randomico = new Random();
                int numeroSecreto = randomico.Next(1, 101);
                Console.WriteLine("Tente adivinhar um número de 1 a 100.");
                //For para permitir o usuário ter 5 tentativas.
                for (int i = 1; i <= numeroTentativas; i++)
                {
                    Console.Write($"\nDigite o {i}° número: ");
                    string? numeroInserido = Console.ReadLine();
                    //Verificação para números inválidos.
                    if (!int.TryParse(numeroInserido, out int numero) || numero < 1 || numero > 100)
                    {
                        Console.WriteLine("Número inválido, digite novamente.");
                        i--;
                    }
                    else if (numero == numeroSecreto)
                    {
                        Console.WriteLine($"Parabéns o número era {numero} e você acertou na {i}° tentativa!");
                        return;
                    }
                    else if (numero > numeroSecreto)
                    {
                        Console.WriteLine("Errou, o número digitado é maior que o número secreto.");
                    }
                    else
                    {
                        Console.WriteLine("Errou, o número digitado é menor que o número secreto.");
                    }
                }
                Console.WriteLine($"Infelizmente acabaram suas tentativas, o número secreto era {numeroSecreto}.");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Questão 2: Crie um programa que leia uma lista de números inteiros do usuário e classifique-os em positivos, negativos e zeros.
        public void VerificaNumerosInseridos()
        {
            try
            {
                //Criando 3 listas para armazenas os 3 tipos de números.
                Console.WriteLine("Verificador de número positivos negativos e zeros.");
                List<double> numerosPositivos = new List<double>();
                List<double> numerosNegativos = new List<double>();
                List<double> zeros = new List<double>();
                Console.WriteLine("Caso queira parar de digitar números digite sair.");
                //Criando um booleano para continuar no loop até que o usuário deseje sair.
                bool loop = true;
                for (int i = 1; loop; i++)
                {
                    Console.Write($"\nDigite o {i}° número: ");
                    string? numeroDigitado = Console.ReadLine().ToLower();
                    //Verificação para que o usuário digite sair quando queria parar de digitar.
                    if (numeroDigitado == "sair")
                    {
                        loop = false;
                    }
                    //Verificação de somente números válidos além de continuar o loop.
                    else if (!double.TryParse(numeroDigitado, CultureInfo.InvariantCulture, out double numero))
                    {
                        Console.WriteLine("Digite somente números!");
                        i--;
                    }
                    else if (numero > 0)
                    {
                        numerosPositivos.Add(numero);
                    }
                    else if (numero < 0)
                    {
                        numerosNegativos.Add(numero);
                    }
                    else if (numero == 0)
                    {
                        zeros.Add(numero);
                    }
                }
                //Verificação se o usuário digitou algum número.
                if (numerosPositivos != null || numerosNegativos != null || zeros != null)
                {
                    Console.WriteLine("Os números digitados foram :");
                    if (numerosPositivos != null)
                    {
                        Console.Write($"\nNúmeros positivos: ");
                        foreach (int numero in numerosPositivos)
                        {
                            Console.Write($"{numero} ");
                        }
                    }
                    if (numerosNegativos != null)
                    {
                        Console.Write($"\nNúmeros negativos: ");
                        foreach (int numero in numerosNegativos)
                        {
                            Console.Write($"{numero} ");
                        }
                    }
                    if (zeros != null)
                    {
                        Console.Write($"\nZeros: ");
                        foreach (int numero in zeros)
                        {
                            Console.Write($"{numero} ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum número foi digitado.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Questão 3: Validação de Senha:
        //Implemente um sistema de validação de senha que exige pelo menos 8 caracteres, pelo menos uma letra maiúscula, uma letra minúscula e um caractere especial.O programa deve informar se a senha fornecida atende aos critérios.
        //Regras: Utilize método para validar a senha inserida.
        public void VerificarSenha()
        {
            try
            {
                //Criação de instância de validações.
                Console.WriteLine("Verificação de Senha.");
                Validacoes validacao = new Validacoes();
                Console.WriteLine("É necessário que a senha possua ao menos 8 caracteres, 1 letra maiúscula, 1 letra minúscula e 1 caracter especial como : ; @ # .");
                //Loop para continuar pedindo senha.
                while (true)
                {
                    Console.Write("\nDigite sua senha: ");
                    string? senhaInserida = Console.ReadLine();
                    if (string.IsNullOrEmpty(senhaInserida))
                    {
                        Console.WriteLine("Digite algo, sua senha não pode nula!");
                    }
                    else
                    {
                        if (validacao.ValidarSenha(senhaInserida))
                        {
                            Console.WriteLine("Senha atende a todos os critérios!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Senha inválida!");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Questão 4: Calculadora com Operações Avançadas:
        //Desenvolva uma calculadora que permita ao usuário realizar operações básicas(adição, subtração, multiplicação, divisão) e operações avançadas(potenciação, raiz quadrada) 
        //com base em escolhas feitas usando um menu e estruturas de controle(switch/case).
        public void Calculadora()
        {
            try
            {
                while (true)
                {
                    //Instanciando metodos para criar o calculo
                    Metodos metodos = new Metodos();
                    //Criando menu para o usuário
                    Console.WriteLine("Calculadora");
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("\nEscolha uma das opções:");
                    Console.WriteLine("1 - adição");
                    Console.WriteLine("2 - subtração");
                    Console.WriteLine("3 - multiplicação");
                    Console.WriteLine("4 - divisão");
                    Console.WriteLine("5 - potenciação");
                    Console.WriteLine("6 - raiz quadrada");
                    string? numeroInserido = Console.ReadLine();
                    //Verificando número inserido no menu.
                    if (!int.TryParse(numeroInserido, out var numero) || numero < 1 || numero > 6)
                    {
                        Console.WriteLine("Número inválido, pedimos para que digite um número válido.");
                    }
                    else
                    {
                        //Chamada do método para calculo
                        metodos.Calcular(numero);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Questão 5: Validação de CPF
        //Crie um programa que solicita ao usuário um CPF e valida se ele está no formato correto(11 dígitos numéricos). O programa deve permitir que o usuário tente novamente caso o formato esteja incorreto.Utilize tratamento de exceções para garantir que o CPF contenha apenas números e tenha o tamanho correto.

        //Regras de Validação de CPF
        //        O CPF deve ter 11 dígitos.
        //Os dois últimos dígitos são verificadores, calculados com base nos 9 primeiros dígitos. 
        //O cálculo dos dígitos verificadores é feito da seguinte forma: 

        //Para o primeiro dígito verificador: 
        //Multiplica-se cada um dos 9 primeiros dígitos por um peso que começa em 10 e diminui até 2. 
        //Soma-se os resultados.
        //O dígito verificador é o resto da divisão dessa soma por 11. Se o resto for menor que 2, o dígito é 0; caso contrário, é 11 menos o resto.

        //Para o segundo dígito verificador: 
        //Multiplica-se cada um dos 10 primeiros dígitos(9 originais + primeiro dígito verificador) por um peso que começa em 11 e diminui até 2. 
        //Soma-se os resultados.
        //O dígito verificador é o resto da divisão dessa soma por 11. 
        //Se o resto for menor que 2, o dígito é 0; caso contrário, é 11 menos o resto.

        public void VerificarCpf()
        {
            try
            {
                Validacoes validacao = new Validacoes();
                Console.WriteLine("Validador de CPF.");

                while (true)
                {
                    //Criação de variáveis e verificação com base no valor retornado do método.
                    Console.Write("\nDigite o seu CPF: ");
                    string? cpfInserido = Console.ReadLine();
                    if (validacao.ValidarCpf(cpfInserido))
                    {
                        Console.WriteLine($"O CPF inserido {cpfInserido} é válido!");
                    }
                    else
                    {
                        Console.WriteLine($"O CPF inserido {cpfInserido} é inválido!");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //        Questão 6: Simulador de Caixa Eletrônico
        //Crie um simulador de caixa eletrônico que permite ao usuário sacar dinheiro.
        //O programa deve:
        //Solicitar o valor do saque.
        //Verificar se o valor é múltiplo de 10 (já que o caixa só trabalha com notas de 10, 20, 50 e 100).
        //Calcular a quantidade de notas necessárias para o saque, priorizando as notas de maior valor.
        //Tratar exceções para valores inválidos (negativos, não múltiplos de 10, etc.).

        public void SimuladorCaixaEletronico()
        {
            try
            {
                Validacoes validacao = new Validacoes();
                Console.WriteLine("Simulador de Caixa Eletrônico");
                while (true)
                {
                    //Variavel e recebendo o valor do saque do usuário
                    Console.Write("\nDigite o valor de saque desejado: ");
                    string? valorInserido = Console.ReadLine();
                    //Verificando se o valor é válido  
                    if (!double.TryParse(valorInserido, out double valorSaque) || valorSaque <= 0)
                    {
                        Console.WriteLine("Digite um valor válido e positivo para o saque.");
                    }
                    else
                    {
                        //Chamada do método para validar se é número de dez
                        if (validacao.ValidaMultiploDeDez(valorSaque))
                        {
                            //Contador de notas.
                            double quantidadeNota100 = 0;
                            double quantidadeNota50 = 0;
                            double quantidadeNota20 = 0;
                            double quantidadeNota10 = 0;
                            //Verificando a quantidade de notas verificando se o número do saque é divisivel pelo valor da nota e imprimindo a quantidade de notas referente ao valor do saque.
                            if (valorSaque % 100 != 0)
                            {
                                quantidadeNota100 = Math.Floor(valorSaque / 100);
                                valorSaque -= (quantidadeNota100 * 100);
                                if (valorSaque % 50 != 0)
                                {
                                    quantidadeNota50 = Math.Floor(valorSaque / 50);
                                    valorSaque -= (quantidadeNota50 * 50);
                                    if (valorSaque % 20 != 0)
                                    {
                                        quantidadeNota20 = Math.Floor(valorSaque / 20);
                                        valorSaque -= (quantidadeNota20 * 20);
                                        quantidadeNota10 = valorSaque / 10;
                                        Console.WriteLine($"A notas disponíveis para saque serão {quantidadeNota100:F0} notas de R$100, {quantidadeNota50:F0} notas de R$50, {quantidadeNota20:F0} notas de R$20 e {quantidadeNota10:F0} notas de R$10.");
                                        return;
                                    }
                                    else
                                    {
                                        quantidadeNota20 = valorSaque / 20;
                                        Console.WriteLine($"A notas disponíveis para saque serão {quantidadeNota100:F0} notas de R$100, {quantidadeNota50:F0} notas de R$50 e {quantidadeNota20:F0} notas de R$20.");
                                        return;
                                    }
                                }
                                else
                                {
                                    quantidadeNota50 = valorSaque / 50;
                                    Console.WriteLine($"A notas disponíveis para saque serão {quantidadeNota100:F0} notas de R$100, e {quantidadeNota50:F0} notas de R$50.");
                                    return;
                                }
                            }
                            else
                            {
                                quantidadeNota100 = valorSaque / 100;
                                Console.WriteLine($"A notas disponíveis para saque serão {quantidadeNota100:F0} notas de R$100.");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("É necessário que o valor do saque seja múltiplo de 10.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //        Questão 7: Jogo da Forca
        //Crie um jogo da forca em que o programa escolhe uma palavra aleatória de uma lista e o usuário tenta adivinhar a palavra, letra por letra.O usuário tem 6 tentativas para acertar a palavra.
        //O programa deve:
        //Exibir o progresso do usuário (letras acertadas e letras faltando). 
        //Contar as tentativas restantes.
        //Tratar exceções para entradas inválidas (mais de uma letra, caracteres não alfabéticos, etc.).
        public void JogoDaForca()
        {
            try
            {
                Metodos metodos = new Metodos();
                string? palavaMisteriosa = metodos.PalavraMisteriosa();
                Console.WriteLine("Jogo da Forca");
                Console.WriteLine("\nTente advinhar a palavra.");
                Console.WriteLine($"Dica: a palavra misteriosa possui {palavaMisteriosa.Length} letras.");
                int numeroAcertos = 0;
                int numeroDeLetras = palavaMisteriosa.Length;
                string?[] palavraInserida = new string[numeroDeLetras];
                for (int i = 0; i < 6; i++)
                {
                    Console.Write("\nDigite uma letra: ");
                    string? letraInserida = Console.ReadLine();
                    if (!(letraInserida.Length > 1))
                    {
                        //usar try parse para verificar letra inserida. 

                        if (palavraInserida.Contains(letraInserida))
                        {
                            Console.WriteLine($"A letra {letraInserida}, já foi inserida. ");
                            i--;
                        }
                        else
                        {
                            if ((palavaMisteriosa.IndexOf(letraInserida)) != -1)
                            {
                                palavraInserida[palavaMisteriosa.IndexOf(letraInserida)] = letraInserida;
                                numeroAcertos++;
                                numeroDeLetras--;
                                Console.WriteLine($"Você acertou {numeroAcertos} letras, ainda faltam {numeroDeLetras} letras.");
                            }
                            else
                            {
                                Console.WriteLine($"A palavra não possui a letra {letraInserida}.");
                            }
                        }
                        if (numeroAcertos == palavaMisteriosa.Length)
                        {
                            Console.WriteLine($"Parabêns você acertou, a palavra misteriosa era {palavaMisteriosa}");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Digite somemte uma letra por vez.");
                        i--;
                    }
                }
                Console.WriteLine($"Infelizmente você perdeu a palavra misteriosa era {palavaMisteriosa}.");
            }
            catch (Exception)
            {

            }
        }
    }
}

