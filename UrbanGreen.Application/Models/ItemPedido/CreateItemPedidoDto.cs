using System.ComponentModel.DataAnnotations;

namespace UrbanGreen.Application.Models.ItemPedido;

public class CreateItemPedidoDto
{
    [Required(ErrorMessage = "A quantidade é obrigatória.")]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
    public int Quantidade { get; set; }
    [Required]
    public int ProdutoId { get; set; }
}
