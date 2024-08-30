using System.ComponentModel.DataAnnotations;
using UrbanGreen.Application.Models.PessoaJuridica;

namespace UrbanGreen.Application.Models.Fornecedor;

public record CreateFornecedorDto
{
    [Required(ErrorMessage = "O nome do Fornecedor é obrigatório")]
    public string Nome { get; init; }
    [Required]
    public int InsumoId { get; init; }
    public CreatePessoaJuridicaDto PessoaJuridica { get; init; }
}
