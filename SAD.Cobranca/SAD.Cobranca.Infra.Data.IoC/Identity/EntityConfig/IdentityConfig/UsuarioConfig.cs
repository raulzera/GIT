using System.Data.Entity.ModelConfiguration;
using SAD.Cobranca.Domain.Identity.Usuario;

namespace SAD.Cobranca.Infra.Data.IoC.Identity.EntityConfig.IdentityConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            ToTable("AspNetUsers");

            HasKey(u => u.Id);
            Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(128);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
