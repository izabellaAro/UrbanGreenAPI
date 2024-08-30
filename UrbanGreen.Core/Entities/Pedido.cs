using System.Xml;

namespace UrbanGreen.Core.Entities;

public class Pedido
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string? NomeComprador { get; set; }
    public double ValorTotal { get; set; }
    public ICollection<ItemPedido> ItemPedidos {  get; set; } 

    public Pedido() 
    {
        ItemPedidos = new List<ItemPedido>();
    }

    public Pedido(DateTime data, string nomeComprador, double valorTotal)
    {
        Data = data;
        NomeComprador = nomeComprador;
        ItemPedidos = new List<ItemPedido>();
        ValorTotal = valorTotal;
    }

        public void Update(DateTime data, string nomeComprador, double valorTotal)
        {
            Data = data;
            NomeComprador = nomeComprador;
            ItemPedidos = new List<ItemPedido>();
            ValorTotal = valorTotal;
    }
}
