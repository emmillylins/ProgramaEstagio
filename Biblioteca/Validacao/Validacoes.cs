using System.Text.RegularExpressions;
using Biblioteca.Classes;
using Biblioteca.Manutencao;

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



        public bool AutenticarSenha(string senha)
        {
            // validacao utilizei o regex para validar os campos da senha. (expressões regulares) 
            var valida = new Metodos();
            string requisitosSenha = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&.*()_+{}\[\]:;<>?~\-])(?=.*\S).{8,}$";

            return Regex.IsMatch(senha, requisitosSenha);
        }

        public bool VerificarMultiploDez(int saque)
        {

            if (saque % 10 == 0)
            {
                return true;
            }

            return false;

        }

        public bool limitarLetras(String tentativa)
        {
            var metodos = new Validacoes();
            var valida = new Metodos();
            string requisitosTentativas = @"^(?=.*[a-z]){1}$";

            return Regex.IsMatch(tentativa, requisitosTentativas);

        }

    }
}
