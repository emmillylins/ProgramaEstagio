using Biblioteca.Classes;
using Biblioteca.Validacao;
using System.Globalization;

namespace Biblioteca.Manutencao
{
    public class Questoes
    {
    #region  Questões do segundo formulário
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
                    string nomeUsuario = Console.ReadLine()!;

                    if (string.IsNullOrEmpty(nomeUsuario))
                    {
                        Console.WriteLine("O usuário não pode ser nulo.");
                        i--;
                    }
                    else
                    {

                        Console.Write("Insira sua senha: ");
                        var senha = Console.ReadLine()!;

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
    #endregion

    #region  Formulário 3

        #region Questão jogo de adivinhação
        /* 
            Questão 1: Como posso criar um jogo simples de adivinhação em C# onde o usuário tenha 5 tentativas para adivinhar um número secreto entre 1 e 100?

            Regras:
            Caso o palpite não seja um valor válido, não deve ser contado como tentativa

            Se o palpite for maior que o número secreto: mostre uma mensagem personalizada;

            Se o palpite for menor que o número secreto: mostre uma mensagem personalizada;
        */

        public void JogoAdivinhacao()
        {
            try
            {
                var validacoes = new Validacoes();

                Random numeroSecreto = new();
                var resultado = numeroSecreto.Next(1, 100);

                Console.WriteLine("\nJogo da adivinhação");
                Console.WriteLine("\nAdivinhe o número");

                for (var i = 0; i < 5; i++)
                {
                    Console.WriteLine("\nDigite um número entre 1 e 100");
                    if (!int.TryParse(Console.ReadLine(), out int numeroInserido) || numeroInserido < 1 || numeroInserido > 100)
                    {
                        Console.WriteLine("Número inválido, digite um valor numérico entre um e cem");
                        i--;
                        continue;
                    }

                    if (validacoes.VerificaNumerosIguais(numeroInserido, resultado))
                    {
                        return;
                    }
                }

                Console.Clear();
                Console.WriteLine($"Suas chances esgotaram");
            }
            catch (Exception) { throw; }

        }

        #endregion

        #region Questão classificação de números positivos e negativos
        /* 
            Questão 2: Crie um programa que leia uma lista de números inteiros do usuário e classifique-os em positivos, negativos e zeros. 
        */
        public void ClassificaNumeros()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Lista de números inteiros.");
                Console.WriteLine("Adicione cinco números a lista e vamos organizar eles pra você.");

                List<int> listaNumerosPositivos = [];
                List<int> listaNumerosNegativos = [];
                int valorZero = -1;

                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"Adicione o {i + 1}° número: ");
                    if (!int.TryParse(Console.ReadLine(), out int numeroAdicionado))
                    {
                        Console.WriteLine("O valor precisa ser numérico.");
                        i--;
                        continue;
                    }

                    if (numeroAdicionado > 0)
                    {
                        listaNumerosPositivos.Add(numeroAdicionado);
                    }
                    else if (numeroAdicionado < 0)
                    {
                        listaNumerosNegativos.Add(numeroAdicionado);
                    }
                    else
                    {
                        valorZero = numeroAdicionado;
                    }
                }

                Console.Clear();

                if (listaNumerosPositivos.Count > 0)
                {
                    Console.WriteLine("Seus números positivos");

                    foreach (var numerosPositivos in listaNumerosPositivos)
                    {
                        Console.WriteLine(numerosPositivos);
                    }
                }

                if (listaNumerosNegativos.Count > 0)
                {
                    Console.WriteLine("Seus números negativos");

                    foreach (var numerosNegativos in listaNumerosNegativos)
                    {
                        Console.WriteLine(numerosNegativos);
                    }
                }

