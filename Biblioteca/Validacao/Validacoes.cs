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

        public bool ValidarSenha(string senha)
        {
            try
            {
                if (string.IsNullOrEmpty(senha) || senha.Length < 8)
                    return false;

                bool temMaiuscula = false, temMinuscula = false, temEspecial = false;

                foreach (char c in senha)
                {
                    if (char.IsUpper(c)) temMaiuscula = true;
                    else if (char.IsLower(c)) temMinuscula = true;
                    else if (!char.IsLetterOrDigit(c)) temEspecial = true;

                    if (temMaiuscula && temMinuscula && temEspecial)
                        return true;
                }
                return false;
            }
            catch (Exception) { throw; }
        }
    }
}
