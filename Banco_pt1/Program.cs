using System;
using System.Linq;

namespace Banco_pt1 
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            string opcao, nome, cpf, leitura;
            decimal deposito, transferir;
            Cliente cliente1;
            Conta conta1;
            //int contadorConta = 1;

            Console.WriteLine("==============================\nBem-vindo ao sistema do 3Bank\n==============================\n");

            //Criação da primeira conta
            Console.WriteLine("Criação da primeira conta\n");
            Console.WriteLine("Digite o nome do cliente:");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o cpf do cliente (sem pontuação):");
            cpf = Console.ReadLine();

            while (cpf.Length != 11 || !cpf.All(Char.IsNumber)) // cpf.All(Char.IsDigit)   !ulong.TryParse(cpf,out _)
            {
                Console.WriteLine("Número de CPF inválido, digite novamente.");
                cpf = Console.ReadLine();
            }
            cliente1 = new Cliente(nome, cpf);
            conta1 = new Conta("0001", cliente1);

            //Laço principal
            while (true)
            {
                Console.WriteLine("==============================");
                Console.WriteLine("Menu Principal:");
                Console.WriteLine("==============================");
                Console.WriteLine("1-Cadastrar Pessoa");
                Console.WriteLine("2-Transferir Dinheiro");
                Console.WriteLine("3-Depositar Dinheiro");
                Console.WriteLine("4-Dados Cliente");
                Console.WriteLine("5-Sair");
                Console.WriteLine("==============================");

                Console.Write("Digite o número da opção desejada: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Digite o nome do cliente:");
                        nome = Console.ReadLine();
                        Console.WriteLine("Digite o cpf do cliente (sem pontuação):");
                        cpf = Console.ReadLine();

                        //verificação do cpf
                        while (cpf.Length != 11 || !cpf.All(Char.IsNumber))
                        {
                            Console.WriteLine("Número de CPF inválido, digite novamente.");
                            cpf = Console.ReadLine();
                        }
                        cliente1 = new Cliente(nome, cpf);
                        conta1 = new Conta("0001", cliente1);
                        break;
                    case "2":
                        //transferir
                        Console.WriteLine("Quanto deseja transferir?");
                        leitura = Console.ReadLine();
                        while (!decimal.TryParse(leitura, out transferir)) //checa se é possível converter a entrada para decimal
                        {
                            Console.WriteLine("Valor inválido. Use apenas números.");
                            leitura = Console.ReadLine();
                        }
                        conta1.transferir(transferir);
                        break;
                    case "3":
                        //depositar
                        Console.WriteLine("Quanto deseja depositar?");
                        leitura = Console.ReadLine();

                        while (!decimal.TryParse(leitura, out deposito)) //checa se é possível converter a entrada para decimal
                        {
                            Console.WriteLine("Valor inválido. Use apenas números.");
                            leitura = Console.ReadLine();
                        }
                        conta1.depositar(deposito);

                        break;
                    case "4":
                        //mostrar dados
                        conta1.imprimirDados();
                        break;
                    case "5":
                        Console.WriteLine("Saindo do programa...");
                        return; //Sai do programa
                    default:
                        Console.WriteLine("Opção inválida. Digite um número de 1 a 5.");
                        break;
                }
            }
        }
    }
}