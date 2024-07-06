using System.ComponentModel.DataAnnotations;

namespace UrbanGreen.Application.Models.PessoaJuridica;

public  class UpdatePessoaJuridicaDto
{
    [Required(ErrorMessage = "O nome fantasia é obrigatório")]
    public string NomeFantasia { get; set; }

    [Required]
    [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve possuir exatamente 14 caracteres")]
    public string CNPJ { get; set; }

    [Required(ErrorMessage = "A razão social é obrigatória")]
    public string RazaoSocial { get; set; }

    [EmailAddress]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "O e-mail deve estar em um formato válido.")]
    public string Email { get; set; }

    [Required]
    [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "O número de telefone deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.")]
    public string Telefone { get; set; }
}
