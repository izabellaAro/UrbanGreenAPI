namespace UrbanGreen.Application.Models.Pedido;

public class ReadPedidoDto
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string NomeComprador { get; set; }
    public string NomeProduto {get;set;}
    public int QuantidadeProduto { get; set; }
    public double ValorTotal { get; set; }
    public int ItemPedidoId { get; set; }
}
