using System;

namespace Banco_pt1 
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            string opcao, nome, cpf, deposito;
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

            while (cpf.Length != 11)
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

                        while (cpf.Length != 11)
                        {
                            Console.WriteLine("Número de CPF inválido, digite novamente.");
                            cpf = Console.ReadLine();
                        }
                        //
                        cliente1 = new Cliente(nome, cpf);
                        //contadorConta++;
                        conta1 = new Conta("0001", cliente1);
                        break;
                    case "2":
                        //transferir
                        Console.WriteLine("Opção 2");
                        break;
                    case "3":
                        //depositar
                        Console.WriteLine("Quanto deseja depositar?");
                        deposito = Console.ReadLine();
                        conta1.depositar(decimal.Parse(deposito));
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