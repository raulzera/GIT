using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace SAD.Cobranca.Application.Identity.Usuarios
{
    public class UsuarioViewModel
    {
            public UsuarioViewModel()
            {
                Id = Guid.NewGuid().ToString();
                SecurityStamp = Guid.NewGuid().ToString();
                EmailConfirmed = false;
                PhoneNumber = null;
                PhoneNumberConfirmed = false;
                TwoFactorEnabled = false;
                LockoutEndDateUtc = null;
                LockoutEnabled = true;
                AccessFailedCount = 0;

                ValidationResult = new ValidationResult();
            }

            [Key]
            public string Id { get; private set; }

            [DisplayName(@"E-mail")]
            public string Email { get; set; }
            private bool EmailConfirmed { get; set; }
            public string PasswordHash { get; set; }
            public string SecurityStamp { get; set; }
            private string PhoneNumber { get; set; }
            private bool PhoneNumberConfirmed { get; set; }
            private bool TwoFactorEnabled { get; set; }

            [DisplayName(@"Data Vencimento/ Status")]
            public DateTime? LockoutEndDateUtc { get; set; }
            public bool LockoutEnabled { get; set; }
            private int AccessFailedCount { get; set; }

            [DisplayName(@"Username")]
            public string UserName { get; set; }

            [NotMapped]
            [ScaffoldColumn(false)]
            public ValidationResult ValidationResult { get; set; }
        }
}
