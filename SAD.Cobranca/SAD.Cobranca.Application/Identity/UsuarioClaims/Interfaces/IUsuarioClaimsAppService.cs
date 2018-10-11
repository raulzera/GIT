using System.Collections.Generic;

namespace SAD.Cobranca.Application.Identity.UsuarioClaims.Interfaces
{
    public interface IUsuarioClaimsAppService
    {
        UsuarioClaimsViewModel Registrar(UsuarioClaimsViewModel usuarioClaimsViewModel);
        UsuarioClaimsViewModel Editar(UsuarioClaimsViewModel usuarioClaimsViewModel);
        void Remover(int id);
        IEnumerable<UsuarioClaimsViewModel> ObterTodos();
        UsuarioClaimsViewModel ObterPorId(int claimId);
        IEnumerable<UsuarioClaimsViewModel> ObterUsuarioClaims(string id);
    }
}
