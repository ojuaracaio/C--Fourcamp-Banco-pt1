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
        }
    }
}
