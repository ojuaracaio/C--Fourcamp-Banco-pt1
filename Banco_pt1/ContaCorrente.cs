using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_pt1
{
    public class ContaCorrente : Conta
    {
        decimal taxaManutencao;
        public ContaCorrente(string numeroConta, Cliente clienteConta, decimal taxa)
        {
            saldo = 0;
            numero = numeroConta;
            cliente = clienteConta;
            taxaManutencao = taxa;
            atualizarTipo();

        }

        public void DescontarTaxa()
        {
            saldo -= taxaManutencao;
            Console.WriteLine("Taxa de manutenção descontada.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Novo saldo na conta corrente: R${string.Format("{0:0.00}", saldo)}");
            atualizarTipo();
        }

        public override void imprimirDados()
        {
            atualizarTipo();// certeza que o tipo correto será mostrado
            Console.WriteLine();
            Console.WriteLine("================= CONTA CORRENTE =================");
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
