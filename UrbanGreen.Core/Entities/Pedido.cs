namespace UrbanGreen.Core.Entities;

public class Pedido
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string? NomeComprador { get; set; }
    public double ValorTotal => ItemPedidos.Sum(x => x.ValorTotal);
    public ICollection<ItemPedido> ItemPedidos {  get; set; } = new List<ItemPedido>();

    public Pedido(string nomeComprador)
    {
        NomeComprador = nomeComprador;
        Data = DateTime.Now;
    }

    public void AdicionarItem(ItemPedido itemPedido)
    {
        ItemPedidos.Add(itemPedido);
    }
}
