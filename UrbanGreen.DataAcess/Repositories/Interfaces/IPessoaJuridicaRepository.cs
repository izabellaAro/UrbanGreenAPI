using UrbanGreen.Core.Entities;

namespace UrbanGreen.DataAcess.Repositories.Interfaces;

public interface IPessoaJuridicaRepository : IBaseRepository<PessoaJuridica>
{
    Task<IEnumerable<PessoaJuridica>> ConsultarPJ(int skip, int take);
    Task<PessoaJuridica> ConsultarPJPorID(int id);
}
