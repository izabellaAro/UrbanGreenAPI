namespace UrbanGreen.Application.Models.ItemPedido;

public class ReadItemPedidoDto
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public int ProdutoId { get; set; }
    public string NomeProduto { get; set; }
}
