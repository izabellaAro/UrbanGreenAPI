namespace UrbanGreen.Core.Entities
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public ItemPedido() { }

        public ItemPedido(Produto produto, int quantidade, int produtoId) 
        {
            Produto = produto;
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }

        public void Update(int quantidade, Produto produto, int produtoId)
        {
            Quantidade = quantidade;
            Produto = produto;
            ProdutoId = produtoId;
        }
    }
}