                if (valorZero == 0)
                {
                    Console.WriteLine("Existe um valor zero: " + valorZero);
                }
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Questão de validação de senha
        /* 
            Questão 3: Validação de Senha:
            Implemente um sistema de validação de senha que exige pelo menos 8 caracteres, 
            pelo menos uma letra maiúscula, 
            uma letra minúscula e um caractere especial. 
            O programa deve informar se a senha fornecida atende aos critérios.

            Regras: Utilize método para validar a senha inserida.
        */
        public void ValidaSenha() 
        {
            try
            {
                Console.Clear();

                Validacoes validacao = new();

                Console.WriteLine("Sistema de validação de senha");

                Console.Write("\nDIgite sua senha:");
                var senha = Console.ReadLine()!;

                var senhaEValida = validacao.VerificaSenha(senha);

                if (senhaEValida)
                {
                    Console.WriteLine("A senha é válida");
                }
                else 
                {
                    Console.WriteLine("A senha é inválida.");
                }
                
            }
            catch (Exception e) 
            { 
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        #region Questao Calculadora
        /* 
            Desenvolva uma calculadora que permita ao usuário realizar operações básicas (adição, subtração, multiplicação, divisão) e 
            operações avançadas (potenciação, raiz quadrada) com base em escolhas feitas usando um menu e estruturas de controle (switch/case).
       
        */
        public void Calculadora()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Calculadora");

                Console.WriteLine("\nEscolha operação matemática que você deseja.");
                Console.WriteLine("1 - Adição");
                Console.WriteLine("2 - Subtração");
                Console.WriteLine("3 - Multiplicação");
                Console.WriteLine("4 - Divisão");
                Console.WriteLine("5 - Potencialização");
                Console.WriteLine("6 - Radiciação");
                Console.WriteLine("7 - Sair");

                var metodos = new Metodos();

                var condicao =  true;

                while(condicao)
                {
                    
                    if(!int.TryParse(Console.ReadLine(), out int operação) || operação < 1 || operação > 5)
                    {
                        Console.WriteLine("Digite um valor numérico válido");
                        continue;
                    }

                    Console.Clear();

                    switch(operação)
                    {
                        case 1:
                            Console.Write("Adição");
                            var (numero1, numero2) = metodos.PegaDoisNumeros();
                            Console.WriteLine($"Resultado: {numero1} + {numero2} = {numero1 + numero2}");
                            break;
                        case 2:
                            Console.WriteLine("Subtração");
                            var (numero3, numero4) = metodos.PegaDoisNumeros();
                            Console.WriteLine($"Resultado: {numero3} + {numero4} = {numero3 - numero4}");
                            break;
                        case 3:
                            Console.WriteLine("Multiplicação");
                            var (numero5, numero6) = metodos.PegaDoisNumeros();
                            Console.WriteLine($"Resultado: {numero5} + {numero6} = {numero5 * numero6}");
                            break;
                        case 4:
                            Console.WriteLine("Divisão");
                            var (numero7, numero8) = metodos.PegaDoisNumeros();
                            Console.WriteLine($"Resultado: {numero7} + {numero8} = {numero7 / numero8}");
                            break;
                        case 5:
                            Console.WriteLine("Potência");
                            metodos.Potencialização();
                            break;
                        case 6:
                            Console.WriteLine("Radiciação");
                            metodos.Radiciação();
                            break;
                        case 7:
                            return;
                    }

                }

            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Questao validação de CPF
        /* 
            Questão 5: Validação de CPF
            Crie um programa que solicita ao usuário um CPF e valida se ele está no formato correto (11 dígitos numéricos). 
            O programa deve permitir que o usuário tente novamente caso o formato esteja incorreto. 
            Utilize tratamento de exceções para garantir que o CPF contenha apenas números e tenha o tamanho correto.

            Regras de Validação de CPF

            O CPF deve ter 11 dígitos. 
            Os dois últimos dígitos são verificadores, calculados com base nos 9 primeiros dígitos. 
            O cálculo dos dígitos verificadores é feito da seguinte forma: 

            Para o primeiro dígito verificador: 
            Multiplica-se cada um dos 9 primeiros dígitos por um peso que começa em 10 e diminui até 2. 
            Soma-se os resultados. 
            O dígito verificador é o resto da divisão dessa soma por 11. Se o resto for menor que 2, o dígito é 0; caso contrário, é 11 menos o resto. 

            Para o segundo dígito verificador: 
            Multiplica-se cada um dos 10 primeiros dígitos (9 originais + primeiro dígito verificador) por um peso que começa em 11 e diminui até 2. 
            Soma-se os resultados. 
            O dígito verificador é o resto da divisão dessa soma por 11. 
            Se o resto for menor que 2, o dígito é 0; caso contrário, é 11 menos o resto.       
        */
        public void ValidacaoCPF()
        {
            while(true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Validador de CPF");

                    var metodos = new Metodos();

                    Console.Write("Digite seu cpf: ");
                    var cpf = Console.ReadLine()!;

                    // valida se cpf nao tem 11 caracteres e se os caracteres não sao digitos numericos
                    if (cpf.Length != 11 || !cpf.All(char.IsDigit)) 
                    {
                        throw new Exception("O CPF deve ter 11 caracteres");
                    }

                    var penultimoDigitoCpfInserido = int.Parse(cpf[9].ToString());
                    var ultimoDigitoCpfInserido = int.Parse(cpf[10].ToString());

                    string noveCaracteresCpfInserido = cpf[..9]; // Esta variavel armazena os nove primeiros caracteres.
                    string dezCaracteresCpfInserido = cpf[..10]; // Esta variavel armazena os dez primeiros caracteres.

                    var primeiroDigitoVerificador = metodos.CalculaDigitoVerificador(10, noveCaracteresCpfInserido);
                    var segundoDigitoVerificador = metodos.CalculaDigitoVerificador(11, dezCaracteresCpfInserido);

                    // Valida se os dígitos batem
                    if (primeiroDigitoVerificador == penultimoDigitoCpfInserido && segundoDigitoVerificador == ultimoDigitoCpfInserido)
                    {
                        Console.WriteLine("CPF inserido está em um formato válido.");
                        return;
                    }
                    else
                    {
                        throw new Exception("CPF inserido está em um formato inválido.");
                    }

                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                    Thread.Sleep(2000);
                }
            }           
            
        }
        #endregion    

        #region Questão Gerador de tabuada
        /* 
            Crie um programa que gera a tabuada de um número fornecido pelo usuário.O programa deve:
            1. Solicitar ao usuário um número inteiro entre 1 e 10.
            2. Validar se o número está dentro do intervalo permitido.
            3. Gerar a tabuada do número, exibindo os resultados de 1 a 10.
            4. Tratar exceções para entradas inválidas (números fora do intervalo, caracteres não numéricos, etc.).
            5. Permitir que o usuário gere outra tabuada ou encerre o programa. 
        */

        public void GeradorTabuada()
        {
            bool condicao = true;
            List<int> listaNumeros = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            
            Console.Clear();
            Console.WriteLine("Gerador de tabuada");

            while(condicao)
            {
                try
                {
                    Console.Write("Digite o numero da tabuada que você deseja gerar: ");
                    if(!int.TryParse(Console.ReadLine(), out var numeroEscolhido) || numeroEscolhido > 10 || numeroEscolhido < 1)
                    {
                        throw new Exception("O valor inserido deve ser numérico e entre 1 e 10");
                    }

                    foreach(int numero  in listaNumeros)
                    {
                        Console.WriteLine($"{numeroEscolhido} x {numero} = {numeroEscolhido * numero}");
                    }

                    Console.WriteLine("\nDeseja gerar uma nova tabuada? (Sim - Não)");
                    var resposta = Console.ReadLine();

                    if(resposta!.ToLower() == "não")
                    {
                        return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        #endregion
        
    #endregion   
        
    #region Desafio - alura    

        #region Gerenciador de podcasts
        /* 
            Questão do mestre
            crie três classes para manter podcasts, episódios e convidados.
            convidado deve ter um Codigo e um Nome
            O podcast possui um Nome, um Apresentador e um TotalEpisodios e uma List<Episodio>.
            O episódio deve ter um Número, um Título, uma Duracao, um Resumo, TotalConvidados e uma List<Convidado>.
            Um podcast nasce com um nome e um apresentador definido.
            Assim, conforme os episódios forem criados, vamos adicioná-los ao podcast.
            Um podcast também terá dois métodos, um AdicionarEpisodio() e outro ExibirDetalhes().
            O método ExibirDetalhes() deve mostrar o nome do podcast e o apresentador na primeira linha,
            seguido pela lista de episódios ordenados por sequência e por fim o total de episódios.
            O resumo do episódio será concatenado com os valores de número, título, duração e convidados do episódio.
            Para finalizar, todo episódio possui um método AdicionarConvidados(), que será chamado quantas vezes forem necessárias.

            Esse é o desafio! O objetivo é colocar tudo o que aprendemos em prática.
            Isso inclui o construtor, a verificação se o atributo pode ser apenas um atributo ou se precisa ser uma propriedade
            e também se precisamos utilizar get e set para todos os valores.
        */
        public void GerenciadorPodcast()
        {
            bool condicao = true;
            Podcast podcast = new("Sem-lógica", "Thiago");
            Metodos metodos = new();

            while(condicao)
            {
                try
                {

                    Console.Clear();
                    Console.WriteLine($"Bem vindo ao gerenciador do podcast {podcast.Nome}");
                    
                    Console.WriteLine("1 - Adicionar episódio ao podcast");
                    Console.WriteLine("2 - Exibir detalhes do podcast");
                    Console.WriteLine("3 - Sair.");

                    Console.WriteLine("\nSelecione a ação: ");
                    if(!int.TryParse(Console.ReadLine(), out int opcao) || opcao < 1 || opcao > 4)
                    {
                        Console.WriteLine("Insira um valor numérico entre 1 e 3");
                        Thread.Sleep(2000);
                        continue;
                    }

                    switch (opcao)
                    {
                        case 1:
                            metodos.AdicionarEpisodio(podcast);
                            Console.ReadKey();
                            break;
                        case 2:
                            metodos.ExibirDetalhes(podcast);
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("Sair");
                            condicao = false;
                            break;
                    }
                }
                catch (Exception e)
                { 
                    Console.WriteLine(e.Message);
                }
            }
        }

        #endregion

    #endregion    
   
    }
}

