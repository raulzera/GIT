using CC.SAD.Cobranca.Domain.Core.Commands;

namespace SAD.Cobranca.Domain.Identity.UsuarioClaim.Commands
{
    public class EditarUsuarioClaimCommand : ICommandInput
    {
        public EditarUsuarioClaimCommand(int id, string userId, string claimType, string claimValue)
        {
            Id = id;
            UserId = userId;
            ClaimType = claimType;
            ClaimValue = claimValue;
        }

        public int Id { get; private set; }
        public string UserId { get; private set; }
        public string ClaimType { get; private set; }
        public string ClaimValue { get; private set; }
    }
}
