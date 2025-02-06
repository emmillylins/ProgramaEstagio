using Biblioteca.Classes;
using Biblioteca.Validacao;
using System.Globalization;

namespace Biblioteca.Manutencao
{
    public class Questoes
    {
        #region Apresentação 31/01
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
                var metodos = new Metodos();
                Console.WriteLine("Programa que simula um caixa eletrônico.");

                var saldos = new List<double> { saldoInicial };
                while (true)
                {
                    Console.WriteLine("\nEscolha uma opção:");
                    Console.WriteLine("1. Depositar" +
                                    "\n2. Sacar" +
                                    "\n3. Ver saldo" +
                                    "\n4. Sair");

                    Console.Write("\nSua opção: ");

                    if (!int.TryParse(Console.ReadLine(), out int opcao))
                        Console.WriteLine("\nDigite um valor válido.");
                    else
                    {
                        switch (opcao)
                        {
                            case 1:
                                var deposito = metodos.Depositar();
                                if (deposito > 0)
                                {
                                    saldos.Add(deposito);
                                    Console.WriteLine($"\nSeu saldo atual é de: {saldos.Sum():F2}");
                                }
                                break;
                            case 2:
                                var saldoComSaque = metodos.Sacar(saldos);
                                if (saldoComSaque is not null)
                                {
                                    saldos = saldoComSaque;
                                    Console.WriteLine($"\nSeu saldo atual é de: {saldos.Sum():F2}");
                                }
                                break;
                            case 3:
                                Console.WriteLine($"\nSeu saldo atual é de: {saldos.Sum():F2}");
                                break;
                            case 4:
                                Console.WriteLine("\nSaindo...");
                                return;
                            default:
                                Console.WriteLine("\nDigite uma opção válida.");
                                break;
                        }
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
        public void CadastroProdutos()
        {
            try
            {
                var metodos = new Metodos();

                double valorTotal = 0;
                List<Produto> produtos = [];

                Console.WriteLine("Programa de cadastro de produtos e cálculo de total.");

                while (true)
                {
                    Console.WriteLine("\nEscolha uma opção:");
                    Console.WriteLine("1. Cadastrar produto\n2. Sair");
                    Console.Write("\nSua opção: ");

                    if (!int.TryParse(Console.ReadLine(), out int opcao))
                        Console.WriteLine("\nDigite um valor válido.");
                    else
                    {
                        switch (opcao)
                        {
                            case 1:
                                var produto = metodos.CadastrarProduto();
                                if (produto is not null)
                                {
                                    produtos.Add(produto);
                                    valorTotal += produto.Preco;
                                }
                                break;
                            case 2:
                                metodos.ListarProdutos(produtos, valorTotal);
                                return;
                            default:
                                Console.WriteLine("\nDigite uma opção válida.");
                                break;
                        }
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
        public void GerenciarNotas()
        {
            try
            {
                var i = 1;
                var metodos = new Metodos();
                var alunos = new List<Aluno>();

                Console.WriteLine("Sistema de gerenciamento de alunos e notas.");
                while (true)
                {
                    Console.WriteLine("\nEscolha uma opção:");
                    Console.WriteLine("1. Cadastrar aluno" +
                                    "\n2. Exibir aluno" +
                                    "\n3. Exibir aluno por Id" +
                                    "\n4. Sair");
                    Console.Write("\nSua opção: ");

                    if (!int.TryParse(Console.ReadLine(), out int opcao))
                        Console.WriteLine("\nDigite um valor válido.");
                    else
                    {
                        switch (opcao)
                        {
                            case 1:
                                var aluno = metodos.CadastrarAluno();
                                if (aluno is not null)
                                {
                                    aluno.Id = i;
                                    alunos.Add(aluno);
                                }
                                break;
                            case 2:
                                metodos.ExibirALunos(alunos);
                                break;
                            case 3:
                                metodos.ExibirALunosPorId(alunos);
                                break;
                            case 4:
                                return;
                            default:
                                Console.WriteLine("\nDigite uma opção válida.");
                                break;
                        }
                    }
                }
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Teste 3

        #region Questão 1: Jogo de adivinhação
        //Crie um programa onde o usuário tenha 5 tentativas para adivinhar um número secreto entre 1 e 100
        //Regras
        //Caso o palpite não seja um valor válido, não deve ser contado como tentativa
        //Se o palpite for maior que o número secreto: mostre uma mensagem personalizada;
        //Se o palpite for menor que o número secreto: mostre uma mensagem personalizada;
        public void JogoAdivinhacao()
        {
            try
            {
                Random random = new Random();
                int numeroSecreto = random.Next(1, 101);
                int tentativas = 5;
                bool acertou = false;
                Console.WriteLine("Jogo de Adivinhação! Tente adivinhar o número entre 1 e 100.");

                for (int i = 0; i < tentativas; i++)
                {
                    Console.Write("\nDigite seu palpite: ");
                    if (!int.TryParse(Console.ReadLine(), out int palpite))
                    {
                        Console.WriteLine("\nPor favor, digite um número válido.");
                        i--; // Não contar tentativa inválida
                        continue;
                    }
                    if (palpite < numeroSecreto)
                    {
                        Console.WriteLine("\nTente um número maior.");
                    }
                    else if (palpite > numeroSecreto)
                    {
                        Console.WriteLine("\nTente um número menor.");
                    }
                    else
                    {
                        Console.WriteLine("\nParabéns! Você acertou!");
                        acertou = true;
                        break;
                    }
                }
                if (!acertou)
                {
                    Console.WriteLine($"Você perdeu! O número era {numeroSecreto}.");
                }
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Questão 2: Programa que lê uma lista de números inteiros do usuário
        //Crie um programa que leia uma lista de números inteiros do usuário 
        //classifique-os em positivos, negativos e zeros.
        public void ClassificaNumeros()
        {
            try
            {
                List<int> positivos = [], negativos = [], zeros = [];

                Console.WriteLine("Programa que lê uma lista de números inteiros do usuário");

                Console.Write("\nDigite números separados por espaço: ");
                string[] entradas = Console.ReadLine().Split(' ');

                for (int i = 0; i < entradas.Length; i++)
                {
                    int numero;
                    while (!int.TryParse(entradas[i], out numero))
                    {
                        Console.Write($"\nErro: '{entradas[i]}' não é um número válido." +
                                       "\nDigite um número válido para substituí-lo: ");
                        entradas[i] = Console.ReadLine();
                    }

                    if (numero > 0)
                        positivos.Add(numero);
                    else if (numero < 0)
                        negativos.Add(numero);
                    else
                        zeros.Add(numero);
                }

                Console.WriteLine("\nNumeros classificados:");
                Console.WriteLine($"Positivos: {string.Join(", ", positivos)}");
                Console.WriteLine($"Negativos: {string.Join(", ", negativos)}");
                Console.WriteLine($"Zeros: {string.Join(", ", zeros)}");
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Questão 3: Validação de Senha
        //Implemente um sistema de validação de senha que exige pelo menos 8 caracteres,
        //pelo menos uma letra maiúscula,
        //uma letra minúscula
        //e um caractere especial.
        //O programa deve informar se a senha fornecida atende aos critérios.
        //Regras: Utilize método para validar a senha inserida.
        public void ValidaSenha()
        {
            try
            {
                var validacoes = new Validacoes();

                Console.WriteLine("Programa de validação de senha\n");

                Console.Write("Digite uma senha: ");
                var senha = Console.ReadLine();

                if (validacoes.ValidarSenha(senha))
                    Console.WriteLine("Senha válida!");
                else
                    Console.WriteLine("Senha inválida! A senha deve conter pelo menos 8 caracteres, " +
                        "uma letra maiúscula, uma letra minúscula e um caractere especial.");
            }
            catch (Exception) { throw; };
        }
        #endregion

        #region Questão 4: Calculadora com Operações Avançadas
        //Desenvolva uma calculadora que permita ao usuário realizar operações básicas(adição, subtração, multiplicação, divisão)
        //e operações avançadas(potenciação, raiz quadrada)
        //com base em escolhas feitas usando um menu e estruturas de controle(switch/case).
        public void CalculadoraAvancada()
        {
            try
            {
                var metodos = new Metodos();

                Console.WriteLine("Programa que permite ao usuário realizar operações de calculadora.\n");

                Console.WriteLine("Escolha uma operação:");
                Console.WriteLine("1 - Adição (+)");
                Console.WriteLine("2 - Subtração (-)");
                Console.WriteLine("3 - Multiplicação (*)");
                Console.WriteLine("4 - Divisão (/)");
                Console.WriteLine("5 - Potenciação (^)");
                Console.WriteLine("6 - Raiz Quadrada (√)");

                if (int.TryParse(Console.ReadLine(), out int opcao) && opcao >= 1 && opcao <= 6)
                    metodos.CalculaNumeros(opcao);
                else
                    Console.WriteLine("Opção inválida!");

            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Questão 5: Validação de CPF
        //Crie um programa que solicita ao usuário um CPF e valida se ele está no formato correto(11 dígitos numéricos).
        //O programa deve permitir que o usuário tente novamente caso o formato esteja incorreto.
        //Uilize tratamento de exceções para garantir que o CPF contenha apenas números e tenha o tamanho correto.
        //Regras de Validação de CPF
        //1. O CPF deve ter 11 dígitos.
        //2. Os dois últimos dígitos são verificadores, calculados com base nos 9 primeiros dígitos.
        //3. O cálculo dos dígitos verificadores é feito da seguinte forma:
        //    - Para o **primeiro dígito verificador**:
        //        - Multiplica-se cada um dos 9 primeiros dígitos por um peso que começa em 10 e diminui até 2.
        //        - Soma-se os resultados.
        //        - O dígito verificador é o resto da divisão dessa soma por 11. Se o resto for menor que 2, o dígito é 0;
        //        caso contrário, é 11 menos o resto.
        //    - Para o **segundo dígito verificador**:
        //        - Multiplica-se cada um dos 10 primeiros dígitos(9 originais + primeiro dígito verificador)
        //        por um peso que começa em 11 e diminui até 2.
        //        - Soma-se os resultados.
        //        - O dígito verificador é o resto da divisão dessa soma por 11. Se o resto for menor que 2, o dígito é 0;
        //        caso contrário, é 11 menos o resto.
        public void ValidaCpf()
        {
            try
            {
                var metodos = new Metodos();
                var validacoes = new Validacoes();
                bool cpfValido = false;

                Console.WriteLine("Programa que solicita ao usuário um CPF e valida se ele está no formato correto.");

                while (!cpfValido)
                {
                    try
                    {
                        Console.Write("\nDigite o CPF (apenas números): ");
                        var cpf = Console.ReadLine();

                        validacoes.ValidacaoBasicasCpf(cpf);

                        // Calcula os dígitos verificadores
                        int[] digitos = new int[11];
                        for (int i = 0; i < 11; i++)
                        {
                            digitos[i] = int.Parse(cpf[i].ToString());
                        }

                        int primeiroDigitoVerificador = metodos.CalcularDigitoVerificador(digitos, 10);
                        int segundoDigitoVerificador = metodos.CalcularDigitoVerificador(digitos, 11);

                        // Verifica se os dígitos verificadores estão corretos
                        if (digitos[9] == primeiroDigitoVerificador && digitos[10] == segundoDigitoVerificador)
                        {
                            cpfValido = true;
                            Console.WriteLine("CPF válido!");
                        }
                        else
                            throw new Exception("CPF inválido. Dígitos verificadores incorretos.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                    }
                }
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Questão 6: Simulador de Caixa Eletrônico
        //Crie um simulador de caixa eletrônico que permite ao usuário sacar dinheiro.O programa deve:
        //1. Solicitar o valor do saque.
        //2. Verificar se o valor é múltiplo de 10 (já que o caixa só trabalha com notas de 10, 20, 50 e 100).
        //3. Calcular a quantidade de notas necessárias para o saque, priorizando as notas de maior valor.
        //4. Tratar exceções para valores inválidos (negativos, não múltiplos de 10, etc.).
        public void SimuladorCaixaEletronico()
        {
            int[] notas = { 100, 50, 20, 10 };
            bool saqueRealizado = false;

            Console.WriteLine("Programa que simula um caixa eletônico.");

            while (!saqueRealizado)
            {
                try
                {
                    Console.Write("\nDigite o valor do saque (múltiplo de 10): ");
                    int valor = int.Parse(Console.ReadLine());

                    if (valor <= 0) throw new Exception("\nValor inválido. O saque deve ser maior que zero.");
                    if (valor % 10 != 0) throw new Exception("\nValor inválido. O saque deve ser múltiplo de 10.");

                    Console.WriteLine("\nNotas necessárias:");
                    for (int i = 0; i < notas.Length; i++)
                    {
                        int quantidade = valor / notas[i];
                        if (quantidade > 0)
                        {
                            Console.WriteLine($"{quantidade} nota(s) de {notas[i]}");
                            valor = valor % notas[i];
                        }
                    }
                    saqueRealizado = true;
                }
                catch (FormatException) { throw new Exception("Erro: Entrada inválida. Digite apenas números."); }
                catch (Exception) { throw; }
            }
        }
        #endregion

        #region Questão 7: Jogo da Forca
        //Crie um jogo da forca em que o programa escolhe uma palavra aleatória de uma lista
        //e o usuário tenta adivinhar a palavra, letra por letra.
        //O usuário tem 6 tentativas para acertar a palavra.
        //O programa deve:
        //1. Exibir o progresso do usuário(letras acertadas e letras faltando).
        //2. Contar as tentativas restantes.
        //3. Tratar exceções para entradas inválidas (mais de uma letra, caracteres não alfabéticos, etc.).
        public void JogoForca()
        {
            List<string> palavras = ["banana", "computador", "elefante", "girassol", "programacao"];
            Random random = new();
            string palavra = palavras[random.Next(palavras.Count)];
            char[] palavraEscondida = new string('_', palavra.Length).ToCharArray();
            int tentativasRestantes = 6;
            HashSet<char> letrasTentadas = [];

            Console.WriteLine("Bem-vindo ao Jogo da Forca!");

            while (tentativasRestantes > 0 && new string(palavraEscondida) != palavra)
            {
                try
                {
                    Console.WriteLine($"\nPalavra: {new string(palavraEscondida)}");
                    Console.WriteLine($"Tentativas restantes: {tentativasRestantes}");
                    Console.Write("\nDigite uma letra: ");
                    char letra = Console.ReadLine()!.ToLower()[0];

                    if (letrasTentadas.Contains(letra))
                        throw new Exception("\nLetra já tentada. Tente outra.");

                    if (!char.IsLetter(letra))
                        throw new Exception("\nEntrada inválida. Digite apenas letras.");

                    letrasTentadas.Add(letra);

                    if (palavra.Contains(letra))
                    {
                        for (int i = 0; i < palavra.Length; i++)
                        {
                            if (palavra[i] == letra)
                            {
                                palavraEscondida[i] = letra;
                            }
                        }
                    }
                    else
                    {
                        tentativasRestantes--;
                        Console.WriteLine("\nLetra incorreta!");
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

            if (new string(palavraEscondida) == palavra)
                Console.WriteLine($"Parabéns! Você acertou a palavra: {palavra}");
            else
                Console.WriteLine($"Você perdeu! A palavra era: {palavra}");
        }
        #endregion

        #region Questão 8: Gerador de Tabuada Personalizado
        //Crie um programa que gera a tabuada de um número fornecido pelo usuário.O programa deve:
        //1. Solicitar ao usuário um número inteiro entre 1 e 10.
        //2. Validar se o número está dentro do intervalo permitido.
        //3. Gerar a tabuada do número, exibindo os resultados de 1 a 10.
        //4. Tratar exceções para entradas inválidas (números fora do intervalo, caracteres não numéricos, etc.).
        //5. Permitir que o usuário gere outra tabuada ou encerre o programa.
        public void GeradorTabuada()
        {
            var metodos = new Metodos();
            bool executando = true;

            while (executando)
            {
                try
                {
                    Console.Write("Digite um número entre 1 e 10 para gerar a tabuada (ou 'sair' para encerrar): ");
                    string entrada = Console.ReadLine();

                    if (entrada.ToLower() == "sair")
                    {
                        executando = false;
                        Console.WriteLine("Encerrando o programa...");
                        continue;
                    }

                    metodos.CalculaTabuada(entrada);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: Entrada inválida. Digite apenas números ou a palavra 'sair'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }
        #endregion

        #region Questão 9: Validação de CNPJ
        //Crie um programa que valida um CNPJ(Cadastro Nacional da Pessoa Jurídica) de acordo com as regras oficiais.
        //O CNPJ deve ter 14 dígitos, e os dois últimos dígitos são verificadores, calculados com base nos 12 primeiros dígitos.
        //O programa deve permitir que o usuário insira o CNPJ e informe se ele é válido ou inválido.
        //Regras de Validação de CNPJ:
        //1. O CNPJ deve ter 14 dígitos.
        //2. Os dois últimos dígitos são verificadores, calculados com base nos 12 primeiros dígitos.
        //3. O cálculo dos dígitos verificadores é semelhante ao do CPF, mas com pesos diferentes:
        //    - Para o **primeiro dígito verificador**, os pesos são: 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2.
        //    - Para o **segundo dígito verificador**, os pesos são: 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2.
        public void ValidaCnpj()
        {
            var metodos = new Metodos();
            bool cnpjValido = false;

            while (!cnpjValido)
            {
                try
                {
                    Console.Write("Digite o CNPJ (apenas números): ");
                    var cnpj = Console.ReadLine();

                    // Verifica se o CNPJ tem 14 dígitos e contém apenas números
                    if (string.IsNullOrEmpty(cnpj) || cnpj.Length != 14 || !long.TryParse(cnpj, out _))
                    {
                        throw new Exception("\nCNPJ inválido. Deve conter exatamente 14 dígitos numéricos.");
                    }

                    // Verifica se todos os dígitos são iguais (CNPJ inválido)
                    if (metodos.TodosDigitosIguais(cnpj))
                    {
                        throw new Exception("\nCNPJ inválido. Todos os dígitos são iguais.");
                    }

                    // Calcula os dígitos verificadores
                    int[] digitos = new int[14];
                    for (int i = 0; i < 14; i++)
                    {
                        digitos[i] = int.Parse(cnpj[i].ToString());
                    }

                    int primeiroDigitoVerificador = metodos.CalcularDigitoVerificadorCNPJ(digitos, 12);
                    int segundoDigitoVerificador = metodos.CalcularDigitoVerificadorCNPJ(digitos, 13);

                    // Verifica se os dígitos verificadores estão corretos
                    if (digitos[12] == primeiroDigitoVerificador && digitos[13] == segundoDigitoVerificador)
                    {
                        cnpjValido = true;
                        Console.WriteLine("\nCNPJ válido!");
                    }
                    else
                    {
                        throw new Exception("\nCNPJ inválido. Dígitos verificadores incorretos.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }
        #endregion

        #endregion
    }
}

