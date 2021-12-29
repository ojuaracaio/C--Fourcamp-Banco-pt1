using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_pt1
{
    public class ContaPoupanca : Conta
    {
        float taxaRendimento;
        public ContaPoupanca(string numeroConta, Cliente clienteConta, float rendimento)
        {
            saldo = 0;
            numero = numeroConta;
            cliente = clienteConta;
            taxaRendimento = rendimento;
            atualizarTipo();
        }

        public void AdicionarRendimento()
        {
            saldo *= (1 + (decimal)taxaRendimento);
            Console.WriteLine("Rendimento adicionado.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Novo saldo na conta poupança: R${string.Format("{0:0.00}", saldo)}");
            atualizarTipo();
        }

        public override void imprimirDados()
        {
            atualizarTipo();// certeza que o tipo correto será mostrado

            Console.WriteLine();
            Console.WriteLine("================= CONTA POUPANÇA =================");
            //nome e cpf
            Console.WriteLine($"Cliente: {cliente.nome} / CPF: {cliente.cpf}");
            //data de nascimento
            Console.WriteLine($"Data de Nascimento: {cliente.dataNascimento.ToShortDateString()}");
            //numero
            Console.WriteLine($"Número: {numero}");
            //saldo
            Console.WriteLine($"Saldo: R${string.Format("{0:0.00}", saldo)}");
            //tipo
            Console.WriteLine($"Tipo da Conta: {cliente.tipo}");
            Console.WriteLine("========================================");
            Console.WriteLine();

        }
    }
}   
