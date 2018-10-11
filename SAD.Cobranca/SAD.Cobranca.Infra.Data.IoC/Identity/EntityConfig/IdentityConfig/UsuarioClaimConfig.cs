using System.Data.Entity.ModelConfiguration;
using SAD.Cobranca.Domain.Identity.UsuarioClaim;

namespace SAD.Cobranca.Infra.Data.IoC.Identity.EntityConfig.IdentityConfig
{
    public class UsuarioClaimConfig : EntityTypeConfiguration<UsuarioClaim>
    {
        public UsuarioClaimConfig()
        {
            ToTable("AspNetUserClaims");

            HasKey(u => u.Id);
            Property(u => u.UserId)
                .IsRequired()
                .HasMaxLength(128);

            Ignore(x => x.ValidationResult);
            HasRequired(uc => uc.Usuario).WithMany(u => u.UsuarioClaim).HasForeignKey(u => u.UserId);
        }
    }
}
