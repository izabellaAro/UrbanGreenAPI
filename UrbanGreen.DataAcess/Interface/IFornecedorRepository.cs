using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Interface
{
    public interface IFornecedorRepository : IBaseRepository<Fornecedor>
    {
        Task<IEnumerable<Fornecedor>> ConsultarFornecedor(int skip, int take);
        Task<Fornecedor> ConsultarFornecedorPorID(int id);
    }
}
