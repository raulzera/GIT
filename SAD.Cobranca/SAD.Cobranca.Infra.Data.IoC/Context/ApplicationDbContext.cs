using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SAD.Cobranca.Domain.Identity;
using SAD.Cobranca.Domain.Identity.UsuarioClaim;
using SAD.Cobranca.Infra.Data.IoC.Identity.EntityConfig.IdentityConfig;

namespace SAD.Cobranca.Infra.Data.IoC.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("ConnectionStringSAD")
        {
        }

        public IDbSet<Claims> Claims { get; set; }
        public IDbSet<UsuarioClaim> UsuarioClaims { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ClaimsConfig());
            modelBuilder.Configurations.Add(new UsuarioClaimConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
