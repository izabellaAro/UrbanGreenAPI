using System.ComponentModel.DataAnnotations;

namespace UrbanGreen.Application.Models.Fornecedor;

public class UpdateFornecedorDto
{
    [Required(ErrorMessage = "O nome do Fornecedor é obrigatório")]
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    
}
