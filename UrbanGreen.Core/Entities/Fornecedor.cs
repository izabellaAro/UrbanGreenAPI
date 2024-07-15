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

    public Fornecedor(string nome, PessoaJuridica pessoaJuridica, Insumo insumo, int insumoId)
    {
        Nome = nome;
        PessoaJuridica = pessoaJuridica;
        PessoaJuridicaId = pessoaJuridica.Id;
        Insumo = insumo;
        InsumoId = insumoId;
    }

    public void Update(string nome)
    {
        Nome = nome;
    }
}
