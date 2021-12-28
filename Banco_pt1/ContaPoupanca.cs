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
        }
    }
}   
