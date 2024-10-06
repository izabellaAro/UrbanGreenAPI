using System.ComponentModel.DataAnnotations;

namespace UrbanGreen.Application.Models.Inspecao;

public class CreateInspecaoDto
{
    public int ProdutoId { get; set; }
    public string Registro { get; set; }
    public List<UpdateItemInspecaoDto> Itens { get; set; }
    [Required]
    [Range(1, 10000, ErrorMessage = "A quantidade colhida do Insumo é obrigatória e deve ser entre 1 a 10000")]
    public int QntColhida { get; set; }

}