using System;

namespace SAD.Cobranca.Domain.Identity.Commands
{
    public class EditarClaimsCommand
    {
        public EditarClaimsCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
