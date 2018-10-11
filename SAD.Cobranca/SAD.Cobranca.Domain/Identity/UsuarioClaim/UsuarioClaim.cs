using FluentValidation.Results;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Validations;

namespace SAD.Cobranca.Domain.Identity.UsuarioClaim
{
    public class UsuarioClaim
    {
        protected UsuarioClaim()
        {
        }

        public UsuarioClaim(string userId, string claimType, string claimValue)
        {
            UserId = userId;
            ClaimType = claimType;
            ClaimValue = claimValue;
        }

        public int Id { get; private set; }
        public string UserId { get; private set; }
        public string ClaimType { get; private set; }
        public string ClaimValue { get; private set; }
        public Usuario.Usuario Usuario { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool valido()
        {
            ValidationResult = new UsuarioClaimConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public void PreencherId(int id) => Id = id;
    }
}
