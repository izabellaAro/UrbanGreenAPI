using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.DataAcess.Interface;

public interface IFornecedorRepository : IBaseRepository<Fornecedor>
{
    Task<IEnumerable<Fornecedor>> ConsultarFornecedor(int skip, int take);
    Task<Fornecedor> ConsultarFornecedorPorID(int id);
}
