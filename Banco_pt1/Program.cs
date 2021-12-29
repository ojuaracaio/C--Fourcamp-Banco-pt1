using System;
using System.Linq;

namespace Banco_pt1 
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //TODO usar switch dentro do while da data

            string opcao, leitura;
            decimal deposito, transferencia;
            Cliente cliente1;
            ContaCorrente conta1;
            ContaPoupanca conta2;
            const decimal TAXAMANUTENCAO = 5;
            const float TAXARENDIMENTO = 0.05f;
            const int TEMPOANIMACAO = 1000;
            const int IDADEMINIMA = 16;
            const int IDADEMAXIMA = 120;
            const int ANOATUAL = 2022;

            //FUNÇÕES
            void animacao()
            {
                for (int i = 0; i < 3; i++)
                {
                    System.Threading.Thread.Sleep(TEMPOANIMACAO);
                    Console.Write(".");
                }
                Console.WriteLine();
            }

            Cliente criarCliente()
            {
                int ano, mes, dia;
                Console.WriteLine("Digite o nome do cliente:");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite o cpf do cliente (sem pontuação):");
                string cpf = Console.ReadLine();

                while (cpf.Length != 11 || !cpf.All(Char.IsNumber)) // cpf.All(Char.IsDigit)   !ulong.TryParse(cpf,out _)
                {
                    Console.WriteLine("Número de CPF inválido, digite novamente.");
                    cpf = Console.ReadLine();
                }
                string leitura;
                // ano de nascimento
                while (true)
                {
                    Console.WriteLine("Digite o ano de nascimento (ex: 1990):");
                    leitura = Console.ReadLine();
                    while (!int.TryParse(leitura, out ano))
                    {
                        Console.WriteLine("Ano inválido. Use apenas números.");
                        leitura = Console.ReadLine();
                    }

                    switch (ano)
                    {
                        case < (ANOATUAL-IDADEMAXIMA):
                        case > (ANOATUAL-IDADEMINIMA):
                            Console.WriteLine($"Insira um ano entre {ANOATUAL - IDADEMAXIMA} e {ANOATUAL - IDADEMINIMA}.");
                            continue;
                        default: // ano válido
                            ano = int.Parse(leitura);
                            break;
                    }
                    break;
                }



                //mes de nascimento
                while (true)
                {
                    Console.WriteLine("Digite o mês de nascimento (ex: 12):");
                    leitura = Console.ReadLine();
                    while (!int.TryParse(leitura, out mes))
                    {
                        Console.WriteLine("Mês inválido. Use apenas números.");
                        leitura = Console.ReadLine();
                    }

                    switch (mes)
                    {
                        case < 1:
                        case > 12:
                            Console.WriteLine("Insira um mês de 01(jan) a 12(dez).");
                            continue;
                        default: // mês válido
                            mes = int.Parse(leitura);
                            break;
                    }
                    break;
                }

                //dia de nascimento
                while (true)
                {
                    Console.WriteLine("Digite o dia de nascimento (ex: 25):");
                    leitura = Console.ReadLine();
                    while (!int.TryParse(leitura, out dia))
                    {
                        Console.WriteLine("Dia inválido. Use apenas números.");
                        leitura = Console.ReadLine();
                    }

                    switch (dia)
                    {
                        case < 1:
                        case > 31:
                            Console.WriteLine("Insira um dia entre 01 e 31.");
                            continue; // volta pro início do while
                        default: // dia válido
                            dia = int.Parse(leitura);
                            break;
                    }
                    break;
                }

                //criação do objeto datetime
                DateTime dataNascimento = new DateTime(ano, mes, dia);
                return new(nome, cpf, dataNascimento);
            }


            Console.WriteLine("==============================\nBem-vindo ao sistema do 3Bank\n==============================\n");

            //Criação da primeira conta
            Console.WriteLine("Criação da primeira conta\n");

            cliente1 = criarCliente();
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
                Console.WriteLine("5-Finalizar Mês");
                Console.WriteLine("6-Sair");
                Console.WriteLine("==============================");

                Console.Write("Digite o número da opção desejada: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        cliente1 = criarCliente();

                        conta1 = new ContaCorrente("0001", cliente1, TAXAMANUTENCAO);
                        conta2 = new ContaPoupanca("0002", cliente1, TAXARENDIMENTO);
                        break;


                    case "2":
                        //transferir
                        Console.WriteLine("De qual conta deseja transferir? Digite apenas o número das opções abaixo:");
                        Console.WriteLine("1-Conta Corrente");
                        Console.WriteLine("2-Conta Poupança");
                        opcao = Console.ReadLine();

                        //certifica que a resposta é 1 ou 2
                        while (opcao != "1" && opcao != "2")
                        {
                            Console.WriteLine("Opção inválida. Use apenas '1' ou '2'.");
                            opcao = Console.ReadLine();
                        }

                        Console.WriteLine("Quanto deseja transferir?");
                        leitura = Console.ReadLine();
                        while (!decimal.TryParse(leitura, out transferencia)) //checa se é possível converter a entrada para decimal
                        {
                            Console.WriteLine("Valor inválido. Use apenas números.");
                            leitura = Console.ReadLine();
                        }
                        if (opcao == "1") // conta corrente
                        {
                            conta1.transferir(transferencia);
                        } else // conta poupança
                        {
                            conta2.transferir(transferencia);
                        }
                        
                        break;
                    case "3":
                        //depositar
                        Console.WriteLine("Em qual conta deseja depositar? Digite apenas o número das opções abaixo:");
                        Console.WriteLine("1-Conta Corrente");
                        Console.WriteLine("2-Conta Poupança");
                        opcao = Console.ReadLine();

                        //certifica que a resposta é 1 ou 2
                        while (opcao != "1" && opcao != "2")
                        {
                            Console.WriteLine("Opção inválida. Use apenas '1' ou '2'.");
                            opcao = Console.ReadLine();
                        }

                        Console.WriteLine("Quanto deseja depositar?");
                        leitura = Console.ReadLine();

                        while (!decimal.TryParse(leitura, out deposito)) //checa se é possível converter a entrada para decimal
                        {
                            Console.WriteLine("Valor inválido. Use apenas números.");
                            leitura = Console.ReadLine();
                        }

                        if (opcao == "1") // conta corrente
                        {
                            conta1.depositar(deposito);
                        }
                        else // conta poupança
                        {
                            conta2.depositar(deposito);
                        }
                        break;
                    case "4":
                        //mostrar dados
                        Console.WriteLine("De qual conta deseja visualizar os dados? Digite apenas o número das opções abaixo:");
                        Console.WriteLine("1-Conta Corrente");
                        Console.WriteLine("2-Conta Poupança");
                        opcao = Console.ReadLine();

                        //certifica que a resposta é 1 ou 2
                        while (opcao != "1" && opcao != "2")
                        {
                            Console.WriteLine("Opção inválida. Use apenas '1' ou '2'.");
                            opcao = Console.ReadLine();
                        }

                        if (opcao == "1") // conta corrente
                        {
                            conta1.imprimirDados();
                        }
                        else // conta poupança
                        {
                            conta2.imprimirDados();
                        }
                        break;

                    case "5":
                        //finalizar mês
                        Console.Write("Finalizando o mês");
                        animacao();
                        
                        Console.Write("Descontando taxa de manutenção");
                        animacao();

                        conta1.DescontarTaxa();
                        Console.Write("Adicionando rendimentos");
                        animacao();

                        conta2.AdicionarRendimento();
                        Console.WriteLine("Mês finalizado com sucesso!");
                        break;

                    case "6":
                        Console.WriteLine("Saindo do programa...");
                        return; //Sai do programa
                    default:
                        Console.WriteLine("Opção inválida. Digite um número de 1 a 6.");
                        break;
                }
            }
        }
    }
}