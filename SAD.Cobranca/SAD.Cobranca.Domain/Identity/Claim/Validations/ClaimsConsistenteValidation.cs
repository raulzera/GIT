using FluentValidation;

namespace SAD.Cobranca.Domain.Identity.Validations
{
    public class ClaimsConsistenteValidation : AbstractValidator<Claims>
    {
        public ClaimsConsistenteValidation()
        {
            RuleFor(claim => claim.Name)
                .NotEmpty()
                .WithMessage("Preencha o nome da claim.");

            RuleFor(claim => claim.Name)
                .Must(x => x.Length <= 256)
                .WithMessage("O nome da claim deve possuir no máximo 256 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Name));
        }
    }
}
