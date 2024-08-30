namespace UrbanGreen.Core.Entities;

public class PessoaJuridica
{
    public int Id { get; set; }
    public string NomeFantasia { get; set; }
    public string CNPJ { get; set; }
    public string RazaoSocial { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

    public PessoaJuridica() { }

    public PessoaJuridica(string nomeFantasia, string cnpj, string razaoSocial, string email, string telefone)
    {
        NomeFantasia = nomeFantasia;
        CNPJ = cnpj;
        RazaoSocial = razaoSocial;
        Email = email;
        Telefone = telefone;
    }

    //atualizacao de fornecedor
    public void Update(string email, string telefone)
    {
        Email = email;
        Telefone = telefone;
    }

    public void Update(string nomeFantasia, string cnpj, string razaoSocial, string email, string telefone)
    {
        NomeFantasia = nomeFantasia;
        CNPJ = cnpj;
        RazaoSocial = razaoSocial;
        Email = email;
        Telefone = telefone;
    }
}
