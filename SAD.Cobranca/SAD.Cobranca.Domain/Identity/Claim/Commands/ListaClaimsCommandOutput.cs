using System;
using CC.SAD.Cobranca.Domain.Core.Commands;

namespace SAD.Cobranca.Domain.Identity.Commands
{
    public class ListaClaimsCommandOutput : ICommandInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}