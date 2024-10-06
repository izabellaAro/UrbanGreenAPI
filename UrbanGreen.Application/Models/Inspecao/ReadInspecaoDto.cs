using System.ComponentModel.DataAnnotations;

namespace UrbanGreen.Application.Models.Inspecao;

public class ReadInspecaoDto
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public string Registro { get; set; }
    public List<ReadItemInspecaoDto> Itens { get; set; }
    public int QntColhida { get; set; }
}
