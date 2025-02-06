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

        public bool ValidarCPF(string cpfInserido)
        {
            try
            {
                if (cpfInserido.Length != 11 || !cpfInserido.All(char.IsDigit))
                {
                    Console.WriteLine("Digite um CPF válido com 11 números.");
                    return false;
                }


                int[] pesosDigito1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] pesosDigito2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                int soma = 0;

                for (int i = 0; i < 9; i++)
                {
                    soma += (cpfInserido[i] - '0') * pesosDigito1[i];
                }
                int primeiroDigito = (soma % 11 < 2) ? 0 : 11 - (soma % 11);

                soma = 0;
                for (int i = 0; i < 10; i++)
                {
                    soma += (cpfInserido[i] - '0') * pesosDigito2[i];
                }
                int segundoDigito = (soma % 11 < 2) ? 0 : 11 - (soma % 11);

                return cpfInserido[9] - '0' == primeiroDigito && cpfInserido[10] - '0' == segundoDigito;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidarCNPJ(string cnpjInserido)
        {
            try
            {
                if (cnpjInserido.Length != 14 || !cnpjInserido.All(char.IsDigit))
                {
                    Console.WriteLine("Digite um CNPJ válido com 14 números.");
                    return false;
                }

                int[] pesosDigito1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] pesosDigito2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

                int soma = 0;
                for (int i = 0; i < 12; i++)
                {
                    soma += (cnpjInserido[i] - '0') * pesosDigito1[i]; // converte char em número
                }
                int primeiroDigito = (soma % 11 < 2) ? 0 : 11 - (soma % 11);

                soma = 0;
                for (int i = 0; i < 13; i++)
                {
                    soma += (cnpjInserido[i] - '0') * pesosDigito2[i]; // converte char em número
                }
                int segundoDigito = (soma % 11 < 2) ? 0 : 11 - (soma % 11);

                return (cnpjInserido[12] - '0') == primeiroDigito && (cnpjInserido[13] - '0') == segundoDigito;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
