using System.ComponentModel.DataAnnotations;

namespace UrbanGreen.Application.Models.Inspecao;

public class UpdateInspecaoDto
{
    [Required]
    public int ProdutoId { get; set; }
    public string Registro { get; set; }
    public List<UpdateItemInspecaoDto> Itens { get; set; }
}
