namespace UrbanGreen.Application.Models.FornecedorDto;

public class ReadFornecedorDto
{
    public int FornecedorId { get; set; }
    public string Nome { get; set; }
    public int PessoaJuridicaId { get; set; }
    public int InsumoId { get; set; }
    public string NomePJ { get; set; }
    public string Insumo {  get; set; }
}
