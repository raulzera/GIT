using System;
using CC.SAD.Cobranca.Domain.Core.Entities;
using FluentValidation.Results;
using SAD.Cobranca.Domain.Identity.Validations;

namespace SAD.Cobranca.Domain.Identity
{
    public class Claims : Entity
    {
        protected Claims()
        {
        }

        public Claims(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public bool Valido()
        {
            ValidationResult = new ClaimsConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public void PreencherId(Guid id) => Id = id;
    }
}
