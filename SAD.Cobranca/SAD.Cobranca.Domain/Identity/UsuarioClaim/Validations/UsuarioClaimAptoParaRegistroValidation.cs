using FluentValidation;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Interfaces;

namespace SAD.Cobranca.Domain.Identity.UsuarioClaim.Validations
{
    public class UsuarioClaimAptoParaRegistroValidation : AbstractValidator<UsuarioClaim>
    {
        private readonly IUsuarioClaimsRepository _usuarioClaimsRepository;

        public UsuarioClaimAptoParaRegistroValidation(IUsuarioClaimsRepository usuarioClaimsRepository)
        {
            _usuarioClaimsRepository = usuarioClaimsRepository;

            RuleFor(usuarioClaim => usuarioClaim.ClaimType)
                .Must(UsuarioJaPossuiClaim)
                .WithMessage("Usuário já possui o claim selecionado.")
                .When(x => !string.IsNullOrEmpty(x.ClaimType));
        }

        private bool UsuarioJaPossuiClaim(UsuarioClaim usuarioClaims, string claimType)
        {
            var usuarioClaimRetorno = _usuarioClaimsRepository.ObterPorClaimType(usuarioClaims.UserId, usuarioClaims.ClaimType);
            if (usuarioClaimRetorno == null)
            {
                return true;
            }

            return usuarioClaimRetorno.Id == usuarioClaims.Id;
        }
    }
}
