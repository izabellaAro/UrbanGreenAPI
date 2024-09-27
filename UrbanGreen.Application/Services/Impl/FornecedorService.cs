using UrbanGreen.Application.Interface;
using UrbanGreen.Application.Models.Fornecedor;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Interface;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.Application.Services.Impl;

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
        fornecedor.Update(FornecedorDto.Nome, FornecedorDto.Email, FornecedorDto.Telefone);
        await _fornecedorRepository.UpdateAsync(fornecedor);
        return true;
    }

    public async Task CadastrarFornecedor(CreateFornecedorDto fornecedorDto)
    {
        var pessoaJuridicaDto = fornecedorDto.PessoaJuridica;

        var insumo = await _insumoRepository.ConsultarInsumoPorID(fornecedorDto.InsumoId);

        var pessoaJuridica = new PessoaJuridica(pessoaJuridicaDto.NomeFantasia, pessoaJuridicaDto.CNPJ, pessoaJuridicaDto.RazaoSocial,
            pessoaJuridicaDto.Email, pessoaJuridicaDto.Telefone);

        var fornecedor = new Fornecedor(fornecedorDto.Nome, insumo.Id, pessoaJuridica);

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
                 InsumoId = fornecedorID.InsumoId,
                 NomePJ = fornecedorID.PessoaJuridica.NomeFantasia,
                 Insumo = fornecedorID.Insumo.Nome,
                 Telefone = fornecedorID.PessoaJuridica.Telefone,
                 Email = fornecedorID.PessoaJuridica.Email,
                 Valor = fornecedorID.Insumo.Valor
             };
    }

    public async Task<IEnumerable<ReadFornecedorDto>> ConsultarFornecedor(int skip = 0, int take = 20)
    {
        var consultaFornecedor = await _fornecedorRepository.ConsultarFornecedor(skip, take);

        return consultaFornecedor.Select(fornecedor => new ReadFornecedorDto
        {
            FornecedorId = fornecedor.FornecedorId,
            Nome = fornecedor.Nome,
            PessoaJuridicaId = fornecedor.PessoaJuridicaId,
            InsumoId = fornecedor.InsumoId,
            NomePJ = fornecedor.PessoaJuridica.NomeFantasia,
            Insumo = fornecedor.Insumo.Nome,
            Telefone = fornecedor.PessoaJuridica.Telefone,
            Email = fornecedor.PessoaJuridica.Email,
            Valor = fornecedor.Insumo.Valor
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
