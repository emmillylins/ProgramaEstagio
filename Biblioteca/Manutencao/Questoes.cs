using Biblioteca.Classes;
using Biblioteca.Validacao;
using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

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

        // Questão de João Gabriel
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

        // Questão de Elton
        // Escreva um program em C# que solicita ao usuário 7 números inteiros e armazene
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
        //Determine quantos deles são múltiplo de 3
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
        // e qual é o menor digitado
        // Caso o número não seja válido, ele deve pedir novamente.
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
        //O programa deve validar as opções digitadas e permitir que o usuário cadastre nomes em uma lista
        //até escolher a opção de sair.
        public void CadastrarUsuarios()
        {
            try
            {
                var metodos = new Metodos();
                var usuarios = new List<Usuario>();

                while (true)
                {
                    Console.WriteLine("Menu interativo para cadastro de usuários!");
                    Console.WriteLine($"\n1. Cadastrar usuário." +
                        $"\n2. Exibir usuário" +
                        $"\n3. Sair");

                    Console.Write("\nSua opção: ");

                    if (!int.TryParse(Console.ReadLine(), out int opcao))
                    {
                        throw new Exception("Digite um valor válido.");
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
            catch (Exception) { throw; }
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
            catch (Exception) { throw; };
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
                    };
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

        //Questão 1: Como posso criar um jogo simples de adivinhação em C# onde o usuário tenha 5 tentativas para adivinhar um número secreto entre 1 e 100?

        public void JogoAdivinhacao()
        {
            try
            {
                Console.WriteLine("Jogo de Adivinhação!");
                Console.WriteLine("Você tem 5 tentativas.");
                var metodos = new Metodos();
                int numeroAleatorio = metodos.GerarNumero();
                int tentativas = 5;

                for (int i = 0; i < tentativas;)
                {
                    Console.Write("\nDigite seu palpite: ");
                    string numeroDigitado = Console.ReadLine();

                    if (!int.TryParse(numeroDigitado, out int palpite) || palpite < 0 || palpite > 100)
                    {
                        Console.WriteLine("Digite um número válido entre 1 e 100!");
                        continue;
                    }

                    i++;

                    if (palpite == numeroAleatorio)
                    {
                        Console.WriteLine($"Você acertou o número secreto, que é {numeroAleatorio}.");
                        return;
                    }
                    else if (palpite > numeroAleatorio)
                    {
                        Console.WriteLine("Seu palpite é maior que o número secreto!");
                    }
                    else
                    {
                        Console.WriteLine("Seu palpite é menor que o número secreto!");
                    }

                }

                Console.WriteLine($"Você gastou todas as suas tentativas! O número secreto era {numeroAleatorio}.");

            }
            catch (Exception) { throw; }
        }

        //Questão 2: Crie um programa que leia uma lista de números inteiros do usuário e classifique-os em positivos, negativos e zeros.

        public void ProgramaLeitorNumeros()
        {
            try
            {
                var metodos = new Metodos();
                List<int> listaNumeros = new List<int>();

                Console.WriteLine("Programa para classificar números inteiros em positivos, negativos e zeros.");

                while (true)
                {
                    Console.WriteLine("\nEscolha uma opção:");
                    Console.WriteLine("1 - Inserir número na lista");
                    Console.WriteLine("2 - Ler números da lista");
                    Console.WriteLine("3 - Sair");

                    var escolha = Console.ReadLine();

                    switch (escolha)
                    {
                        case "1":
                            Console.WriteLine("Digite o número que você quer inserir: ");
                            var numeroInserido = Console.ReadLine();

                            if (int.TryParse(numeroInserido, out int numero))
                            {
                                listaNumeros.Add(numero);
                                Console.WriteLine($"Número {numero} adicionado à lista.");
                            }
                            else
                            {
                                Console.WriteLine("Digite apenas números inteiros.");
                            }
                            break;

                        case "2":
                            metodos.ClassificarNumeros(listaNumeros);
                            break;

                        case "3":
                            Console.WriteLine("Você saiu do programa.");
                            return;

                        default:
                            Console.WriteLine("Opção inválida! Tente novamente.");
                            break;
                    }


                }
            }
            catch (Exception) { throw; }
        }
//        Questão 3: Validação de Senha:
//Implemente um sistema de validação de senha que exige pelo menos 8 caracteres, pelo menos uma letra maiúscula, uma letra minúscula e um caractere especial. O programa deve informar se a senha fornecida atende aos critérios.
//        Regras: Utilize método para validar a senha inserida.

        public void ProgramaValidarSenha()
        {
            var metodos = new Metodos();
            Console.WriteLine("\nPrograma para validação de senhas!\nAs regras são: Sua senha precisa ter pelo menos 8 caracteres,\npelo menos uma letra maiúscula, uma letra minúscula e um caractere especial.");
            Console.Write("Insira sua senha: ");
            var senhaInserida = Console.ReadLine();

            bool senhaValida = metodos.ValidacaoSenhas(senhaInserida);

            if (senhaValida)
            {
                Console.WriteLine("Senha válida!");
            }
            else
            {
                Console.WriteLine("Senha inválida.");
            }

        }

//        Questão 4: Calculadora com Operações Avançadas:

//Desenvolva uma calculadora que permita ao usuário realizar operações básicas(adição, subtração, multiplicação, divisão) e operações avançadas(potenciação, raiz quadrada) com base em escolhas feitas usando um menu e estruturas de controle(switch/case).
//COMECEI MAS NAO CONSEGUI TERMINAR

        public void CalculadoraAvancada()
        {
            try
            {
                Console.WriteLine("Calculadora avançada!");

                while (true)
                {
                    Console.Write("Insira o primeiro número: ");
                    var primeiroNumeroInserido = Console.ReadLine();

                    Console.Write("Insira o segundo número: ");
                    var segundoNumeroInserido = Console.ReadLine();

                    Console.WriteLine("\nEscolha uma operação:");
                    Console.WriteLine("+ - Soma");
                    Console.WriteLine("- - Subtração");
                    Console.WriteLine("/ - Divisão");
                    Console.WriteLine("* - Multiplicação");
                    Console.WriteLine("* - Multiplicação");

                    
                }
            }
            catch (Exception) { throw; }
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

        public void ProgramaValidarCPF()
        {
            try
            {
                var validacao = new Validacoes();
                Console.WriteLine("Programa para validar CPF!");
                Console.Write("Insira um CPF válido, com 11 dígitos numéricos: ");
                var cpfInserido = Console.ReadLine();


                bool ValidarCPF = validacao.ValidarCPF(cpfInserido);

                if (ValidarCPF)
                {
                    Console.WriteLine("CPF válido!");
                }
                else
                {
                    Console.WriteLine("CPF inválido.");
                }

            }
            catch (Exception) { throw; }
        }

        //        Questão 9: Validação de CNPJ

        //Crie um programa que valida um CNPJ(Cadastro Nacional da Pessoa Jurídica) de acordo com as regras oficiais.O CNPJ deve ter 14 dígitos, e os dois últimos dígitos são verificadores, calculados com base nos 12 primeiros dígitos. O programa deve permitir que o usuário insira o CNPJ e informe se ele é válido ou inválido.

        //Regras de Validação de CNPJ:
        //O CNPJ deve ter 14 dígitos.
        //Os dois últimos dígitos são verificadores, calculados com base nos 12 primeiros dígitos. 
        //O cálculo dos dígitos verificadores é semelhante ao do CPF, mas com pesos diferentes: 
        //Para o primeiro dígito verificador, os pesos são: 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2. 
        //Para o segundo dígito verificador, os pesos são: 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2. 
        public void ProgramaValidarCNPJ()
        {
            try
            {
                var validacao = new Validacoes();
                Console.WriteLine("Programa para validar CNPJ!");
                Console.Write("Insira um CNPJ válido, com 14 dígitos numéricos: ");
                var cnpjInserido = Console.ReadLine();


                bool ValidarCNPJ = validacao.ValidarCNPJ(cnpjInserido);

                if (ValidarCNPJ)
                {
                    Console.WriteLine("CNPJ válido!");
                }
                else
                {
                    Console.WriteLine("CNPJ inválido.");
                }

            }
            catch (Exception) { throw; }
        }

        #region Questão do mestre
        //Questão do mestre
        //crie três classes para manter podcasts, episódios e convidados.
        //convidado deve ter um Codigo e um Nome
        //o nome do podcast é pra ser sem logica e o apresentador um apelido meu
        // menu p adicionar convidado ao episodio e p exibir detalhes
        //O podcast possui um Nome, um Apresentador e um TotalEpisodios e uma List<Episodio>.
        //O episódio deve ter um Número, um Título, uma Duracao, um Resumo, TotalConvidados e uma List<Convidado>.
        //Um podcast nasce com um nome e um apresentador definido.
        //Assim, conforme os episódios forem criados, vamos adicioná-los ao podcast.
        //Um podcast também terá dois métodos, um AdicionarEpisodio() e outro ExibirDetalhes().
        //O método ExibirDetalhes() deve mostrar o nome do podcast e o apresentador na primeira linha,
        //seguido pela lista de episódios ordenados por sequência e por fim o total de episódios.
        //O resumo do episódio será concatenado com os valores de número, título, duração e convidados do episódio.
        //Para finalizar, todo episódio possui um método AdicionarConvidados(), que será chamado quantas vezes forem necessárias.

        //Esse é o desafio! O objetivo é colocar tudo o que aprendemos em prática.
        //Isso inclui o construtor, a verificação se o atributo pode ser apenas um atributo ou se precisa ser uma propriedade
        //e também se precisamos utilizar get e set para todos os valores.
        public void CriarPodcast()
        {
            try
            {
                Podcasts podcast1 = new("Sem Lógica", "Clarinha");
                var metodos = new Metodos();

            } catch (Exception) { throw; }
        }
        #endregion

    }
}

