using System.Threading.Channels;
using Biblioteca.Classe;
using Biblioteca.Validacao;

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

        // Cadastrar Usuário
        public Usuario CadastrarUsuario()
        {
            try
            {
                var validacoes = new Validacoes();
                Usuario usuario = new Usuario();

                Console.Write("Informe o nome do usuário: ");
                usuario.Nome = Console.ReadLine();

                Console.Write("Informe o email do usuário: ");
                usuario.Email = Console.ReadLine();

                Console.Write("Informe a idade do usuário: ");
                
                if (!int.TryParse(Console.ReadLine(), out var idade))
                {
                    Console.WriteLine("Valor para idade inserido inválido");
                }

                // Verificando se a idade é um número válido
                bool idadeValida = validacoes.ValidaNumeroPositivoMaiorZero(idade);

                if (idadeValida)
                {
                    usuario.Idade = idade;
                }
                else
                {
                    Console.WriteLine("Insira uma idade válida! \n  ");
                }
                    // retornando uma instância da classe usuário
                    return usuario;
            }
            catch (Exception) { throw; }
        }

        // Método para listar usuários 
        public void ListarUSuarios(List<Usuario> usuarios)
        {
            if (usuarios.Count > 0)
            {
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($" Nome: {usuario.Nome} \n Idade: {usuario.Idade} \n Email: {usuario.Email}");
                }
            }
            else
            {
                return;
            }
        }
    }
}
