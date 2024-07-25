using UrbanGreen.Application.Models.ItemPedido;

namespace UrbanGreen.Application.Models.Pedido;

public class ReadPedidoDto
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string NomeComprador { get; set; }
    public double ValorTotal { get; set; }
    public List<ReadItemPedidoDto> ItemPedidos { get; set; }
}
