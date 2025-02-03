﻿using System.Data.SqlTypes;

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

        public bool ValidaNumeroPositivoMaiorZero(int numero)
        {
            try
            {
                if (numero > 0)
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
    }
}
