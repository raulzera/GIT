using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation.Results;

namespace SAD.Cobranca.Application.Identity.UsuarioClaims
{
    public class UsuarioClaimsViewModel
    {
        public int Id { get; set; }

        [DisplayName("Usuário")]
        public string UserId { get; set; }

        [DisplayName("Claim")]
        public string ClaimType { get; set; }

        [DisplayName("Valor")]
        public string ClaimValue { get; set; }

        [DisplayName("Username")]
        public string Username { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
    }
}
