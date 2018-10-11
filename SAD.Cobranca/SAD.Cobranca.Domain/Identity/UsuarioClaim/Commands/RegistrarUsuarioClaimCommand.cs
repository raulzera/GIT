using CC.SAD.Cobranca.Domain.Core.Commands;

namespace SAD.Cobranca.Domain.Identity.UsuarioClaim.Commands
{
    public class RegistrarUsuarioClaimCommand : ICommandInput
    {
        public RegistrarUsuarioClaimCommand(string userId, string claimType, string claimValue)
        {
            UserId = userId;
            ClaimType = claimType;
            ClaimValue = claimValue;
        }

        public string UserId { get; private set; }
        public string ClaimType { get; private set; }
        public string ClaimValue { get; private set; }
    }
}
