namespace UrbanGreen.Application.Models.Fornecedor;

public class ReadFornecedorDto
{
    public int FornecedorId { get; set; }
    public string Nome { get; set; }
    public int PessoaJuridicaId { get; set; }
    public int InsumoId { get; set; }
    public string NomePJ { get; set; }
    public string Insumo {  get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public double Valor {  get; set; }
}
