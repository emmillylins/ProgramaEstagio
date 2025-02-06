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


        // Validação para o jogo do número aleatório
        public bool ValidaNumeroEntre1e100(int numero)
        {
            try
            {
                if (numero > 0 && numero < 101)
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

        public bool ValidaSenha(string senha)
        {
            try
            {
                // Variável para armazenar o resultado da verificação do digito
                bool possuiDigitoMaiusculo = false;
                bool possuiDigitoMinusculo = false;
                bool possuiCaracterEspecial = false;


                // Percorrendo a string para verificar se a senha possui letra maiúscula
                foreach (char digito in senha)
                {
                    if (digito == char.ToUpper(digito))
                    {
                        possuiDigitoMaiusculo = true;
                        break;
                    }
                }

                // Percorrendo a string para verificar se a senha possui letra minuscula
                foreach (char digito in senha)
                {
                    if (digito == char.ToLower(digito))
                    {
                        possuiDigitoMinusculo = true;
                        break;
                    }
                }

                // Percorrendo a string para verificar se a senha possui um caracter especial
                foreach (char digito in senha)
                {
                    if (char.IsLetterOrDigit(digito))
                    {
                        possuiCaracterEspecial = true;
                        break;
                    }
                }

                int digitos = 0;
                // Percorrendo a string para verificar se a senha possui 8 digitos
                foreach (char digito in senha)
                {
                    digitos++;
                }

                if (possuiDigitoMaiusculo == true && possuiDigitoMinusculo == true && possuiCaracterEspecial == true && digitos == 8)
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

        //Regras de Validação de CPF
        //O CPF deve ter 11 dígitos. OK
        //Os dois últimos dígitos são verificadores, calculados com base nos 9 primeiros dígitos. 
        //O cálculo dos dígitos verificadores é feito da seguinte forma: 
        //Para o primeiro dígito verificador: 
        //Multiplica-se cada um dos 9 primeiros dígitos por um peso que começa em 10 e diminui até 2. OK
        //Soma-se os resultados. OK
        //O dígito verificador é o resto da divisão dessa soma por 11. Se o resto for menor que 2, o dígito é 0; caso contrário, é 11 menos o resto.

        //Para o segundo dígito verificador: 
        //Multiplica-se cada um dos 10 primeiros dígitos(9 originais + primeiro dígito verificador) por um peso que começa em 11 e diminui até 2. 
        //Soma-se os resultados.
        //O dígito verificador é o resto da divisão dessa soma por 11. 
        //Se o resto for menor que 2, o dígito é 0; caso contrário, é 11 menos o resto.

        // VALIDAÇÂO COM ERRO!
        public bool ValidaCPF(string cpf)
        {

            int quantidadeDigitos = 0;

            // Percorrendo a string para verificar se a senha possui 11 digitos
            foreach (char digito in cpf)
            {
                quantidadeDigitos++;
            }

            if (!int.TryParse(cpf, out var cpfInserido))
            {
                if (quantidadeDigitos == 11)
                {
                    // Variável peso
                    int peso = 10;

                    // Lista para armazenar os resultados das multiplicações dos digitos + seus pesos
                    List<int> resultados = [];
                    // Lista para armazenar os dígitos do cpf
                    List<int> digitosCpf = [];

                    //Armazenando cada digito do CPF em uma lista
                    foreach (char digito in cpf)
                    {
                        digitosCpf.Add(digito);
                    }

                    // Calculando o resultado do digito multiplicado pelo seu peso
                    for (int i = 0; i < 9; i++)
                    {
                        resultados.Add(digitosCpf[i] * peso);
                        peso--;
                    }

                    // Soma do resultado
                    int primeiroDigitoVerificador = resultados.Sum() % 11;

                    //Se o resto for menor que 2, o dígito é 0; caso contrário, é 11 menos o resto.
                    if (primeiroDigitoVerificador < 2)
                    {
                        primeiroDigitoVerificador = 0;
                    }
                    else
                    {
                        primeiroDigitoVerificador = 11 - primeiroDigitoVerificador;
                    }

                    //Para o segundo dígito verificador: 
                    //Multiplica-se cada um dos 10 primeiros dígitos(9 originais + primeiro dígito verificador) por um peso que começa em 11 e diminui até 2. 
                    //Soma-se os resultados.
                    //O dígito verificador é o resto da divisão dessa soma por 11. 
                    //Se o resto for menor que 2, o dígito é 0; caso contrário, é 11 menos o resto.

                    // Alterando o valor do peso para a verificação do segundo digito
                    peso = 11;

                    for (int i = 0; i < 10; i++)
                    {
                        resultados.Add(digitosCpf[i] * peso);
                        peso--;
                    }

                    int segundoDigitoVerificador = resultados.Sum() % 11;

                    if (segundoDigitoVerificador < 2)
                    {
                        segundoDigitoVerificador = 0;
                    }
                    else
                    {
                        segundoDigitoVerificador = 11 - segundoDigitoVerificador;
                    }

                    if (primeiroDigitoVerificador == digitosCpf[9] && segundoDigitoVerificador == digitosCpf[10])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
