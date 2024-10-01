namespace UrbanGreen.Core.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public double Valor { get; set; }
    public byte[] Imagem { get; set; }
    public string ImagemBase64 => Convert.ToBase64String(Imagem);
    public Inspecao Inspecao { get; private set; } = new Inspecao();

    public Produto() { }
    public Produto(string nome, int quantidade, double valor, byte[] imagem)
    {
        Nome = nome;
        Quantidade = quantidade;
        Valor = valor;
        Imagem = imagem;
    }

    public void Update(string nome, int quantidade, double valor, byte[] imagem)
    {
        Nome = nome;
        Quantidade = quantidade;
        Valor = valor;
        Imagem = imagem;
    }
}
