using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanGreen.Core.Entities
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int PessoaJuridicaId { get; set; }
        public virtual PessoaJuridica PessoaJuridica { get; set; }

        public Fornecedor() { }

        public Fornecedor(string nome, string cnpj, PessoaJuridica pessoaJuridica)
        {
            Nome = nome;
            Cnpj = cnpj;
            PessoaJuridica = pessoaJuridica;
            PessoaJuridicaId = pessoaJuridica.Id;
        }

        public void Update(string nome, string Cnpj)
        {
            Nome = nome;
            Cnpj = Cnpj;
        }
    }
}
