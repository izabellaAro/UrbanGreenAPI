using UrbanGreen.Application.Models.PessoaJuridica;

namespace UrbanGreen.Application.Services.Interfaces;

public interface IPessoaJuridicaService
{
    Task CadastrarPJ(CreatePessoaJuridicaDto pessoaJuridicaDto);
    Task<IEnumerable<ReadPessoaJuridicaDto>> ConsultarPJ(int skip = 0, int take = 20);
    Task<ReadPessoaJuridicaDto> ConsultarPJPorID(int id);
    Task<bool> AtualizarPJ(int id, UpdatePessoaJuridicaDto pessoaJuridicaDto);
    Task<bool> DeletarPJ(int id);
}
