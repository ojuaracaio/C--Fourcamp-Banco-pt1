using System;

public class Conta
{
    string numero;
    decimal saldo;
    Cliente cliente;

    public Conta(string numeroConta, Cliente clienteConta)
    {
        saldo = 0;
        numero = numeroConta;
        cliente = clienteConta;
        //Console.WriteLine($"O cliente {cliente.nome} criou a conta nº {numeroConta}.");
        atualizarTipo();

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
        //nome e cpf
        Console.WriteLine($"Cliente: {cliente.nome} / CPF: {cliente.cpf}");
        //numero
        Console.WriteLine($"Número: {numero}");
        //saldo
        Console.WriteLine($"Saldo: {saldo}");
        //tipo
        Console.WriteLine($"Tipo da Conta: {cliente.tipo}");

    }

    public void depositar(decimal quantia)
    {
        saldo += quantia;
        Console.WriteLine($"O saldo após o depósito é de R${saldo}");
        atualizarTipo();
    }
}