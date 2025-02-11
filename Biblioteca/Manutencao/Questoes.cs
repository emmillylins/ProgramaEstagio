
//Atividade Code Review
using Biblioteca.Classes;
using Biblioteca.Validacao;
using System.Globalization;
namespace Biblioteca.Manutencao
{
    public class Questoes
    {
        #region Verificação de Números Primos
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
        #endregion

        #region Exibir Numeros Pares e Impares
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
        #endregion

        #region Listar Números Positivos
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
        #endregion

        #region Exibição de Múltiplos de Três

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

        #endregion

        #region Informar Número Maior e Menor
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
        #endregion

        #region Menu Interativo
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
        #endregion

        #region Sistema de Login

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

        }
        #endregion

        #region Caixa Eletrônico Simples
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
        #endregion

        #region Cadastro de Produtos

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
        #endregion

        #region Gerenciamento de Alunos e Notas
        // Gerenciamento de Alunos e Notas
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

        #region Forms3

        # region Questão 1: Como posso criar um jogo simples de adivinhação em C# onde o usuário tenha 5 tentativas para adivinhar um número secreto entre 1 e 100?

        //Regras:
        //Caso o palpite não seja um valor válido, não deve ser contado como tentativa
        //Se o palpite for maior que o número secreto: mostre uma mensagem personalizada;
        //Se o palpite for menor que o número secreto: mostre uma mensagem personalizada;

