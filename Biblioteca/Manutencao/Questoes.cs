using Biblioteca.Classes;
using Biblioteca.Validacao;
using System.Globalization;

namespace Biblioteca.Manutencao
{
    public class Questoes
    {
        #region Apresentação
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
        //Questão 1: Como posso criar um jogo simples de adivinhação em C# onde o usuário tenha
        //5 tentativas para adivinhar um número secreto entre 1 e 100?
        //Regras
        //Caso o palpite não seja um valor válido, não deve ser contado como tentativa
        //Se o palpite for maior que o número secreto: mostre uma mensagem personalizada;
        //Se o palpite for menor que o número secreto: mostre uma mensagem personalizada;
       


        //Questão 2: Crie um programa que leia uma lista de números inteiros do usuário
        //e classifique-os em positivos, negativos e zeros.



        //Questão 3: Validação de Senha:
        //Implemente um sistema de validação de senha que exige pelo menos 8 caracteres,
        //pelo menos uma letra maiúscula,
        //uma letra minúscula
        //e um caractere especial.
        //O programa deve informar se a senha fornecida atende aos critérios.
        //Regras: Utilize método para validar a senha inserida.



        //Questão 4: Calculadora com Operações Avançadas:
        //Desenvolva uma calculadora que permita ao usuário realizar operações básicas(adição, subtração, multiplicação, divisão)
        //e operações avançadas(potenciação, raiz quadrada)
        //com base em escolhas feitas usando um menu e estruturas de controle(switch/case).



        //Questão 5: Validação de CPF
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



        //Questão 6: Simulador de Caixa Eletrônico*
        //Crie um simulador de caixa eletrônico que permite ao usuário sacar dinheiro.O programa deve:
        //1. Solicitar o valor do saque.
        //2. Verificar se o valor é múltiplo de 10 (já que o caixa só trabalha com notas de 10, 20, 50 e 100).
        //3. Calcular a quantidade de notas necessárias para o saque, priorizando as notas de maior valor.
        //4. Tratar exceções para valores inválidos (negativos, não múltiplos de 10, etc.).



        //Questão 7: Jogo da Forca
        //Crie um jogo da forca em que o programa escolhe uma palavra aleatória de uma lista
        //e o usuário tenta adivinhar a palavra, letra por letra.
        //O usuário tem 6 tentativas para acertar a palavra.
        //O programa deve:
        //1. Exibir o progresso do usuário(letras acertadas e letras faltando).
        //2. Contar as tentativas restantes.
        //3. Tratar exceções para entradas inválidas (mais de uma letra, caracteres não alfabéticos, etc.).



        //Questão 8: Gerador de Tabuada Personalizado
        //Crie um programa que gera a tabuada de um número fornecido pelo usuário.O programa deve:
        //1. Solicitar ao usuário um número inteiro entre 1 e 10.
        //2. Validar se o número está dentro do intervalo permitido.
        //3. Gerar a tabuada do número, exibindo os resultados de 1 a 10.
        //4. Tratar exceções para entradas inválidas (números fora do intervalo, caracteres não numéricos, etc.).
        //5. Permitir que o usuário gere outra tabuada ou encerre o programa.



        //Questão 9: Validação de CNPJ
        //Crie um programa que valida um CNPJ(Cadastro Nacional da Pessoa Jurídica) de acordo com as regras oficiais.
        //O CNPJ deve ter 14 dígitos, e os dois últimos dígitos são verificadores, calculados com base nos 12 primeiros dígitos.
        //O programa deve permitir que o usuário insira o CNPJ e informe se ele é válido ou inválido.
        //Regras de Validação de CNPJ:
        //1. O CNPJ deve ter 14 dígitos.
        //2. Os dois últimos dígitos são verificadores, calculados com base nos 12 primeiros dígitos.
        //3. O cálculo dos dígitos verificadores é semelhante ao do CPF, mas com pesos diferentes:
        //    - Para o **primeiro dígito verificador**, os pesos são: 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2.
        //    - Para o **segundo dígito verificador**, os pesos são: 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2.



        #endregion
    }
}

