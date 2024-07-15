using System.ComponentModel.DataAnnotations;

namespace UrbanGreen.Application.Models.FornecedorDto
{
    public class UpdateFornecedorDto
    {
        [Required(ErrorMessage = "O nome do Fornecedor é obrigatório")]
        public string Nome { get; set; }
    }
}
