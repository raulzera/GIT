using System;
using System.Collections.Generic;

namespace SAD.Cobranca.Domain.Identity.Interfaces
{
    public interface IClaimsRepository
    {
        Claims Registrar(Claims claim);
        Claims Editar(Claims command);
        void Remover(Guid id);
        Claims ObterPorId(Guid id);
        IEnumerable<Claims> ObterTodos();
        Claims ObterPorNome(string nomeClaim);
    }
}