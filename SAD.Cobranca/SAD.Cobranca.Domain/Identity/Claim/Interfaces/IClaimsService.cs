using System;
using System.Collections.Generic;
using SAD.Cobranca.Domain.Identity.Commands;

namespace SAD.Cobranca.Domain.Identity.Interfaces
{
    public interface IClaimsService
    {
        Claims Registrar(RegistrarClaimsCommand command);
        Claims Editar(EditarClaimsCommand command);
        void Remover(Guid id);
        Claims ObterPorId(Guid id);
        IEnumerable<Claims> ObterTodos();
        Claims ObterPorNome(string nomeClaim);
    }
}
