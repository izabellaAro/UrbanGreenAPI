namespace UrbanGreen.Core.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public double Valor { get; set; }

    public Produto() { }
    public Produto(string nome, int quantidade, double valor)
    {
        Nome = nome;
        Quantidade = quantidade;
        Valor = valor;
    }

    public void Update(string nome, int quantidade, double valor)
    {
        Nome = nome;
        Quantidade = quantidade;
        Valor = valor;
    }
}
