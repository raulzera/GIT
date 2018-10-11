using System;
using System.Collections.Generic;
using SAD.Cobranca.Domain.Identity.Commands;
using SAD.Cobranca.Domain.Identity.Interfaces;
using SAD.Cobranca.Domain.Identity.Validations;

namespace SAD.Cobranca.Domain.Identity
{
    public class ClaimsService : IClaimsService
    {
        private readonly IClaimsRepository _claimsRepository;

        public ClaimsService(IClaimsRepository claimsRepository)
        {
            _claimsRepository = claimsRepository;
        }

        public Claims Registrar(RegistrarClaimsCommand command)
        {
            var claim = new Claims(command.Name);
            if (!claim.Valido())
            {
                return claim;
            }
            claim.ValidationResult = new ClaimsAptoParaRegistroValidation(_claimsRepository).Validate(claim);
            return !claim.ValidationResult.IsValid
                ? claim
                : _claimsRepository.Registrar(claim);
        }

        public Claims Editar(EditarClaimsCommand command)
        {
            var claim = new Claims(command.Name);
            claim.PreencherId(command.Id);
            if (!claim.Valido())
            {
                return claim;
            }
            claim.ValidationResult = new ClaimsAptoParaRegistroValidation(_claimsRepository).Validate(claim);
            return !claim.ValidationResult.IsValid
                ? claim
                : _claimsRepository.Editar(claim);
        }

        public void Remover(Guid id)
        {
            _claimsRepository.Remover(id);
        }

        public IEnumerable<Claims> ObterTodos()
        {
            return _claimsRepository.ObterTodos();
        }

        public Claims ObterPorId(Guid id)
        {
            return _claimsRepository.ObterPorId(id);
        }

        public Claims ObterPorNome(string nomeClaim)
        {
            return _claimsRepository.ObterPorNome(nomeClaim);
        }
    }
}
