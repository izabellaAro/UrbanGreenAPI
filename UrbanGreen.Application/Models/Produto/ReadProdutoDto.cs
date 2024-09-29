namespace UrbanGreen.Application.Models.Produto;

public class ReadProdutoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public double Valor { get; set; }
    public string? ImagemBase64 { get; set; }
}
