using System.Security.Claims;
using UrbanGreen.Application.Models.Usuario;

namespace UrbanGreen.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List< ConsultaUsuarioDto>> ListarUsuarios();
        Task<ConsultaUsuarioDto> ObterUsuarioPorId(string id);
        Task<ConsultaUsuarioDto> GetCurrentUser(ClaimsPrincipal userClaim);
        Task<bool?> ExcluirUsuario(string id);
        Task<bool?> EditarUsuario(string id, UpdateUsuarioDto model);
        Task<bool> Registrar(RegistroNovoUsuario model);
        Task<dynamic> Login(Login model);
    }
}
