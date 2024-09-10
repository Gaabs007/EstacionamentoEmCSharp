using System;
using Projetos_C_.Classes;
class Program
{
    static void Main(string[] args)
    {
        int opcao;
        decimal precoInicial, precoPorHora;
        bool verificar = true;
        Estacionamento estacionamento = new Estacionamento();
        estacionamento.SolicitaValorInicial();
        estacionamento.SolicitaValorPorHora();
        do
        {
            Console.Write("MENU ESTACIONAMENTO - GaaBs\n" + "Digite 1 para incluir um novo veiculo.\n" +
            "Digite 2 para retirar um veiculo.\n" + "Digite 3 para listar veiculos.\n" +
            "Digite 4 para sair.\n");
            Console.Write("Digite a opção desejada: ");
            try
            {
                opcao = Convert.ToInt32(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        estacionamento.IncluirCarro();
                        break;
                    case 2:
                        estacionamento.SaidaCarro();
                        break;
                    case 3:
                        estacionamento.ListarCarros();
                        break;
                    case 4:
                        verificar = false;
                        break;
                    default:
                        Console.WriteLine("\nOpção digitada é invalida. Pressione qualquer tecla para continuar\n");
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nOpção digitada é inválida! Pressione qualquer tecla para continuar\n");
                Console.ReadKey();
            }
        } while (verificar == true);
    }
}
