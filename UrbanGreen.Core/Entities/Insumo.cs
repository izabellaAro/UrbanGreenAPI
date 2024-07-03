namespace UrbanGreenAPI.Core.Entities;

public class Insumo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public double Valor { get; set; }

    public Insumo() { }

    public Insumo(string nome, int quantidade, double valor)
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
   