using CC.SAD.Cobranca.Domain.Core.Commands;

namespace SAD.Cobranca.Domain.Identity.Commands
{
    public class RegistrarClaimsCommand : ICommandInput
    {
        public RegistrarClaimsCommand(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
