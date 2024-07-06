using System.ComponentModel.DataAnnotations;

namespace UrbanGreen.Application.Models.Insumo;

public class UpdateInsumoDto
{
    [Required(ErrorMessage = "O nome do Insumo é obrigatório")]
    public string Nome { get; set; }

    [Required]
    [Range(1, 5000, ErrorMessage = "A quantidade de Insumo é obrigatória e deve ser entre 1 a 5000")]
    public int Quantidade { get; set; }

    [Required]
    [Range(1, 10000, ErrorMessage = "O valor do Insumo é obrigatória e deve ser entre R$1 a R$10000")]
    public double Valor { get; set; }
}
