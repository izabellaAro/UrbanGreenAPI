namespace UrbanGreen.Core.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string? NomeComprador { get; set; }
        public double ValorTotal { get; set; }
        public int ItemPedidoId { get; set; }
        //public virtual ItemPedido ItensPedidos { get; set; }
       // public ICollection<ItemPedido> ItensPedidos { get; set; }


        public Pedido() 
        {
           // ItensPedidos = new List<ItemPedido>();
        }

        public Pedido(DateTime data, string? nomeComprador, int itemPedidoId, double valorTotal)
        {
            Data = data;
            NomeComprador = nomeComprador;
            //ItemPedido = itemPedido;
            ItemPedidoId = itemPedidoId;
            ValorTotal = valorTotal;
        }

            public void Update(DateTime data, int itemPedidoId)
            {
                Data = data;
                //ItemPedido = itemPedido;
                ItemPedidoId = itemPedidoId;
        }
        
    }
}
