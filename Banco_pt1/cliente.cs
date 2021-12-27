using System;

public class Cliente
{
    //declaração de atributos
    public string cpf { get; set; }
    public string nome { get; set; }
    public TipoCliente tipo { get; set; }

    //construtor
    public Cliente(string entradaNome, string entradaCpf)
    {
        nome = entradaNome;
        cpf = entradaCpf;
        //Console.WriteLine($"O cliente {entradaNome} foi cadastrado com sucesso!");
    }

}