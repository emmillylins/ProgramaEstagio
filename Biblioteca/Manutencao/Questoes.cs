using Biblioteca.Classes;
using Biblioteca.Validacao;
using System.Globalization;
using System.Runtime.Intrinsics.X86;

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

                List<Classes.Usuario> usuarios = new List<Classes.Usuario>();
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

        //Como posso criar um jogo simples de adivinhação em C# onde o usuário tenha 5 tentativas para adivinhar um
        // número secreto entre 1 e 100?
        //Regras:
        //Caso o palpite não seja um valor válido, não deve ser contado como tentativa
        //Se o palpite for maior que o número secreto: mostre uma mensagem personalizada;
        // Se o palpite for menor que o número secreto: mostre uma mensagem personalizada;


        public void JogoNumeroAdvinhação()
        {
            try
            {
                // numeros aleatórios 
                Random rand = new Random();
                int numeroSecreto = rand.Next(1, 101);

                // mensagem de inicio do jogo 
                Console.WriteLine("Seja bem-vindo ao jogo do número secreto!! ");
                Console.WriteLine("Insira um número de 1 a 100: ");

                // for para a repetição de tentativas do usuário 
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"Insira o {i}° número: ");

                    // input mais validação caso insira algum texto ou números fora dos parâmetros desejados
                    if (!int.TryParse(Console.ReadLine(), out int numeroChute) || numeroChute < 0 || numeroChute > 100)
                    {
                        Console.WriteLine("Insira uma tentativa válida dentro dos parâmentros esperados (1-100)!");
                        i--;
                    }
                    // validação em relação aos chutes do usuario e o numero secreto
                    if (numeroChute == numeroSecreto)
                    {
                        Console.WriteLine($"Parabéns!! você acertou o numero secreto com {i} tentativas!!");
                        return;
                    }
                    else if (numeroChute < numeroSecreto)
                    {
                        Console.WriteLine("O número secreto é maior!");
                    }
                    else
                    {
                        Console.WriteLine("O número secreto é menor!");
                    }

                }
                // mensagem final do jogo
                Console.WriteLine($"Você não conseguiu acertar! o numero secreto era: {numeroSecreto}");




            }
            catch (Exception) { throw; }
        }
        //Crie um programa que leia uma lista de números inteiros do usuário e classifique-os em positivos, negativos e zeros.  

        public void ListaNumeros()
        {
            try
            {

                //instância para os metodos 
                var metodos = new Metodos();

                //lista
                List<int> numeros = new List<int>();

                //mensagem 
                Console.WriteLine("Programa que mostra os tipos de números inseridos em uma lista! ");

                // loop para que o usuario insira o quanto quiser por isso while 
                while (true)
                {

                    Console.WriteLine("\n1-Insira um número\n2-Mostrar números\n3-Sair");
                    // vaidação e input da opção do usuario 
                    if (!int.TryParse(Console.ReadLine(), out int opcao))
                    {
                        Console.WriteLine("Insira apenas as opções mostradas!! ");
                        continue;
                    }
                    // switch case para as devidas opçãos inseridasd
                    switch (opcao)
                    {
                        case 1:
                            metodos.InserirNumeroLista(numeros);
                            break;
                        case 2:
                            metodos.MostrarNumerosLista(numeros);
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("\nInsira apenas uma das opções mostradas: ");
                            break;

                    }
                }
            }
            catch (Exception) { throw; }





        }
        // Validação de Senha:
        //Implemente um sistema de validação de senha que exige pelo menos 8 caracteres,
        //pelo menos uma letra maiúscula, uma letra minúscula e um caractere especial.
        //O programa deve informar se a senha fornecida atende aos critérios.
        //Regras: Utilize método para validar a senha inserida.

        public void CadastrarSenha()
        {
            try
            {
                // instancias 
                var validacao = new Validacoes();
                var metodos = new Metodos();
                // for 
                while (true)
                {
                    // opções 
                    Console.WriteLine("\nValidador de senha!");
                    Console.WriteLine("\nEscolha uma das opções: ");
                    Console.WriteLine("\n1 -Cadastrar Senha: ");
                    Console.WriteLine("2- Sair");
                    // validacao
                    if (!int.TryParse(Console.ReadLine(), out int opcao))
                    {
                        Console.WriteLine("Insira apenas umas das opções mostradas!");
                        continue;
                    }
                    switch (opcao)
                    {
                        case 1:
                            metodos.ValidarSenha();
                            break;
                        case 2:
                            Console.WriteLine("Saindo do programa...");
                            return;

                        default:
                            Console.WriteLine("Insira apenas uma das opções mostradas");
                            break;
                    }
                }
            }
            catch (Exception) { throw; }
        }
        // Calculadora com Operações Avançadas:
        //Desenvolva uma calculadora que permita ao usuário realizar 7
        //operações básicas(adição, subtração, multiplicação, divisão) e operações avançadas(potenciação, raiz quadrada)
        //com base em escolhas feitas usando um menu e estruturas de controle(switch/case).

        public void CalculadoraAvancada()

        {
            var metodos = new Metodos();
            try
            {
                Console.WriteLine("Bem vindos a calculadora avançada!!");
                while (true)
                {
                    Console.WriteLine("\nInsira uma das opções: ");
                    Console.WriteLine("\n1- Soma");
                    Console.WriteLine("2- Subtração");
                    Console.WriteLine("3- Divisão");
                    Console.WriteLine("4- Multiplicação");
                    Console.WriteLine("5- Potenciação");
                    Console.WriteLine("6- Raiz Quadrada");
                    Console.WriteLine("7- Sair");

                    if (!int.TryParse(Console.ReadLine(), out int opcao))
                    {
                        Console.WriteLine("Insira apenas as opções inseridas!!");
                    }

                    switch (opcao)
                    {
                        case 1:
                            metodos.Soma();
                            break;
                        case 2:
                            metodos.Subtração();
                            break;
                        case 3:
                            metodos.Divisao();
                            break;
                        case 4:
                            metodos.Multiplicacao();
                            break;
                        case 5:
                            metodos.Potenciacao();
                            break;
                        case 6:
                            metodos.RaizQuadradada();
                            break;
                        case 7:
                            return;
                        default:
                            Console.WriteLine("Insira uma opção válida");
                            break;

                    }

                }
            }
            catch (Exception) { throw; }



        }
        //Crie um programa que solicita ao usuário um CPF e
        //valida se ele está no formato correto (11 dígitos numéricos). O programa deve permitir que o
        //usuário tente novamente caso o formato esteja incorreto.
        //Utilize tratamento de exceções para garantir que o CPF contenha apenas números e tenha o tamanho correto.
        public void Cpf()
        {
            var metodos = new Metodos();
            try
            {


                Console.WriteLine("Programa que valida CPF");

                Console.WriteLine("\nInsira seu CPF: ");


                string cpf = Console.ReadLine();

                metodos.ValidarCpf(cpf);

            }
            catch (Exception) { throw; }



        }


        //Crie um simulador de caixa eletrônico que permite ao usuário sacar dinheiro.
        //O programa deve:
        //Solicitar o valor do saque.
        //Verificar se o valor é múltiplo de 10 (já que o caixa só trabalha com notas de 10, 20, 50 e 100).
        //Calcular a quantidade de notas necessárias para o saque, priorizando as notas de maior valor.
        //Tratar exceções para valores inválidos (negativos, não múltiplos de 10, etc.).

        public void CaixaEletronico()
        {
            var validacao = new Validacoes();

            try
            {
                // array para armazenar os tipo de nota 
                int[] cedulas = [100, 50, 20, 10];
                // armazena quuantas vezes foi usada

                int[] quantidade = new int[cedulas.Length];

                Console.WriteLine("Bem vindo ao caixa eletrônico");
                // inserção do saque do usuario 
                Console.WriteLine("Insira o valor do saque: ");
                if (!int.TryParse(Console.ReadLine(), out int saque) || saque < 0)
                {
                    Console.WriteLine("Insira apenas valores válidos!!");

                }
                // validação
                if (!validacao.VerificarMultiploDez(saque))
                {
                    Console.WriteLine("Trabalhamos apenas com multiplos de 10");
                    return;
                }
                else
                {

                    // calculo 
                    for (int i = 0; i < cedulas.Length; i++)
                    {
                        quantidade[i] = saque / cedulas[i];
                        saque = saque % cedulas[i];
                    }
                    Console.WriteLine("Cedulas fornecidas");
                    for (int i = 0; i < quantidade.Length; i++)
                    {
                        if (quantidade[i] > 0)
                        {
                            Console.WriteLine($"Notas de {cedulas[i]}: {quantidade[i]} ");
                        }
                    }


                }
            }
            catch (Exception) { throw; }
        }
        public void Tabuada()
        {
            while (true)
            {
                try
                {
                    var metodos = new Metodos();

                    Console.WriteLine("Bem vindo a Tabuada!! ");



                    Console.WriteLine("\nInsira uma das opções\n1-Inserir tabuada\n2-Sair");

                    if (!int.TryParse(Console.ReadLine(), out int opcao))
                    {
                        Console.WriteLine("Insira uma das opções mostradas");
                    }
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("\nInsira a tabuada desejada entre 1 e 10:   ");
                            metodos.Tabuada();
                            break;
                        case 2:
                            Console.WriteLine("Saindo do programa...");
                            return;
                        default:
                            Console.WriteLine("Insira umas das opções mostradas!");
                            break;


                    }

                }
                catch (Exception) { throw; }
            }
        }



        //Crie um jogo da forca em que o programa escolhe uma palavra aleatória de uma lista
        //e o usuário tenta adivinhar a palavra, letra por letra.O usuário tem 6 tentativas para acertar a palavra.
        //O programa deve:
        // Exibir o progresso do usuário(letras acertadas e letras faltando).
        //Contar as tentativas restantes.
        //Tratar exceções para entradas inválidas(mais de uma letra, caracteres não alfabéticos, etc.).

        public void JogoForca()
        {
            var validacao = new Validacoes();
            var metodos = new Metodos();
            try
            {
                List<String> palavrasJogoForca = ["Almoço", "Garota", "Gato", "Dado", "Prato"];

                Console.WriteLine("Bem vindos ao jogo da Forca!!");

                metodos.ValidarEntradaUsuario();




            }
            catch (Exception) { throw; }



        }

        public void Cnpj()
        {
            var metodos = new Metodos();
            try
            {
                Console.WriteLine("Validador CNPJ!");

                Console.WriteLine("\nInsira um CNPJ para a validação: ");
                String? cnpj = Console.ReadLine();

                metodos.ValidarCnpj(cnpj);

            }
            catch (Exception) { throw; }






        }
    }
}

