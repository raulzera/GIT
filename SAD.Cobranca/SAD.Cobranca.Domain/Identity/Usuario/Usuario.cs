using System;
using System.Collections.Generic;

namespace SAD.Cobranca.Domain.Identity.Usuario
{
    public class Usuario
    {
        public Usuario()
        {
            Id = Guid.NewGuid().ToString();
            UsuarioClaim = new List<UsuarioClaim.UsuarioClaim>();
        }
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public Guid ClienteId { get; set; }
        public ICollection<UsuarioClaim.UsuarioClaim> UsuarioClaim { get; set; }
    }
}
