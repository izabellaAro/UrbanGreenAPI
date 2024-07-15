using System.ComponentModel.DataAnnotations;

namespace UrbanGreen.Application.Models.ItemPedido;

public class UpdateItemPedidoDto
{
    [Required(ErrorMessage = "A quantidade é obrigatória.")]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
    public int Quantidade { get; set; }
    public int ProdutoId { get; set; }
}
