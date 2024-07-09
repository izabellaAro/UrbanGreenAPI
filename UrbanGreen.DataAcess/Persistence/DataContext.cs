using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UrbanGreen.Core.Entities;
using UrbanGreenAPI.Core.Entities;

namespace UrbanGreen.DataAcess.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

    public DbSet<Insumo> Insumos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Inspecao> Inspecoes { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
