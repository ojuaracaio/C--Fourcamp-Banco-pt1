using System;

public class Cliente
{
    //declaração de atributos
    public string cpf { get; set; }
    public string nome { get; set; }
    public TipoCliente tipo { get; set; }
    public DateTime dataNascimento { get; set; }

    //construtor
    public Cliente(string entradaNome, string entradaCpf, DateTime entradaNascimento)
    {
        nome = entradaNome;
        cpf = entradaCpf;
        dataNascimento = entradaNascimento;
        //Console.WriteLine($"O cliente {entradaNome} foi cadastrado com sucesso!");
    }

}