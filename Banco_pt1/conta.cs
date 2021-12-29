using System;

public abstract class Conta
{
    public string numero { get; set; }
    private protected decimal saldo { get; set; }
    public Cliente cliente { get; set; }

    public Conta()
    {

    }

    public void atualizarTipo()
    {
        if (saldo < 5000)
        {
            //comum
            cliente.tipo = TipoCliente.Comum;
        }
        else if (saldo < 15000)
        {
            //super
            cliente.tipo = TipoCliente.Super;
        }
        else
        {
            //premium
            cliente.tipo = TipoCliente.Premium;
        }
    }

    public abstract void imprimirDados();

    public void depositar(decimal quantia)
    {
        saldo += quantia;
        Console.WriteLine($"O saldo após o depósito é de R${string.Format("{0:0.00}", saldo)}");
        atualizarTipo();
    }

    public void transferir(decimal quantia)
    {
        if((saldo - quantia) >= 0)
        {
            Console.WriteLine("Transferência realizada com sucesso!");
            saldo -= quantia; // transferência
        }
        else
        {
            Console.WriteLine("Saldo insuficiente. Não foi possível realizar a transferência.");
        }
        Console.WriteLine($"Saldo atual: {string.Format("{0:0.00}", saldo)}");
        atualizarTipo();
    }
}