using FluentValidation;
using SAD.Cobranca.Domain.Identity.Interfaces;

namespace SAD.Cobranca.Domain.Identity.Validations
{
    public class ClaimsAptoParaRegistroValidation : AbstractValidator<Claims>
    {
        private readonly IClaimsRepository _claimsRepository;

        public ClaimsAptoParaRegistroValidation(IClaimsRepository claimsRepository)
        {
            _claimsRepository = claimsRepository;

            RuleFor(claim => claim.Name)
                .Must(ClaimDeveSerUnico)
                .WithMessage("Claim já registrado.")
                .When(x => !string.IsNullOrEmpty(x.Name));
        }

        private bool ClaimDeveSerUnico(Claims claim, string nomeClaim)
        {
            var claimRetorno = _claimsRepository.ObterPorNome(claim.Name);
            if (claimRetorno == null)
            {
                return true;
            }

            return claimRetorno.Id == claim.Id;
        }
    }
}