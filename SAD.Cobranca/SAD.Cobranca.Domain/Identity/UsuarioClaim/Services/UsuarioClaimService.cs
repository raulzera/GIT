using System.Collections.Generic;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Commands;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Interfaces;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Validations;

namespace SAD.Cobranca.Domain.Identity.UsuarioClaim.Services
{
    public class UsuarioClaimService : IUsuarioClaimsService
    {
        private readonly IUsuarioClaimsRepository _usuarioClaimsRepository;

        public UsuarioClaimService(IUsuarioClaimsRepository usuarioClaimsRepository)
        {
            _usuarioClaimsRepository = usuarioClaimsRepository;
        }

        public UsuarioClaim Registrar(RegistrarUsuarioClaimCommand command)
        {
            var usuarioClaim = new UsuarioClaim(command.UserId, command.ClaimType, command.ClaimValue);
            if (!usuarioClaim.valido())
            {
                return usuarioClaim;
            }
            usuarioClaim.ValidationResult = new UsuarioClaimAptoParaRegistroValidation(_usuarioClaimsRepository).Validate(usuarioClaim);
            return !usuarioClaim.ValidationResult.IsValid
                ? usuarioClaim
                : _usuarioClaimsRepository.Registrar(usuarioClaim);
        }

        public UsuarioClaim Editar(EditarUsuarioClaimCommand command)
        {
            var usuarioClaim = new UsuarioClaim(command.UserId, command.ClaimType, command.ClaimValue);
            usuarioClaim.PreencherId(command.Id);
            if (!usuarioClaim.valido())
            {
                return usuarioClaim;
            }
            usuarioClaim.ValidationResult = new UsuarioClaimAptoParaRegistroValidation(_usuarioClaimsRepository).Validate(usuarioClaim);
            return !usuarioClaim.ValidationResult.IsValid
                ? usuarioClaim
                : _usuarioClaimsRepository.Editar(usuarioClaim);
        }

        public void Remover(int id)
        {
            _usuarioClaimsRepository.Remover(id);
        }

        public ListarUsuarioClaimCommandOutput ObterPorId(int id)
        {
            return _usuarioClaimsRepository.ObterPorId(id);
        }

        public IEnumerable<ListarUsuarioClaimCommandOutput> ObterUsuarioClaim(string id)
        {
            return _usuarioClaimsRepository.ObterUsuarioClaim(id);
        }

        public IEnumerable<ListarUsuarioClaimCommandOutput> ObterTodos()
        {
            return _usuarioClaimsRepository.ObterTodos();
        }
    }
}