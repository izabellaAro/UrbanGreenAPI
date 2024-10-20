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

    public Inspecao() { }

    public Inspecao(int produtoId)
    {
        ProdutoId = produtoId;
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

    public void UpdateRegistro(string registro)
    {
        Registro = registro;
    }
}
