using System.ComponentModel.DataAnnotations;

namespace UrbanGreen.Application.Models.FornecedorDto;

public class CreateFornecedorDto
{
    [Required(ErrorMessage = "O nome do Fornecedor é obrigatório")]
    public string Nome { get; set; }
    [Required]
    public int PessoaJuridicaId { get; set; }
    [Required]
    public int InsumoId { get; set; }
}
