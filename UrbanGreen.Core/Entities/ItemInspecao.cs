namespace UrbanGreen.Core.Entities;

public class ItemInspecao
{
    public int Id { get; private set; }
    public bool Realizado { get; private set; }
    public int TipoItemInspecaoId { get; private set; }
    public DateTime Data { get; private set; }
    public TipoItemInspecao TipoItemInspecao { get; private set; }
    public Inspecao Inspecao { get; set; }
    public int InspecaoId { get; set; }

    private ItemInspecao() { }

    public ItemInspecao(Inspecao inspecao, DateTime data, int tipoId, bool realizado)
    {
        Inspecao = inspecao;
        Data = data;
        TipoItemInspecaoId = tipoId;
        Realizado = realizado;
    }

    public void Update(DateTime data, bool realizado)
    {
        Data = data;
        Realizado = realizado;
    }
}
