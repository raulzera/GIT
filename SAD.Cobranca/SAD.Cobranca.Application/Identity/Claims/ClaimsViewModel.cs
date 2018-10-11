using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace SAD.Cobranca.Application.Identity.Claims
{
    public class ClaimsViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = @"Fornceça um nome para a Claim")]
        [MaxLength(128, ErrorMessage = @"Tamanho máximo {0} excedido")]
        [Display(Name = @"Claim")]
        public string Name { get; set; }

        [NotMapped]
        [ScaffoldColumn(false)]
        public ValidationResult ValidationResult { get; set; }
    }
}
