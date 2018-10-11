using FluentValidation;

namespace SAD.Cobranca.Domain.Identity.UsuarioClaim.Validations
{
  public class UsuarioClaimConsistenteValidation : AbstractValidator<UsuarioClaim>
        {
            public UsuarioClaimConsistenteValidation()
            {
                RuleFor(usuarioClaim => usuarioClaim.UserId)
                    .NotNull()
                    .WithMessage("Selecione o usuário");

                RuleFor(usuarioClaim => usuarioClaim.ClaimType)
                    .NotEmpty()
                    .WithMessage("Selecione um claim.");

                RuleFor(usuarioClaim => usuarioClaim.ClaimValue)
                    .NotEmpty()
                    .WithMessage("Preencha o valor do claim.");
            }
        }
    }