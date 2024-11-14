using System.ComponentModel.DataAnnotations;
using UrbanGreen.Application.Models.ItemPedido;

namespace UrbanGreen.Application.Models.Pedido;

public class CreatePedidoDto
{
    [Required(ErrorMessage = "O nome do comprador é obrigatório")]
    public string NomeComprador { get; set; }
    [Required]
    public List<CreateItemPedidoDto> ItensPedido { get; set; }
}