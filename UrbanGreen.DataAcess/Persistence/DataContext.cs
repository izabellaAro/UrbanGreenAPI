using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UrbanGreenAPI.Core.Entities;

namespace UrbanGreen.DataAcess.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

    public DbSet<Insumo> Insumos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
