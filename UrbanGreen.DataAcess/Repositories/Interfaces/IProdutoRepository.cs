using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Repositories.Interfaces;

public interface IProdutoRepository : IBaseRepository<Produto>
{
    Task<IEnumerable<Produto>> ConsultarProdutos(int skip, int take);
    Task<Produto> ConsultarProdutoPorID(int id);
}
