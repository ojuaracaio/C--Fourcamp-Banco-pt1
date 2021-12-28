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

    public void imprimirDados()
    {
        atualizarTipo();// certeza que o tipo correto será mostrado

        //nome e cpf
        Console.WriteLine($"Cliente: {cliente.nome} / CPF: {cliente.cpf}");
        //data de nascimento
        Console.WriteLine($"Data de Nascimento: {cliente.dataNascimento.ToShortDateString()}");
        //numero
        Console.WriteLine($"Número: {numero}");
        //saldo
        Console.WriteLine($"Saldo: R${string.Format("{0:0.00}",saldo)}");
        //tipo
        Console.WriteLine($"Tipo da Conta: {cliente.tipo}");

    }

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