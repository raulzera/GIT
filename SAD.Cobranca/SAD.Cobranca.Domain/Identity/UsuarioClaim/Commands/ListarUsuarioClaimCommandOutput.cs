using CC.SAD.Cobranca.Domain.Core.Commands;

namespace SAD.Cobranca.Domain.Identity.UsuarioClaim.Commands
{
    public class ListarUsuarioClaimCommandOutput : ICommandInput
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string Username { get; set; }
    }
}
