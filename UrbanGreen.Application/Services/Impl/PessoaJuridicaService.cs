using UrbanGreen.Application.Models.PessoaJuridica;
using UrbanGreen.Application.Services.Interfaces;
using UrbanGreen.Core.Entities;
using UrbanGreen.DataAcess.Repositories.Interfaces;

namespace UrbanGreen.Application.Services.Impl;

public class PessoaJuridicaService : IPessoaJuridicaService
{
    private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;

    public PessoaJuridicaService(IPessoaJuridicaRepository pessoaJuridicaRepository)
    {
        _pessoaJuridicaRepository = pessoaJuridicaRepository;
    }

    public async Task<bool> AtualizarPJ(int id, UpdatePessoaJuridicaDto pessoaJuridicaDto)
    {
        var pessoaJuridica = await _pessoaJuridicaRepository.ConsultarPJPorID(id);
        if(pessoaJuridica == null) return false;
        pessoaJuridica.Update(pessoaJuridicaDto.NomeFantasia, 
            pessoaJuridicaDto.CNPJ, pessoaJuridicaDto.RazaoSocial, 
            pessoaJuridicaDto.Email, pessoaJuridicaDto.Telefone);
        await _pessoaJuridicaRepository.UpdateAsync(pessoaJuridica);
        return true;
    }

    public async Task CadastrarPJ(CreatePessoaJuridicaDto pessoaJuridicaDto)
    {
        var pessoaJuridica = new PessoaJuridica(pessoaJuridicaDto.NomeFantasia,
            pessoaJuridicaDto.CNPJ, pessoaJuridicaDto.RazaoSocial,
            pessoaJuridicaDto.Email, pessoaJuridicaDto.Telefone);
        await _pessoaJuridicaRepository.AddAsync(pessoaJuridica);
    }

    public async Task<IEnumerable<ReadPessoaJuridicaDto>> ConsultarPJ(int skip = 0, int take = 20)
    {
        var consultaPJ = await _pessoaJuridicaRepository.ConsultarPJ(skip, take);

        return consultaPJ.Select(pj => new ReadPessoaJuridicaDto
        {
            Id = pj.Id,
            NomeFantasia = pj.NomeFantasia,
            CNPJ = pj.CNPJ,
            RazaoSocial = pj.RazaoSocial,
            Email = pj.Email,
            Telefone = pj.Telefone
        }).ToList();
    }

    public async Task<ReadPessoaJuridicaDto> ConsultarPJPorID(int id)
    {
        var pjID = await _pessoaJuridicaRepository.ConsultarPJPorID(id);
        if (pjID == null) return null;
        return new ReadPessoaJuridicaDto
        {
            Id = pjID.Id,
            NomeFantasia = pjID.NomeFantasia,
            CNPJ = pjID.CNPJ,
            RazaoSocial = pjID.RazaoSocial,
            Email = pjID.Email,
            Telefone = pjID.Telefone
        };
    }

    public async Task<bool> DeletarPJ(int id)
    {
        var pessoaJuridica = await _pessoaJuridicaRepository.ConsultarPJPorID(id);
        if (pessoaJuridica == null) return false;
        await _pessoaJuridicaRepository.DeleteAsync(pessoaJuridica);
        return true;
    }
}