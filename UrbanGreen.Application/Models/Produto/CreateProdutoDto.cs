using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace UrbanGreen.Application.Models.Produto;

public class CreateProdutoDto
{
    [Required(ErrorMessage = "O nome do Produto é obrigatório")]
    public string Nome { get; set; }

    [Required]
    [Range(1, 5000, ErrorMessage = "A quantidade de Produto é obrigatória e deve ser entre 1 a 5000")]
    public int Quantidade { get; set; }

    [Required]
    [Range(1, 10000, ErrorMessage = "O valor do Produto é obrigatório e deve ser entre R$1 a R$10000")]
    public double Valor { get; set; }

    public IFormFile? Imagem { get; set; }
}
