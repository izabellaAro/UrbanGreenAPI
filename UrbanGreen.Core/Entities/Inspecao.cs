namespace UrbanGreen.Core.Entities;

public class Inspecao
{
    public int Id { get; set; }
    public DateTime Data = DateTime.Now;

    public IList<ItemInspecao> Itens { get; private set; } = new List<ItemInspecao>();

    public int ProdutoId { get; set; }
    public virtual Produto Produto { get; set; }
    public int QntColhida { get; set; }
    public string Registro { get; set; }
    public bool Ativa { get; private set; }

    public Inspecao() { }

    public Inspecao(int produtoId)
    {
        ProdutoId = produtoId;
        Ativa = true;
    }

    private void UpdateRegistro(string registro) => Registro = registro;

    private bool PossuiTodosItensRealizados() => Itens.All(x => x.Realizado);

    private void Concluir(int qntColhida)
    {
        QntColhida = qntColhida;
        Ativa = false;
        Produto.AdicionarQuantidade(qntColhida);
    }

    public void UpdateItem(DateTime data, int tipoItemId, bool statusItem)
    {
        var item = Itens.FirstOrDefault(x => x.TipoItemInspecaoId == tipoItemId);

        if (item == null)
        {
            Itens.Add(new ItemInspecao(this, data, tipoItemId, statusItem));
            return;
        }

        item.Update(data, statusItem);
    }

    public void AtualizarComplementos(string registro, int qntColhida)
    {
        UpdateRegistro(registro);

        if (PossuiTodosItensRealizados())
        {
            Concluir(qntColhida);
        }
    }
}
