using System.Dynamic;
using System.Globalization;
using Projetos_C_.Classes;

namespace Projetos_C_.Classes
{
    public class Estacionamento
    {
        private decimal _valorInicial;
        private decimal _valorPorHora;
        private decimal valorInicial
        {
            set
            {
                if (value > 0)
                {
                    _valorInicial = value;
                }
                else
                {
                    Console.WriteLine("\nO valor não pode ser negativo ou zero\n");
                    SolicitaValorInicial();
                }
            }
            get => _valorInicial;
        }
        public void SolicitaValorInicial()
        {
            bool verifica = false;
            while (!verifica)
            {
                try
                {
                    Console.Write("Digite o valor do estacionamento: ");
                    valorInicial = Convert.ToDecimal(Console.ReadLine());
                    verifica = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n Você digitou um valor invalido, por favor digite novamente!\n");
                }
            }
        }
        public void SolicitaValorPorHora()
        {
            bool verifica = false;
            while (!verifica)
            {
                try
                {
                    Console.Write("Digite o valor por hora estacionada: ");
                    valorPorHora = Convert.ToDecimal(Console.ReadLine());
                    verifica = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nVocê digitou um valor invalido, por favor digite novamente!\n");
                }
            }
        }
        private decimal valorPorHora
        {
            set
            {
                if (value > 0)
                {
                    _valorPorHora = value;
                }
                else
                {
                    Console.WriteLine("\nO valor não pode ser negativo ou zero\n");
                    SolicitaValorPorHora();
                }
            }
            get => _valorPorHora;
        }
        private List<string> carros = new List<string>();
        private string input;
        public void IncluirCarro()
        {
            Console.Write("Digite a placa do carro: ");
            input = Console.ReadLine();
            carros.Add(input);
            Console.WriteLine("\nVeiculo adicionado com sucesso! Pressione qualquer tecla para continuar\n");
            Console.ReadKey();
        }
        public void SaidaCarro()
        {
            string entrada;
            int qtdHoras;
            decimal totalFinal = 0;
            bool verificaHoras = false;
            Console.Write("Digite a placa do carro que deseja retirar: ");
            input = Console.ReadLine();

            if (carros.Contains(input))
            {
                while (!verificaHoras)
                {
                    Console.Write("Digite a quantidade de horas que o carro ficou no estacionamento: ");
                    entrada = Console.ReadLine();

                    if (int.TryParse(entrada, out qtdHoras) && qtdHoras >= 0)
                    {
                        verificaHoras = true;
                        totalFinal = CalculaValor(qtdHoras);
                    }
                    else
                    {
                        Console.WriteLine("\nValor digitado inválido! Pressione qualquer tecla para prosseguir\n");
                        Console.ReadKey();
                    }
                }

                carros.Remove(input);
                Console.WriteLine($"A conta do estacionamento ficou no valor de R${totalFinal}");
                Console.WriteLine("\nVeiculo retirado com sucesso! Pressione qualquer tecla para continuar\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Placa inexistente! Pressione qualquer tecla pra continuar");
                Console.ReadKey();
            }
        }
        public void ListarCarros()
        {
            Console.WriteLine("\nLista de veiculos estacionados\n");
            foreach (string itens in carros)
            {
                Console.WriteLine(itens);
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar\n");
            Console.ReadKey();
        }
        private decimal CalculaValor(int qtdHoras)
        {
            return valorInicial + valorPorHora * qtdHoras;
        }
    }
}