        // Método para jogar o jogo
        public void CriarJogoAdivinhacao()
        {

            try
            {
                // var metodos = new Metodos();
                int numeroSecreto = Metodos.CriarNumeroSecreto();
                int tentativas = 5;

                Console.WriteLine("Bem-vindo ao jogo de adivinhação!");
                Console.WriteLine("Você tem 5 tentativas para adivinhar o número secreto entre 1 e 100.");

                while (tentativas > 0)
                {
                    Console.WriteLine($"\nTentativas restantes: {tentativas}");
                    Console.Write("Digite o seu palpite: ");
                    string palpiteUsuario = Console.ReadLine();

                    //validação para que usuário insira apenas números inteiros.
                    //Cada número inteiro inserido será tentativa de convertido em número 
                    bool palpiteValido = int.TryParse(palpiteUsuario, out var palpite);

                    if (palpiteValido)
                    {
                        bool acerto = Metodos.VerificarPalpite(palpite, numeroSecreto);
                        if (acerto)
                        {
                            Console.WriteLine("Número Correto.");
                            //Sendo um número válido aplica verificacao e segue o fluxo
                            break;
                        }
                        else
                        {
                            //Se não for o número válido não contará como tentativa
                            //E o usuário continua com 5 tentativas 
                            tentativas--;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Por favor, insira um número válido.");
                    }

                    if (tentativas == 0)
                    {
                        Console.WriteLine($"\nVocê não conseguiu adivinhar o número. O número secreto era: {numeroSecreto}");
                    }
                }
            }
            catch (Exception) { throw; }

        }
        #endregion


        #region Questão 2: Leitor de Números Inteiros
        //Crie um programa que leia uma 
        //lista de números inteiros do usuário e classifique-os em positivos, negativos e zeros.
        public void LeiaListaNumerosInteiros()
        {
            try
            {
                var metodos = new Metodos();
                //Lista de números positos, negativos e zeros digitados pelo usuário
                List<int> positivos = new List<int>();
                List<int> negativos = new List<int>();
                List<int> zeros = new List<int>();

                Console.WriteLine("Digite uma lista de números inteiros. Para terminar, digite 'fim'.");

                // Chama o método para ler e classificar os números
                Metodos.lerListaNumerosInteiros(positivos, negativos, zeros);

                // Exibe os resultados
                Console.WriteLine("\nClassificação dos números: ");
                Console.WriteLine($"Positivos: {string.Join(", ", positivos)}");
                Console.WriteLine($"Negativos: {string.Join(", ", negativos)}");
                Console.WriteLine($"Zeros: {string.Join(", ", zeros)}");

            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Questão 3:  Validação de Senha:
        //Implemente um sistema de validação de senha que exige pelo menos 8 caracteres,
        //pelo menos uma letra maiúscula, uma letra minúscula e um caractere especial.
        //O programa deve informar se a senha fornecida atende aos critérios.
        //Regras: Utilize método para validar a senha inserida.
        public void ProgramaDeValidarSenha()

        {
            try
            {
                var metodos = new Metodos();
                Console.WriteLine("Programa para validar senha.");

                // Solicita a senha ao usuário
                Console.Write("\nDigite uma senha para validação: ");
                string senha = Console.ReadLine();

                //Verifica se a senha está vazia ou nula
                if (string.IsNullOrEmpty(senha))
                {
                    Console.WriteLine("Você precisa adicionar pelo menos um caractere à sua senha.");
                    return; //Sai do método se a senha for inválida
                }

                //Chama o método para validar a senha
                bool senhaValida = Metodos.ValidarSenha(senha);

                // Exibe se a senha é válida ou não
                if (senhaValida)
                {
                    Console.WriteLine("Senha válida!");
                }
                else
                {
                    Console.WriteLine("Senha inválida. A senha deve atender aos seguintes critérios:");
                    Console.WriteLine("- Pelo menos 8 caracteres.");
                    Console.WriteLine("- Pelo menos uma letra maiúscula.");
                    Console.WriteLine("- Pelo menos uma letra minúscula.");
                    Console.WriteLine("- Pelo menos um caractere especial.");
                }
            }
            catch (Exception) { throw; };
        }
        //PADRÃO EXPRESSÕES REGULARES - REGEX
        //^(?=.* [a - z]): Exige pelo menos uma letra minúscul;
        //(?=.*[A-Z]): Exige pelo menos uma letra maiúscula;
        //(?=.*[\W_]): Exige pelo menos um caractere especial (isso inclui qualquer caractere não alfanumérico);
        //.{8,}$: Exige no mínimo 8 caracteres.

        #endregion


        #region Questão 4: Calculadora com Operações Avançadas:
        //Desenvolva uma calculadora que permita ao usuário realizar operações básicas(adição, subtração,
        // multiplicação, divisão) e operações avançadas(potenciação, raiz quadrada) com base em escolhas feitas
        //usando um menu e estruturas de controle(switch/case).

        public static void ExibirMenu()
        {
            Console.WriteLine("Programa Calculadora com Operações Básicas e Avançadas.");
            Console.WriteLine("\nEscolha uma operação:");
            Console.WriteLine("1 - Adição");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Potenciação");
            Console.WriteLine("6 - Raiz Quadrada");
            Console.WriteLine("7 - Sair");
            Console.Write("Escolha uma opção (1-7): ");
        }

        public void CalculadoraAvancada()
        {
            try
            {
                int opcao = 0;
                double numero1, numero2, resultado;

                //A condição while será verificada antes de cada operação.
                while (opcao != 7)
                {
                    ExibirMenu();
                    string opcaoEscolhidaPeloUsuario = Console.ReadLine();

                    //Valida se a entrada é um número
                    if (!int.TryParse(opcaoEscolhidaPeloUsuario, out opcao))
                    {
                        Console.WriteLine("Opção inválida, por favor escolha uma opção de 1 a 7.");
                        continue;
                    }

                    switch (opcao)
                    {
                        case 1: //Adição
                            Console.Write("Digite o primeiro número: ");
                            numero1 = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Digite o segundo número: ");
                            numero2 = Convert.ToDouble(Console.ReadLine());
                            resultado = numero1 + numero2;
                            Console.WriteLine($"Resultado: {numero1} + {numero2} = {resultado}");
                            break;

                        case 2: //Subtração
                            Console.Write("Digite o primeiro número: ");
                            numero1 = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Digite o segundo número: ");
                            numero2 = Convert.ToDouble(Console.ReadLine());
                            resultado = numero1 - numero2;
                            Console.WriteLine($"Resultado: {numero1} - {numero2} = {resultado}");
                            break;

                        case 3: //Multiplicação
                            Console.Write("Digite o primeiro número: ");
                            numero1 = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Digite o segundo número: ");
                            numero2 = Convert.ToDouble(Console.ReadLine());
                            resultado = numero1 * numero2;
                            Console.WriteLine($"Resultado: {numero1} * {numero2} = {resultado}");
                            break;

                        case 4: //Divisão
                            Console.Write("Digite o primeiro número: ");
                            numero1 = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Digite o segundo número: ");
                            numero2 = Convert.ToDouble(Console.ReadLine());

                            //Verifica divisão por zero
                            if (numero2 == 0)
                            {
                                Console.WriteLine("Não é possível dividir por zero.");
                            }
                            else
                            {
                                resultado = numero1 / numero2;
                                Console.WriteLine($"Resultado: {numero1} / {numero2} = {resultado}");
                            }
                            break;

                        case 5: //Potenciação
                            Console.Write("Digite a base: ");
                            numero1 = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Digite o expoente: ");
                            numero2 = Convert.ToDouble(Console.ReadLine());
                            resultado = Math.Pow(numero1, numero2);
                            Console.WriteLine($"Resultado: {numero1} ^ {numero2} = {resultado}");
                            break;

                        case 6: //Raiz Quadrada
                            Console.Write("Digite o número: ");
                            numero1 = Convert.ToDouble(Console.ReadLine());

                            //Verifica se o número é negativo
                            if (numero1 < 0)
                            {
                                Console.WriteLine("Erro: Não é possível calcular a raiz quadrada de um número negativo.");
                            }
                            else
                            {
                                resultado = Math.Sqrt(numero1);
                                Console.WriteLine($"Resultado: Raiz quadrada de {numero1} = {resultado}");
                            }
                            break;

                        case 7://Sair
                            Console.WriteLine("Saindo da calculadora...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida! Por favor, escolha uma opção de 1 a 7.");
                            break;
                    }

                    //Solicita ao usuário se deseja continuar
                    if (opcao != 7)
                    {
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();

                    }
                }

                //Finaliza o programa
                Console.WriteLine("Obrigado por usar a calculadora!");

            }
            catch (Exception) { throw; }
        }

        #endregion



        #region Questão 5: Validação de CPF
        //Crie um programa que solicita ao usuário um CPF e valida se ele está no formato correto(11 dígitos numéricos).
        //O programa deve permitir que o usuário tente novamente caso o formato esteja incorreto.Utilize
        //tratamento de exceções para garantir que o CPF contenha apenas números e tenha o tamanho correto.

        //Regras de Validação de CPF
        // O CPF deve ter 11 dígitos.
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


        public void ValidarCpf()
        {
            try
            {
                Console.WriteLine("Programa para validadar CPF");
                var metodos = new Metodos();
                string cpfUsuario;
                bool cpfValido = false;

                //Solicitar CPF ao usuário até que seja válido
                while (!cpfValido)
                {
                    Console.Write("Digite um CPF (somente números): ");
                    cpfUsuario = Console.ReadLine();

                    // Chama o método para validar o CPF
                    cpfValido = Metodos.ValidarCpfFormatado(cpfUsuario);

                    if (cpfValido)
                    {
                        Console.WriteLine("CPF válido!");
                    }
                    else
                    {
                        Console.WriteLine("CPF inválido. O CPF deve conter 11 dígitos numéricos e ser válido.");
                    }
                }
            }
            catch (Exception) { throw; };
        }

        #endregion


        # region Questão 6: Simulador de Caixa Eletrônico
        ////Crie um simulador de caixa eletrônico que permite ao usuário sacar dinheiro.
        ////O programa deve:
        ////Solicitar o valor do saque.
        ////Verificar se o valor é múltiplo de 10 (já que o caixa só trabalha com notas de 10, 20, 50 e 100).
        ////Calcular a quantidade de notas necessárias para o saque, priorizando as notas de maior valor.
        ////Tratar exceções para valores inválidos (negativos, não múltiplos de 10, etc.).

        public void SimularSaque()
        {
            try
            {
                var metodos = new Metodos();
                Console.WriteLine("Programa para simular saque!");
                decimal valorSaque = 0; //Atribuição inicial

                bool saqueValido = false;

                //Solicitar valor de saque ao usuário até que seja válido
                while (!saqueValido)
                {
                    Console.Write("\nDigite o valor do saque: ");
                    string valorInserido = Console.ReadLine();

                    //Tenta converter o valor digitado para decimal
                    if (!decimal.TryParse(valorInserido, CultureInfo.CurrentCulture, out valorSaque))
                    {
                        Console.WriteLine("O valor digitado não é válido. Digite um número válido.");
                        continue;
                    }

                    // Verifica se o valor é maior que 0 e é múltiplo de 10
                    if (valorSaque <= 0)
                    {
                        Console.WriteLine("O valor do saque deve ser positivo.");
                    }
                    else if (valorSaque % 10 != 0)
                    {
                        Console.WriteLine("O valor do saque deve ser múltiplo de 10.");
                    }
                    else
                    {
                        saqueValido = true;
                    }
                }

                //Com o valor  validado, chama o método para calcular as notas
                if (saqueValido)
                {
                    Metodos.CalcularNotas(valorSaque); //Chama o método de cálculo de notas
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possível realizar a transação, tente novamente mais tarde: {ex.Message}");
            }
        }

        #endregion


        # region Questão 7: Jogo da Forca
        //Crie um jogo da forca em que o programa escolhe uma palavra aleatória de uma lista e o usuário tenta adivinhar a palavra, letra por letra.O usuário tem 6 tentativas para acertar a palavra.
        //O programa deve:
        //Exibir o progresso do usuário (letras acertadas e letras faltando). 
        //Contar as tentativas restantes.
        //Tratar exceções para entradas inválidas (mais de uma letra, caracteres não alfabéticos, etc.).
        public void JogoDaForca()
        {
            var metodos = new Metodos();
            string[] palavras = { "programacao", "desenvolvimento", "computador", "software", "jogo" };
            string palavraEscolhida = Metodos.EscolherPalavra(palavras);
            char[] palavraOculta = Metodos.CriarPalavraOculta(palavraEscolhida.Length);
            int tentativas = 6;

            Console.WriteLine("Bem-vindo ao Jogo da Forca!");
            Console.WriteLine("\nVocê tem 6 tentativas para adivinhar a palavra.");
            Console.WriteLine("A palavra tem " + palavraEscolhida.Length + " letras.");
            Metodos.ExibirPalavraOculta(palavraOculta);

            while (tentativas > 0 && new string(palavraOculta) != palavraEscolhida)
            {
                try
                {
                    char letra = Metodos.PedirLetra();
                    bool acertou = Metodos.VerificarLetra(palavraEscolhida, letra, ref palavraOculta);

                    if (acertou)
                    {
                        Console.WriteLine("Boa! Você acertou uma letra.");
                    }
                    else
                    {
                        tentativas--;
                        Console.WriteLine("A letra não está na palavra. Tentativas restantes: " + tentativas);
                    }

                    Metodos.ExibirPalavraOculta(palavraOculta);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Metodos.FinalizarJogo(palavraEscolhida, palavraOculta);
        }
        #endregion

        #region Questão 8: Gerador de Tabuada Personalizado
        //Crie um programa que gera a tabuada de um número fornecido pelo usuário.
        //O programa deve:

        //Solicitar ao usuário um número inteiro entre 1 e 10. 
        //Validar se o número está dentro do intervalo permitido.
        //Gerar a tabuada do número, exibindo os resultados de 1 a 10. 
        //Tratar exceções para entradas inválidas (números fora do intervalo, caracteres não numéricos, etc.). 
        //Permitir que o usuário gere outra tabuada ou encerre o programa.

        public void GeradorTabuadaPersonalizada()
        {
            try
            {
                Console.WriteLine("Programa para gerar tabuada personalizada!");
                while (true)
                {
                    int numero;

                    Console.Write("\nDigite um número entre 1 e 10 para gerar a tabuada: ");
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
                        string resposta;
                        while (true)
                        {
                            Console.Write("Deseja gerar outra tabuada? (s/n): ");
                            resposta = Console.ReadLine().ToLower();

                            if (resposta == "s" || resposta == "n")
                            {
                                break; // Sai do loop quando a resposta for válida
                            }
                            else
                            {
                                Console.WriteLine("Resposta inválida! Por favor, digite 's' para sim ou 'n' para não.");
                            }
                        }

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
                    catch (ArgumentOutOfRangeException)
                    {
                        //Captura exceção caso o número não esteja no intervalo permitido
                        Console.WriteLine("Digite um valor dentro do intervalo especificado, 1 a 10.");
                    }
                }
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Desafio Alura - Criação de PodCast
        
        public void CriarPodCast()
        {
            try
            {
                var metodos = new Metodos();
                Podcast podcast = new("SemLógica - Novo podcast para falar dos perrengues na Tecnologia", "Van");
                Episodio episodioEscolhido = null;

                bool continuar = true;

                while (continuar)
                {
                    Console.Clear();
                    Console.WriteLine("***MENU PRINCIPAL***");
                    Console.WriteLine("1. Adicionar Episódio. ");
                    Console.WriteLine("2. Escolher Episódio. ");
                    Console.WriteLine("3. Adicionar Convidado. ");
                    Console.WriteLine("4. Listar Convidados. ");
                    Console.WriteLine("5. Listar Episódios. ");
                    Console.WriteLine("6. Sair. ");
                    Console.Write("Escolha uma opção: ");

                    int opcao;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out opcao) && opcao >= 1 && opcao <= 6)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Opção inválida! Por favor, escolha um número entre 1 e 6.");
                            Console.Write("Escolha uma opção: ");
                        }
                    }

                    switch (opcao)
                    {
                        case 1:
                            Metodos.AdicionarEpisodio(podcast);
                            break;
                        case 2:
                            episodioEscolhido = Metodos.EscolherEpisodio(podcast);
                            break;
                        case 3:
                            if (episodioEscolhido != null)
                                Metodos.AdicionarConvidado(episodioEscolhido);
                            else
                                Console.WriteLine("Escolha um episódio primeiro.");
                            break;
                        case 4:
                            if (episodioEscolhido != null)
                                Metodos.ListarConvidados(episodioEscolhido);
                            else
                                Console.WriteLine("Escolha um episódio primeiro.");
                            break;
                        case 5:
                            Metodos.ListarEpisodios(podcast);
                            break;
                        case 6:
                            continuar = false;
                            Console.WriteLine("Você está saindo do PodCast. Pressione qualquer tecla e até logo!");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                }
            }
            catch (Exception) { throw; }
        }



        #endregion






























        #endregion

    }
}






