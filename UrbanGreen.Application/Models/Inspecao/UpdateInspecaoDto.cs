using System.ComponentModel.DataAnnotations;

namespace UrbanGreen.Application.Models.Inspecao;

public class UpdateInspecaoDto
{
    public DateTime Data = DateTime.Now;
    [Required]
    public bool SelecaoSemente { get; set; }
    [Required]
    public bool ControlePragas { get; set; }
    [Required]
    public bool Irrigacao { get; set; }
    [Required]
    public bool CuidadoSolo { get; set; }
    [Required]
    public bool Colheita { get; set; }
    [Required]
    public int ProdutoId { get; set; }
}
