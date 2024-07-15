namespace UrbanGreen.Core.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string? NomeComprador { get; set; }
        public double ValorTotal { get; set; }
        public List<int> ItemPedidoId { get; set; }

        public Pedido() 
        {
        }

        public Pedido(DateTime data, string? nomeComprador, List<int> itemPedidoId, double valorTotal)
        {
            Data = data;
            NomeComprador = nomeComprador;
            ItemPedidoId = itemPedidoId;
            ValorTotal = valorTotal;
        }

            public void Update(DateTime data, List<int> itemPedidoId)
            {
                Data = data;
                ItemPedidoId = itemPedidoId;
        }
    }
}
