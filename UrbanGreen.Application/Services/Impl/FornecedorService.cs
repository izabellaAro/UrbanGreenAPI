using UrbanGreen.Application.Interface;
using UrbanGreen.Application.Models.FornecedorDto;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Interface;

namespace UrbanGreen.Application.Services.Impl
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }
        public async Task<bool> AtualizarFornecedor(int id, UpdateFornecedorDto FornecedorDto)
        {
            var fornecedor = await _fornecedorRepository.ConsultarFornecedorPorID(id);
            if (fornecedor == null) return false;
            fornecedor.Update(FornecedorDto.Nome, FornecedorDto.Cnpj);
            await _fornecedorRepository.UpdateAsync(fornecedor);
            return true;
        }

        public async Task CadastrarFornecedor(CreateFornecedorDto FornecedorDto)
        {
            var fornecedor = new Fornecedor(FornecedorDto.Nome, FornecedorDto.Cnpj);
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
                Cnpj = fornecedorID.Cnpj
            };
        }

        public async Task<IEnumerable<ReadFornecedorDto>> ConsultarFornecedor(int skip = 0, int take = 20)
        {
            var consultaFornecedor = await _fornecedorRepository.ConsultarFornecedor(skip, take);

            return consultaFornecedor.Select(fornecedor => new ReadFornecedorDto
            {
                FornecedorId = fornecedor.FornecedorId,
                Nome = fornecedor.Nome,
                Cnpj = fornecedor.Cnpj
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
