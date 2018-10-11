using System.Collections.Generic;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Commands;

namespace SAD.Cobranca.Domain.Identity.UsuarioClaim.Interfaces
{
    public interface IUsuarioClaimsRepository
    {
        UsuarioClaim Registrar(UsuarioClaim usuarioClaim);
        UsuarioClaim Editar(UsuarioClaim usuarioClaim);
        void Remover(int id);
        IEnumerable<ListarUsuarioClaimCommandOutput> ObterTodos();
        IEnumerable<ListarUsuarioClaimCommandOutput> ObterUsuarioClaim(string id);
        UsuarioClaim ObterPorClaimType(string id, string claimType);
        ListarUsuarioClaimCommandOutput ObterPorId(int id);
    }
}
