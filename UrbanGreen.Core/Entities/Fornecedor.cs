using UrbanGreenAPI.Core.Entities;

namespace UrbanGreen.Core.Entities;

public class Fornecedor
{
    public int FornecedorId { get; set; }
    public string Nome { get; set; }
    public int PessoaJuridicaId { get; set; }
    public virtual PessoaJuridica PessoaJuridica { get; set; }
    public int InsumoId { get; set; }
    public virtual Insumo Insumo { get; set; }

    public Fornecedor() { }

    public Fornecedor(string nome, int insumoId, string nomeFantasia, string cnpj, string razaoSocial,
        string email, string telefone)
    {
        Nome = nome;
        PessoaJuridica = new (nomeFantasia, cnpj, razaoSocial, email, telefone);
        InsumoId = insumoId;
    }

    public Fornecedor(string nome, int insumoId, PessoaJuridica pessoaJuridica)
    {
        Nome = nome;
        InsumoId = insumoId;
        PessoaJuridica = pessoaJuridica;
    }

    public void Update(string nome, string email, string telefone)
    {
        Nome = nome;
        PessoaJuridica.Update(email, telefone);
    }
}
