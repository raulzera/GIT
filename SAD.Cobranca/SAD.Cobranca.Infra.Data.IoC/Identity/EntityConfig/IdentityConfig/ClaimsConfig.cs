using System.Data.Entity.ModelConfiguration;
using SAD.Cobranca.Domain.Identity;

namespace SAD.Cobranca.Infra.Data.IoC.Identity.EntityConfig.IdentityConfig
{
    public class ClaimsConfig : EntityTypeConfiguration<Claims>
    {
        public ClaimsConfig()
        {

            ToTable("AspNetClaims");

            HasKey(x => x.Id);
            Property(u => u.Id).IsRequired();

            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(256);

            Ignore(x => x.ValidationResult);
        }
    }
}
