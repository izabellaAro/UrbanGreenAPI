namespace UrbanGreen.Application.Models.Inspecao;

public class CreateInspecaoDto
{
    public int ProdutoId { get; set; }
    public string Registro { get; set; }
    public List<UpdateItemInspecaoDto> Itens { get; set; }
}