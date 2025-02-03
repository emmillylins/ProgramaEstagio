using Biblioteca.Classes;

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


        // metodo cadastrar usuário
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
        // Método listar Usuário

        public void MostrarUsuario(List<Usuario> usuarios)
        {
            try
            {

                foreach (var usuario in usuarios)
                {
                    Console.WriteLine(@$"nome: {usuario.Nome}
                                        E-mail: {usuario.Email}
                                        Senha: {usuario.Senha}
                                        Idade: {usuario.Idade}"
                                        );
                }
                if (usuarios.Count == 0)
                {
                    Console.WriteLine("Nenhum usuario cadastrado");
                }

            }
            catch (Exception) { throw; }

        }

        public Usuario CadastrarUsuario()
        {
            var usuario = new Usuario();
            try
            {
                Console.Write("Digite um nome: ");
                usuario.Nome = Console.ReadLine();

                Console.Write("Digite um email: ");
                usuario.Email = Console.ReadLine();

                Console.Write("Digite uma idade: ");
                if (!int.TryParse(Console.ReadLine(), out int numero))
                    Console.WriteLine("Digite uma idade válida.");

                return usuario;
            }
            catch (Exception) { throw; }
        }
    }
}
