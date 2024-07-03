using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanGreen.Application.Models.FornecedorDto
{
    public class ReadFornecedorDto
    {
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
    }
}
