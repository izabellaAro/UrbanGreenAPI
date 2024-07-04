using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanGreen.Application.Models.FornecedorDto
{
    public class UpdateFornecedorDto
    {
        [Required(ErrorMessage = "O nome do Fornecedor é obrigatório")]
        public string Nome { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve possuir exatamente 14 caracteres")]
        public string Cnpj { get; set; }
    }
}
