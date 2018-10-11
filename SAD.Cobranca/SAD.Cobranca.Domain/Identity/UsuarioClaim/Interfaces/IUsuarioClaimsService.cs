using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Commands;

namespace SAD.Cobranca.Domain.Identity.UsuarioClaim.Interfaces
{
    public interface IUsuarioClaimsService
    {
        UsuarioClaim Registrar(RegistrarUsuarioClaimCommand command);
        UsuarioClaim Editar(EditarUsuarioClaimCommand command);
        void Remover(int id);
        ListarUsuarioClaimCommandOutput ObterPorId(int id);
        IEnumerable<ListarUsuarioClaimCommandOutput> ObterTodos();
        IEnumerable<ListarUsuarioClaimCommandOutput> ObterUsuarioClaim(string id);
    }
}
