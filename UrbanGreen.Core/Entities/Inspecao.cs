using Microsoft.Win32;

namespace UrbanGreen.Core.Entities;

public class Inspecao
{
    public int Id { get; set; }
    public DateTime Data = DateTime.Now;
    public bool SelecaoSemente { get; set; }
    public bool ControlePragas { get; set; }
    public bool Irrigacao { get; set; }
    public bool CuidadoSolo { get; set; }
    public bool Colheita { get; set; }
    public string Registro { get; set; }
    public int ProdutoId { get; set; }
    public virtual Produto Produto { get; set; }

    public Inspecao() { }

    public Inspecao(DateTime data, bool selecaoSemente, bool controlePragas, bool irrigacao, bool cuidadoSolo, bool colheita, string registro, Produto produto, int produtoId)
    {
        Data = data;
        SelecaoSemente = selecaoSemente;
        ControlePragas = controlePragas;
        Irrigacao = irrigacao;
        CuidadoSolo = cuidadoSolo;
        Colheita = colheita;
        Registro = registro;
        Produto = produto;
        ProdutoId = produtoId;

    }

    public void Update(DateTime data, bool selecaoSemente, bool controlePragas, bool irrigacao, bool cuidadoSolo, bool colheita, string registro, Produto produto, int produtoId)
    {
        Data = data;
        SelecaoSemente = selecaoSemente;
        ControlePragas = controlePragas;
        Irrigacao = irrigacao;
        CuidadoSolo = cuidadoSolo;
        Colheita = colheita;
        Registro = registro;
        Produto = produto;
        ProdutoId = produtoId;
    }
}
