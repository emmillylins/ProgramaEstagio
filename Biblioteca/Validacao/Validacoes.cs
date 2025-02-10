using System.Reflection.PortableExecutable;
using Biblioteca.Classes;

namespace Biblioteca.Validacao
{
    public class Validacoes
    {

        #region Valida número primo
        public bool ValidaNumeroPrimo(int num)
        {
            try
            {
                if (num < 2) return false;

                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        return false; // Se encontrar um divisor, o número não é primo
                    }
                }
                return true; // Se não encontrou divisores, o número é primo
            }
            catch (Exception) { throw; }
        }

        #endregion

        #region Valida número par ou ímpar

        public bool ValidaNumeroParImpar(int numero)
        {
            try
            {
                if (numero % 2 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception) { throw; }
        }

        #endregion

        #region Valida número multiplo de 3
        public bool ValidaMultiplosDeTres(int numero)
        {
            try
            {
                if (numero % 3 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception) { throw; }
        }

        #endregion

        #region Valida número multiplo de 10

        //Validador para saber se número é múltiplo de dez.
        public bool ValidaMultiploDeDez(double valorSaque)
        {
            try
            {
                if (valorSaque % 10 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception) { throw; }
        }

        #endregion

        #region Valida se o usuário existe

        public bool ValidaUsuarioExistente(string login, string senha)
        {
            try
            {
                var usuarioPreCadastrado = new Usuario
                {
                    Nome = "emy",
                    NomeUsuario = "emylinda",
                    Senha = "amogatos"
                };

                if (login == usuarioPreCadastrado.NomeUsuario && senha == usuarioPreCadastrado.Senha)
                    return true;
                else
                    return false;
            }
            catch (Exception) { throw; }
        }

        #endregion

        #region Valida senha
        public bool ValidarSenha(string senha)
        {
            try
            {
                //Verificações se senha possui tamanho maior ou igual a 8.
                if (senha.Length < 8)
                {
                    Console.WriteLine("É necessário que a senha possua ao menos 8 caracteres!");
                    return false;
                }

                //Método Any para percorres todos caracteres da string inserida pelo usuário e verificando se possui letras.
                if (!senha.Any(letras => Char.IsLetter(letras)))
                {
                    Console.WriteLine("É necessário ao menos 1 letra.");
                    return false;
                }

                //Verifica se possui alguma letra maiúscula.
                if (!senha.Any(letras => Char.IsUpper(letras)))
                {
                    Console.WriteLine("É necessário ao menos 1 letra maiúscula.");
                    return false;
                }

                //Verifica se possui alguma letra minúscula.
                if (!senha.Any(letras => Char.IsLower(letras)))
                {
                    Console.WriteLine("É necessário ao menos 1 letra minúscula.");
                    return false;
                }

                //Verifica se possui algum caracter especial.
                if (!senha.Any(letras => Char.IsPunctuation(letras)))
                {
                    Console.WriteLine("É necessário ao menos 1 caracter especial.");
                    return false;
                }

                //Caso não entre em nenhuma das condições acima, senha se enquadra nos critérios e retorna um boolean;
                return true;
            }
            catch (Exception) { throw; }
        }

        #endregion

        #region Valida CPF
        public bool ValidarCpf(string cpf)
        {
            try
            {
                if (cpf.Length < 11 || cpf.Length > 11)
                {
                    Console.WriteLine("O CPF deve possuir 11 caracteres.");
                    return false;
                }
                if (cpf.Any(letras => Char.IsLetter(letras)) || cpf.Any(letras => Char.IsPunctuation(letras)))
                {
                    Console.WriteLine("O CPF só pode possuir números.");
                    return false;
                }
                int[] cpfSeparado = cpf.Select(numeros => (int)Char.GetNumericValue(numeros)).ToArray();
                //Primeira Verificação do Enunciado da questão

                int peso = 10;
                int valorTotalSoma = 0;
                int compararPrimeiroNumero = 0;
                for (int i = 0; i <= (cpfSeparado.Length - 3); i++)
                {
                    int valor = cpfSeparado[i] * peso;
                    valorTotalSoma += valor;
                    peso--;
                }
                if ((valorTotalSoma % 11) < 2)
                {
                    compararPrimeiroNumero = 0;
                }
                else
                {
                    compararPrimeiroNumero = (11 - (valorTotalSoma % 11));
                }

                //Segunda Verificação do Enunciado da questão
                if (compararPrimeiroNumero == cpfSeparado[9])
                {
                    int novoPeso = 11;
                    int novoValorTotalSoma = 0;
                    int compararSegundoNumero = 0;
                    for (int i = 0; i <= (cpfSeparado.Length - 2); i++)
                    {
                        int valor = (cpfSeparado[i]) * novoPeso;
                        novoValorTotalSoma += valor;
                        novoPeso--;
                    }
                    if ((novoValorTotalSoma % 11) < 2)
                    {
                        compararSegundoNumero = 0;
                    }
                    else
                    {
                        compararSegundoNumero = (11 - (novoValorTotalSoma % 11));
                    }

                    //Ultima verificação

                    if (compararPrimeiroNumero == cpfSeparado[9] && compararSegundoNumero == cpfSeparado[10])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else { return false; }
            }
            catch (Exception) { throw; }
        }

        #endregion

        #region Valida CNPJ
        public bool ValidarCnpj(string cnpj)
        {
            try
            {
                int[] pesosPrimeiraVerificacao = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
                int[] pesosSegundaVerificacao = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
                if (!int.TryParse(cnpj, out int a))
                {
                    Console.WriteLine("O CNPJ só pode possuir números.\n");
                    return false;
                }
                else if (cnpj.Length < 14 || cnpj.Length > 14)
                {
                    Console.WriteLine("O CNPJ deve possuir 14 caracteres.\n");
                    return false;
                }
                else
                {
                    int[] cnpjSeparado = cnpj.Select(numeros => (int)Char.GetNumericValue(numeros)).ToArray();
                    //Primeira Verificação do Enunciado da questão
                    int valorSomaPrimeiraVerificacao = 0;
                    int compararPrimeiroNumero = 0;
                    for (int i = 0; i < pesosPrimeiraVerificacao.Length; i++)
                    {
                        int valor = cnpjSeparado[i] * pesosPrimeiraVerificacao[i];
                        valorSomaPrimeiraVerificacao += valor;
                    }
                    if ((valorSomaPrimeiraVerificacao % 11) < 2)
                    {
                        compararPrimeiroNumero = 0;
                    }
                    else
                    {
                        compararPrimeiroNumero = (11 - (valorSomaPrimeiraVerificacao % 11));
                    }

                    //Segunda Verificação do Enunciado da questão
                    if (compararPrimeiroNumero == cnpjSeparado[12])
                    {
                        int novoValorSomaSegundaVerificacao = 0;
                        int compararSegundoNumero = 0;
                        for (int i = 0; i < pesosSegundaVerificacao.Length; i++)
                        {
                            int valor = cnpjSeparado[i] * pesosSegundaVerificacao[i];
                            novoValorSomaSegundaVerificacao += valor;
                        }
                        if ((novoValorSomaSegundaVerificacao % 11) < 2)
                        {
                            compararSegundoNumero = 0;
                        }
                        else
                        {
                            compararSegundoNumero = (11 - (novoValorSomaSegundaVerificacao % 11));
                        }

                        //Ultima verificação

                        if (compararPrimeiroNumero == cnpjSeparado[12] && compararSegundoNumero == cnpjSeparado[13])
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else { return false; }
                }
            }
            catch (Exception) { throw; }

        }
        #endregion
    }
}
