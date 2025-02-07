using Biblioteca.Classes;
using System.Globalization;


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
            catch (Exception)
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
        public bool VerificarPalpite(int palpite, int numeroSecreto)
        {
            if (palpite == numeroSecreto)
            {
                Console.WriteLine($"\nParabéns! Você acertou, o número secreto era {numeroSecreto}!");
                return true;
            }
            else if (palpite > numeroSecreto)
            {
                Console.WriteLine("O número secreto é menor. Tente novamente.");
            }
            else
            {
                Console.WriteLine("O número secreto é maior. Tente novamente.");
            }
            return false;
        }
        public void AdicionarNumero(List<int> listaNumeros)
        {
            Console.Write("\nDigite o número a ser inserido: ");

            if (!int.TryParse(Console.ReadLine(), out var numero))
            {
                Console.WriteLine("\nInsira apenas números inteiros");
                return;
            }

            listaNumeros.Add(numero);
        }

        public void ExibirNumeroClassificacao(List<int> listaNumeros)
        {
            Console.WriteLine("\nNúmeros e suas classificações");

            if (listaNumeros.Count == 0) { Console.WriteLine("Não possui números na lista"); }
            else
            {
                foreach (int numero in listaNumeros)
                {
                    if (numero > 0)
                    {
                        Console.WriteLine($"O número {numero} é positivo");
                    }
                    else if (numero < 0)
                    {
                        Console.WriteLine($"O número {numero} é negativo");
                    }
                    else
                    {
                        Console.WriteLine($"O número inserido: {numero} é zero");
                    }
                }
            }
        }

        public double Adicao(double a, double b)
        {
            return a + b;
        }

        public double Subtracao(double a, double b)
        {
            return a - b;
        }

        public double Multiplicacao(double a, double b)
        {
            return a * b;
        }

        public double Divisao(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Não é possível realizar a Divisão por zero!");
                return double.NaN; // "Not a Number" em caso de divisão por zero
            }
            return a / b;
        }


        public double Potenciacao(double a, double b)
        {
            return Math.Pow(a, b);
        }

        public double RaizQuadrada(double a)
        {
            if (a < 0)
            {
                Console.WriteLine("Não é possível realizar a Raiz quadrada de número negativo!");
                return double.NaN; // "Not a Number" para raiz de número negativo
            }
            return Math.Sqrt(a);
        }

        // deve ter 11 digitos
        ////Para o primeiro dígito verificador: 
        //Multiplica-se cada um dos 9 primeiros dígitos por um peso que começa em 10 e diminui até 2. 
        //Soma-se os resultados.
        //O dígito verificador é o resto da divisão dessa soma por 11. Se o resto for menor que 2, o dígito é 0;
        //caso contrário, é 11 menos o resto.

        //Para o segundo dígito verificador: 
        //Multiplica-se cada um dos 10 primeiros dígitos(9 originais + primeiro dígito verificador)
        //por um peso que começa em 11 e diminui até 2. 
        //Soma-se os resultados.
        //O dígito verificador é o resto da divisão dessa soma por 11. 
        //Se o resto for menor que 2, o dígito é 0; caso contrário, é 11 menos o resto.

        public bool VerificaCpf(string cpf)
        {
            // converter pra string só agora pra evitar que entrassem letras anteriormente
            // garante 11 letras com zero a esquerda se preciso

            if (cpf.Length != 11)
            {
                Console.WriteLine("\nO CPF deve ter 11 digitos.");
                return false;
            }

            // primeiro digito

            int soma = 0;
            for (int i = 0; i < 9; i++) // passa pelos 9 primeiros digitos
            {
                int digito = int.Parse(cpf[i].ToString()); // pega o digito
                int peso = 10 - i; // peso 10 e vai diminuindo até 2
                soma += digito * peso; // digito vezes peso e adicao com soma
            }

            int resto = soma % 11;
            int digito1;

            if (resto < 2)
            {
                digito1 = 0;
            }
            else
            {
                digito1 = 11 - resto;
            }

            // segundo digito
            soma = 0; // 
            for (int i = 0; i < 10; i++) // passa pelos 10 primeiros digitos
            {
                int digito = int.Parse(cpf[i].ToString());
                int peso = 11 - i; //peso descendo de 11 e diminui até 2)
                soma += digito * peso; //peso x digito e adiciona à soma
            }


            resto = soma % 11;
            int digito2;

            if (resto < 2)
            {
                digito2 = 0;
            }
            else
            {
                digito2 = 11 - resto;
            }

            // verifica se os dígitos verificadores calculados são iguais aos do CPF
            if (int.Parse(cpf[9].ToString()) == digito1 && int.Parse(cpf[10].ToString()) == digito2)
            {
                return true;
            }

            return false;

        }

        //Solicitar o valor do saque.
        //Verificar se o valor é múltiplo de 10 (já que o caixa só trabalha com notas de 10, 20, 50 e 100).
        //Calcular a quantidade de notas necessárias para o saque, priorizando as notas de maior valor.
        //Tratar exceções para valores inválidos (negativos, não múltiplos de 10, etc.).


        public double Sacar(double saldoTotal)
        {
            Console.WriteLine("Digite o valor do saque: ");
            if (!double.TryParse(Console.ReadLine(), out double saque) || saque <= 0)
            {
                Console.WriteLine("Digite um valor válido.");
                return saldoTotal;
            }
            else if (saque > saldoTotal)
            {
                Console.WriteLine("Saldo insuficiente.");
                return saldoTotal;
            }
            else if (saque % 10 != 0)
            {
                Console.WriteLine("O valor do saque deve ser múltiplo de 10.");
                return saldoTotal;
            }
            else
            {
                saldoTotal -= saque;
                Console.WriteLine("Saque realizado com sucesso!");
                ExibirNotas(saque);
                return saldoTotal;
            }
        }

        public void ExibirNotas(double valorSaque)
        {
            int[] notas = new int[] { 100, 50, 20, 10 };
            int[] quantidadeNotas = new int[notas.Length];

            for (int i = 0; i < notas.Length; i++)
            {
                if (valorSaque >= notas[i])
                {
                    quantidadeNotas[i] = (int)(valorSaque / notas[i]);
                    valorSaque %= notas[i];
                }
            }

            if (valorSaque == 0)
            {
                Console.WriteLine("\nNotas necessárias para o saque:");
                for (int i = 0; i < notas.Length; i++)
                {
                    if (quantidadeNotas[i] > 0)
                    {
                        Console.WriteLine($"Notas de {notas[i]}: {quantidadeNotas[i]}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Não foi possível realizar o saque com as notas disponíveis.");
            }
        }



        public void GerarTabuada()
        {
            Console.WriteLine("Digite o número para gerar a tabuada: ");
            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine("Digite um número válido.");
                return;
            }
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{numero} x {i} = {numero * i}");
            }
        }

        //Crie um programa que valida um CNPJ(Cadastro Nacional da Pessoa Jurídica) de acordo com as regras oficiais.
        //O CNPJ deve ter 14 dígitos, e os dois últimos dígitos são verificadores, calculados com base nos 12 primeiros dígitos.
        //O programa deve permitir que o usuário insira o CNPJ e informe se ele é válido ou inválido.

        //Regras de Validação de CNPJ:

        //O CNPJ deve ter 14 dígitos.
        //Os dois últimos dígitos são verificadores, calculados com base nos 12 primeiros dígitos. 
        //O cálculo dos dígitos verificadores é semelhante ao do CPF, mas com pesos diferentes: 
        //Para o primeiro dígito verificador, os pesos são: 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2. 
        //Para o segundo dígito verificador, os pesos são: 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2

        public bool VerificaCnpj(string cnpj)
        {
            List<int> primeiroPeso = new List<int> { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            List<int> segundoPeso = new List<int> { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };


            if (cnpj.Length != 14)
            {
                Console.WriteLine("O CNPJ deve conter 14 dígitos numéricos.");
                return false;
            }

            // Primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 12; i++)
            {
                int digito = int.Parse(cnpj[i].ToString());
                soma += digito * primeiroPeso[i];
            }

            int resto = soma % 11;
            int digito1;
            if (resto < 2)
            {
                digito1 = 0;
            }
            else
            {
                digito1 = 11 - resto;
            }


            // Segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 13; i++)
            {
                int digito = int.Parse(cnpj[i].ToString());
                soma += digito * segundoPeso[i];
            }

            resto = soma % 11;
            int digito2;
            if (resto < 2)
            {
                digito2 = 0;
            }
            else
            {
                digito2 = 11 - resto;
            }

            // Verifica se os dígitos verificadores calculados são iguais aos do CNPJ
            if (int.Parse(cnpj[12].ToString()) == digito1 && int.Parse(cnpj[13].ToString()) == digito2)
            {
                return true;
            }

            return false;
        }




        public void ProcessarTentativa(string palavraEscolhida, char[] progresso, List<char> letrasTentadas, ref int tentativasRestantes)
        {
            while (tentativasRestantes > 0 && progresso.Contains('_'))
            {
                Console.WriteLine($"\nPalavra: {new string(progresso)}");
                Console.WriteLine($"Tentativas restantes: {tentativasRestantes}");
                Console.Write("Digite uma letra: ");
                string entrada = Console.ReadLine().ToLower();

                if (entrada.Length != 1 || !char.IsLetter(entrada[0]))
                {
                    Console.WriteLine("Entrada inválida. Digite apenas uma letra.");
                    continue;
                }

                char letra = entrada[0];

                if (letrasTentadas.Contains(letra))
                {
                    Console.WriteLine("Você já tentou essa letra. Tente outra.");
                    continue;
                }

                letrasTentadas.Add(letra);

                if (palavraEscolhida.Contains(letra))
                {
                    for (int i = 0; i < palavraEscolhida.Length; i++)
                    {
                        if (palavraEscolhida[i] == letra)
                        {
                            progresso[i] = letra;
                        }
                    }
                }
                else
                {
                    tentativasRestantes--;
                    Console.WriteLine("Letra incorreta.");
                }
            }
        }

        public void AdicionarEpisodios()
        {
            

        }
    }
}






