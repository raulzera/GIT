using System;
using System.Collections.Generic;

namespace SAD.Cobranca.Application.Identity.Claims.Interfaces
{
    public interface IClaimsAppService
    {
        ClaimsViewModel Registrar(ClaimsViewModel claimViewModel);
        ClaimsViewModel Editar(ClaimsViewModel claimViewModel);
        void Remover(Guid id);
        ClaimsViewModel ObterPorId(Guid claimId);
        IEnumerable<ClaimsViewModel> ObterTodos();
    }
}
