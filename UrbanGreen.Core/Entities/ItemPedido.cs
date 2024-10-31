namespace UrbanGreen.Core.Entities;

public class ItemPedido
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public virtual Produto Produto { get; set; }
    public int Quantidade { get; set; }
    public double ValorProduto { get; set; }
    public Pedido Pedido { get; set; }
    public int? PedidoId { get; set; }
    public double ValorTotal => ValorProduto * Quantidade;

    private ItemPedido() { }

    public ItemPedido(Produto produto, int quantidade) 
    {
        Quantidade = quantidade;
        Produto = produto;
        ValorProduto = produto.Valor;
    }
}
