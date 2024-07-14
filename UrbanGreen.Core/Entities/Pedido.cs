namespace UrbanGreen.Core.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string NomeComprador { get; set; }
        public double ValorTotal { get; set; }
        public int ItemPedidoId { get; set; }
        public virtual ItemPedido ItemPedido { get; set; }


        public Pedido() { }

        public Pedido(DateTime data, string nomeComprador, ItemPedido itemPedido, int itemPedidoId, double valorTotal)
        {
            Data = data;
            NomeComprador = nomeComprador;
            ItemPedido = itemPedido;
            ItemPedidoId = itemPedidoId;
            ValorTotal = valorTotal;
        }

            public void Update(DateTime data, string nomeComprador, ItemPedido itemPedido, int itemPedidoId)
            {
                Data = data;
                NomeComprador = nomeComprador;
                ItemPedido = itemPedido;
                ItemPedidoId = itemPedidoId;
        }
        
    }
}
