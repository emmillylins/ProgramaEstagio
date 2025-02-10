using System.Text.RegularExpressions;
using Biblioteca.Classes;

namespace Biblioteca.Validacao
{
    public class Validacoes
    {
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

        #region Metodo referente a questao do formulário 3 do jogo da adivinhação
        public bool VerificaNumerosIguais(int numeroUsuario, int numeroSecreto)
        {

            if (numeroSecreto == numeroUsuario) 
            {
                Console.WriteLine($"Parabéns o numero é {numeroSecreto} e você inseriu {numeroUsuario}");
                return true;
            }
            else
            {
                if(numeroUsuario > numeroSecreto)
                {
                    Console.WriteLine($"Você errou, você inseriu o número {numeroUsuario}, este valor é maior que o número secreto");

                }
                else 
                {
                    Console.WriteLine($"Você errou, você inseriu o número {numeroUsuario}, este valor é menor que o número secreto");
                }
                return false;
            }
        }

        #endregion

        #region Metodo referente a questao do formulário 3 de validação de senha
        public bool VerificaSenha(string senha)
        {
            try 
            {
                if (senha.Length < 8) 
                {
                    Console.WriteLine("Senha não atende aos critérios, deve ter mais de oito caracteres");
                    return false;
                }

                if(!senha.Any(Char.IsUpper)) 
                {
                    Console.WriteLine("Senha não atende aos critérios, deve ter pelo menos um caractere maiusculo");
                    return false;
                }

                if(!senha.Any(Char.IsLower)) 
                {
                    Console.WriteLine("Senha não atende aos critérios, deve ter pelo menos um caractere minusculo");
                    return false;
                }

                if (!Regex.IsMatch(senha, @"[!@#$%^&*(),.?""{}|<>]"))
                {
                    Console.WriteLine("Senha não atende aos critérios, Deve conter pelo menos um caractere especial.");
                    return false;
                }

                return true;

            } catch { throw; }
        }

        #endregion

    }
}
