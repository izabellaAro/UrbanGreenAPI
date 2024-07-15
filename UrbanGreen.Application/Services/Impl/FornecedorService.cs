using UrbanGreen.Application.Interface;
using UrbanGreen.Application.Models.FornecedorDto;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Interface;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.Application.Services.Impl
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;
        private readonly IInsumoRepository _insumoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IPessoaJuridicaRepository pessoaJuridicaRepository, IInsumoRepository insumoRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _insumoRepository = insumoRepository;
        }
        public async Task<bool> AtualizarFornecedor(int id, UpdateFornecedorDto FornecedorDto)
        {
            var fornecedor = await _fornecedorRepository.ConsultarFornecedorPorID(id);
            if (fornecedor == null) return false;
            fornecedor.Update(FornecedorDto.Nome);
            await _fornecedorRepository.UpdateAsync(fornecedor);
            return true;
        }

        public async Task CadastrarFornecedor(CreateFornecedorDto FornecedorDto)
        {
            var insumo = await _insumoRepository.ConsultarInsumoPorID(FornecedorDto.InsumoId);
            var pessoaJuridica = await _pessoaJuridicaRepository.ConsultarPJPorID(FornecedorDto.PessoaJuridicaId);

            if (pessoaJuridica == null || insumo == null)
            {
                throw new Exception("Pessoa Jurídica ou insumo não encontrado.");
            }
            var fornecedor = new Fornecedor(FornecedorDto.Nome, pessoaJuridica, insumo, insumo.Id);
            await _fornecedorRepository.AddAsync(fornecedor);
        }

        public async Task<ReadFornecedorDto> ConsultarFornecedorPorID(int id)
        {
            var fornecedorID = await _fornecedorRepository.ConsultarFornecedorPorID(id);

            if (fornecedorID == null) return null;

            return new ReadFornecedorDto
            {
                FornecedorId = fornecedorID.FornecedorId,
                Nome = fornecedorID.Nome,
                PessoaJuridicaId = fornecedorID.PessoaJuridicaId,
                InsumoId = fornecedorID.InsumoId
            };
        }

        public async Task<IEnumerable<ReadFornecedorDto>> ConsultarFornecedor(int skip = 0, int take = 20)
        {
            var consultaFornecedor = await _fornecedorRepository.ConsultarFornecedor(skip, take);

            return consultaFornecedor.Select(fornecedor => new ReadFornecedorDto
            {
                FornecedorId = fornecedor.FornecedorId,
                Nome = fornecedor.Nome
            }).ToList();
        }

        public async Task<bool> DeletarFornecedor(int id)
        {
            var fornecedor = await _fornecedorRepository.ConsultarFornecedorPorID(id);
            if (fornecedor == null) return false;
            await _fornecedorRepository.DeleteAsync(fornecedor);
            return true;
        }
    }
}
