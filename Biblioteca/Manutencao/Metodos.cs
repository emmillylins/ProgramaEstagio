using Biblioteca.Classes;
using System.Globalization;
using System.Text.RegularExpressions;


namespace Biblioteca.Manutencao
{
    public class Metodos
    {
        //Encontrar Maior e Menor Número
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
     

      //Mostrar Usuário
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
      

     //Cadastrar Usuário
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
    

      // Depositar
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


        //Questão 4: Calculadora com Operações Avançadas:
        //Desenvolva uma calculadora que permita ao usuário realizar operações básicas(adição, subtração,
        // multiplicação, divisão) e operações avançadas(potenciação, raiz quadrada) com base em escolhas feitas
        //usando um menu e estruturas de controle(switch/case).





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



        public static void CalcularNotas(decimal valorSaque)
        {
            try
            {
                // Define as notas disponíveis no caixa eletrônico
                int[] notasDisponiveis = { 100, 50, 20, 10 };

                Console.WriteLine($"Você solicitou um saque de R${valorSaque}. A seguir, a quantidade de notas:");

                //Calcula a quantidade de cada nota
                foreach (int nota in notasDisponiveis)
                {
                    int quantidadeNotas = (int)(valorSaque / nota);// Quantidade de notas de determinado valor
                    if (quantidadeNotas > 0)
                    {
                        Console.WriteLine($"{quantidadeNotas} nota(s) de R${nota}");
                        valorSaque -= quantidadeNotas * nota; // Subtrai o valor das notas do saque restante
                    }
                }

                // Caso sobre algum valor não sacado, exibe uma mensagem
                if (valorSaque > 0)
                {
                    Console.WriteLine("Infelizmente não conseguimos realizar o saque com as notas disponíveis.");
                }
                else
                {
                    Console.WriteLine("Saque realizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possível prosseguir, tente novamente mais tarde: {ex.Message}");
            }
        }


        //Questão 7: Jogo da Forca
        // Método para escolher uma palavra aleatória
        public static string EscolherPalavra(string[] palavras)
        {
            Random rand = new Random();
            return palavras[rand.Next(palavras.Length)];
        }

        // Método para criar a palavra oculta
        public static char[] CriarPalavraOculta(int comprimento)
        {
            return new string('_', comprimento).ToCharArray();
        }

        // Método para exibir o progresso da palavra oculta
        public static void ExibirPalavraOculta(char[] palavraOculta)
        {
            Console.WriteLine(new string(palavraOculta));
        }


        // Método para pedir a letra do usuário
        public static char PedirLetra()
        {
            string entrada;
            char letra;

            while (true)
            {
                Console.Write("\nDigite uma letra: ");
                entrada = Console.ReadLine();

                // Verificar se a entrada é válida
                if (entrada.Length == 1 && char.IsLetter(entrada[0]))
                {
                    letra = char.ToLower(entrada[0]); // Converte a letra para minúscula
                    return letra;
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Digite apenas uma letra.");
                }
            }
        }

        // Método para verificar se a letra existe na palavra
        public static bool VerificarLetra(string palavraEscolhida, char letra, ref char[] palavraOculta)
        {
            bool acertou = false;

            for (int i = 0; i < palavraEscolhida.Length; i++)
            {
                if (palavraEscolhida[i] == letra)
                {
                    palavraOculta[i] = letra;
                    acertou = true;
                }
            }

            return acertou;
        }

        // Método para finalizar o jogo e mostrar o resultado
        public static void FinalizarJogo(string palavraEscolhida, char[] palavraOculta)
        {
            if (new string(palavraOculta) == palavraEscolhida)
            {
                Console.WriteLine("Parabéns! Você adivinhou a palavra: " + palavraEscolhida);
            }
            else
            {
                Console.WriteLine("Você perdeu! A palavra era: " + palavraEscolhida);
            }
        }//Questão 9: Validação de CNPJ
         //Crie um programa que valida um CNPJ(Cadastro Nacional da Pessoa Jurídica) de acordo com as regras oficiais.
         //O CNPJ deve ter 14 dígitos, e os dois últimos dígitos são verificadores, calculados com base nos 12 primeiros dígitos.
         //O programa deve permitir que o usuário insira o CNPJ e informe se ele é válido ou inválido.
         //Regras de Validação de CNPJ:
         //O CNPJ deve ter 14 dígitos.
         //Os dois últimos dígitos são verificadores, calculados com base nos 12 primeiros dígitos. 
         //O cálculo dos dígitos verificadores é semelhante ao do CPF, mas com pesos diferentes: 
         //Para o primeiro dígito verificador, os pesos são: 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2. 
         //Para o segundo dígito verificador, os pesos são: 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2


        //Podcast
        //Questão do mestre
        //crie duas classes para manter podcasts e episódios.OK


        //PODCAST
        //O podcast possui um nome, um apresentador e um total de episódios.OK
        //Um podcast nasce com um nome e um apresentador definido.
        //Assim, conforme os episódios forem criados, vamos adicioná-los ao podcast.
        //Um podcast também terá dois métodos, um AdicionarEpisodio() e outro ExibirDetalhes().OK
        //O método ExibirDetalhes() deve mostrar o nome do podcast e o apresentador na primeira linha,
        //Para finalizar, todo episódio possui um método AdicionarConvidados(), que será chamado quantas
        //vezes forem necessárias.
        //Esse é o desafio! O objetivo é colocar tudo o que aprendemos em prática.
        //Isso inclui o construtor, a verificação se o atributo pode ser apenas um atributo ou se precisa
        //ser uma propriedade e também se precisamos utilizar get e set para todos os valores.

        //EPISODIO
        //O episódio deve ter um número, um título, uma duração e um resumo.OK
        //seguido pela lista de episódios ordenados por sequência e por fim o total de episódios.
        //O resumo do episódio será concatenado com os valores de número, título, duração e convidados do episódio.OK
        //
        //
        public static void AdicionarEpisodio(Podcast podcast)
        {
            try
            {

                Console.Clear();
                Console.Write("Número do Episódio: ");
                int numero = int.Parse(Console.ReadLine());

                Console.Write("Título do Episódio: ");
                string titulo = Console.ReadLine();

                Console.Write("Duração do Episódio (em minutos): ");
                int duracao = int.Parse(Console.ReadLine());

                Episodio episodio = new Episodio(numero, duracao * 60000, titulo); // Convertendo para milissegundos

                podcast.AdicionarEpisodio(episodio);

                Console.WriteLine($"Episódio {numero} - {titulo} adicionado com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }
            catch (Exception) { throw; }
        }
        public static Episodio EscolherEpisodio(Podcast podcast)
        {
            try

            {
                if (podcast.TotalEpsodios == 0)
                {
                    Console.WriteLine("Não há episódios adicionados.");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    return null;
                }

                bool continuarEscolhendo = true;
                Episodio episodioEscolhido = null;
                while (continuarEscolhendo)
                {
                    Console.Clear();
                    Console.WriteLine("Escolha um Episódio:");
                    for (int i = 0; i < podcast.TotalEpsodios; i++)
                    {
                        Console.WriteLine($"{i + 1}. Episódio {podcast.EpisodiosList[i].Numero} - {podcast.EpisodiosList[i].Titulo}");
                    }

                    Console.Write("Escolha o número do episódio (ou 0 para voltar ao menu): ");
                    int escolha = int.Parse(Console.ReadLine()) - 1;

                    if (escolha == -1)
                    {
                        continuarEscolhendo = false;
                    }
                    else if (escolha >= 0 && escolha < podcast.TotalEpsodios)
                    {
                        episodioEscolhido = podcast.EpisodiosList[escolha];
                        Console.WriteLine($"Episódio {episodioEscolhido.Numero} - {episodioEscolhido.Titulo} selecionado!");
                        continuarEscolhendo = false;
                    }
                    else
                    {
                        Console.WriteLine("Episódio inválido.");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                    }
                }
                return episodioEscolhido;
            }
            catch (Exception) { throw; }
        }
        public static void ListarConvidados(Episodio episodio)
        {
            try
            {


                Console.Clear();
                if (episodio.TotalConvidados == 0)
                {
                    Console.WriteLine("Este episódio não possui convidados.");
                }
                else
                {
                    Console.WriteLine($"Convidados do Episódio {episodio.Numero}:");
                    foreach (var convidado in episodio.ConvidadosList)
                    {
                        Console.WriteLine($"- {convidado.Nome} ({convidado.Profissao})");
                    }
                }
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }
            catch (Exception) { throw; }
        }

        public static void AdicionarConvidado(Episodio episodio)
        {
            try
            {

                Console.Clear();
                Console.Write("Nome do Convidado: ");
                string nomeConvidado = Console.ReadLine();

                Console.Write("Profissão do Convidado: ");
                string profissaoConvidado = Console.ReadLine();

                Convidado convidado = new Convidado(nomeConvidado, profissaoConvidado);
                episodio.AdicionarConvidado(convidado);

                Console.WriteLine($"Convidado {nomeConvidado} - {profissaoConvidado} adicionado ao Episódio {episodio.Numero}.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();

            }
            catch (Exception) { throw; }

        }


    }
    
}

