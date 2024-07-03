using System.ComponentModel.DataAnnotations;

namespace UrbanGreen.Application.Models.FornecedorDto
{
    public class CreateFornecedorDto
    {
        public int FornecedorId { get; set; }
        [Required(ErrorMessage = "O nome do Fornecedor é obrigatório")]
        public string Nome { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve possuir exatamente 14 caracteres")]
        public string Cnpj { get; set; }
    }
}
