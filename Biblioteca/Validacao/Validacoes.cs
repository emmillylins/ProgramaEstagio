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


        //Implemente um sistema de validação de senha que exige pelo menos 8 caracteres,
        //pelo menos uma letra maiúscula, uma letra minúscula e um caractere especial.
        //O programa deve informar se a senha fornecida atende aos critérios.

        public bool ValidaSenha(string senha)
        {
            if (senha == null)
            {
                Console.WriteLine("\nInsira um valor não nulo");
                return false;
            }
            else if (senha.Length < 8)
            {
                Console.WriteLine("\nA senha deve conter pelo menos 8 caracteres");
                return false;
            }

            bool temMaiuscula = false;
            bool temMinuscula = false;
            bool temCaractereEspecial = false;

            foreach (char caractere in senha)
            {
                if (char.IsUpper(caractere))
                {
                    temMaiuscula = true;
                }
                else if (char.IsLower(caractere))
                {
                    temMinuscula = true;
                }
                else if (!char.IsLetterOrDigit(caractere)) 
                {
                    temCaractereEspecial = true;
                }
            }

            if (!temMaiuscula)
            {
                Console.WriteLine("\nA senha deve conter pelo menos uma letra maiúscula");
                return false;
            }
            else if (!temMinuscula)
            {
                Console.WriteLine("\nA senha deve conter pelo menos uma letra minúscula");
                return false;
            }
            else if (!temCaractereEspecial)
            {
                Console.WriteLine("\nA senha deve conter pelo menos um caractere especial");
                return false;
            }

            return true;
        }
    }
}
