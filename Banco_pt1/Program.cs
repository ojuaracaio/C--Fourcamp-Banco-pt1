using System;
using System.Linq;

namespace Banco_pt1 
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //TODO Escolha das contas para transferir e depositar
            //TODO Escolha da conta para exibir os dados

            string opcao, nome, cpf, leitura;
            decimal deposito, transferir;
            int ano, mes, dia;
            Cliente cliente1;
            Conta conta1, conta2;
            DateTime data;
            const decimal TAXAMANUTENCAO = 5;
            const float TAXARENDIMENTO = 0.05f;

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

            // ano de nascimento
            Console.WriteLine("Digite o ano de nascimento (ex: 1990):");
            leitura = Console.ReadLine();

            while(leitura.Length != 4 || !leitura.All(Char.IsNumber))
            {
                Console.WriteLine("Use apenas 4 números para indicar o ano.");
                leitura= Console.ReadLine();
            }
            ano = int.Parse(leitura);

            //mes de nascimento
            Console.WriteLine("Digite o mês de nascimento (ex: 12):");
            leitura = Console.ReadLine();

            while (leitura.Length != 2 || !leitura.All(Char.IsNumber))
            {
                Console.WriteLine("Use apenas 2 números para indicar o ano.");
                leitura = Console.ReadLine();
            }
            mes = int.Parse(leitura);

            //dia de nascimento
            Console.WriteLine("Digite o dia de nascimento (ex: 25):");
            leitura = Console.ReadLine();

            while (leitura.Length != 2 || !leitura.All(Char.IsNumber))
            {
                Console.WriteLine("Use apenas 2 números para indicar o ano.");
                leitura = Console.ReadLine();
            }
            dia = int.Parse(leitura);

            //criação do objeto datetime
            data = new DateTime(ano, mes, dia);
            cliente1 = new Cliente(nome, cpf, data);

            /*
            //Opção de conta 
            Console.WriteLine("Qual tipo de conta você deseja criar? Digite o número das opções abaixo:");
            Console.WriteLine("1-Conta Corrente");
            Console.WriteLine("2-Conta Poupança");
            Console.WriteLine("3-Ambas");
            opcao = Console.ReadLine();

            while (opcao != "1" && opcao != "2" && opcao != "3")
            {
                Console.WriteLine("Opção inválida, digite uma opção de 1 a 3.");
            }

            switch (opcao)
            {
                case "1":
                    conta1 = new ContaCorrente("0001", cliente1, TAXAMANUTENCAO);
                    Console.WriteLine("Conta Corrente criada com sucesso.");
                    break;

                case "2":
                    conta1 = new ContaPoupanca("0002", cliente1, TAXARENDIMENTO);
                    Console.WriteLine("Conta Poupança criada com sucesso.");
                    break;
                
                case "3":
                    conta1 = new ContaCorrente("0001", cliente1, TAXAMANUTENCAO);
                    conta2 = new ContaPoupanca("0002", cliente1, TAXARENDIMENTO);
                    Console.WriteLine("Contas Corrente e Poupança criadas com sucesso.");
                    break;
            } */

            conta1 = new ContaCorrente("0001", cliente1, TAXAMANUTENCAO);
            conta2 = new ContaPoupanca("0002", cliente1, TAXARENDIMENTO);

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
                        // ano de nascimento
                        Console.WriteLine("Digite o ano de nascimento (ex: 1990):");
                        leitura = Console.ReadLine();

                        while (leitura.Length != 4 || !leitura.All(Char.IsNumber))
                        {
                            Console.WriteLine("Use apenas 4 números para indicar o ano.");
                            leitura = Console.ReadLine();
                        }
                        ano = int.Parse(leitura);

                        //mes de nascimento
                        Console.WriteLine("Digite o mês de nascimento (ex: 12):");
                        leitura = Console.ReadLine();

                        while (leitura.Length != 2 || !leitura.All(Char.IsNumber))
                        {
                            Console.WriteLine("Use apenas 2 números para indicar o ano.");
                            leitura = Console.ReadLine();
                        }
                        mes = int.Parse(leitura);

                        //dia de nascimento
                        Console.WriteLine("Digite o dia de nascimento (ex: 25):");
                        leitura = Console.ReadLine();

                        while (leitura.Length != 2 || !leitura.All(Char.IsNumber))
                        {
                            Console.WriteLine("Use apenas 2 números para indicar o ano.");
                            leitura = Console.ReadLine();
                        }
                        dia = int.Parse(leitura);

                        //criação do objeto datetime
                        data = new DateTime(ano, mes, dia);
                        cliente1 = new Cliente(nome, cpf, data);

                        conta1 = new ContaCorrente("0001", cliente1, TAXAMANUTENCAO);
                        conta2 = new ContaPoupanca("0002", cliente1, TAXARENDIMENTO);
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