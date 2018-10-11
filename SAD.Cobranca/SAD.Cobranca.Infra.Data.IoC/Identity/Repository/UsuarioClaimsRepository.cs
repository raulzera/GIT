using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dapper;
using SAD.Cobranca.Domain.Identity.UsuarioClaim;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Commands;
using SAD.Cobranca.Domain.Identity.UsuarioClaim.Interfaces;
using SAD.Cobranca.Infra.Data.IoC.Context;

namespace SAD.Cobranca.Infra.Data.IoC.Identity.Repository
{
    public class UsuarioClaimsRepository : AppDbContext<UsuarioClaim>, IUsuarioClaimsRepository
    {
        public UsuarioClaimsRepository(ApplicationDbContext context)
        : base(context)
        {
        }

        public UsuarioClaim Registrar(UsuarioClaim command)
        {
            return Db.UsuarioClaims.Add(command);
        }

        public UsuarioClaim Editar(UsuarioClaim command)
        {
            var entry = Db.Entry(command);
            Db.UsuarioClaims.Attach(command);
            entry.State = EntityState.Modified;

            return command;
        }

        public void Remover(int id)
        {
            Db.UsuarioClaims.Remove(Db.UsuarioClaims.Find(id));
        }

        public IEnumerable<ListarUsuarioClaimCommandOutput> ObterTodos()
        {
            var conexao = Db.Database.Connection;
            const string query = "SELECT " +
                                 "[uc].[Id], [uc].[UserId], [uc].[ClaimType], [uc].[ClaimValue], [u].[UserName] " +
                                 "FROM [AspNetUserClaims] [uc] " +
                                 "LEFT JOIN [AspNetUsers] [u] ON [uc].[UserId] = [u].[Id]";

            return conexao.Query<ListarUsuarioClaimCommandOutput>(query);
        }

        public ListarUsuarioClaimCommandOutput ObterPorId(int id)
        {
            var conexao = Db.Database.Connection;
            const string query = "SELECT " +
                                 "[uc].[Id], [uc].[UserId], [uc].[ClaimType], [uc].[ClaimValue], [u].[UserName] " +
                                 "FROM [AspNetUserClaims] [uc] " +
                                 "LEFT JOIN [AspNetUsers] [u] ON [uc].[UserId] = [u].[Id] " +
                                 "WHERE [uc].[Id]=@pId";

            return conexao.Query<ListarUsuarioClaimCommandOutput>(query, new { pId = id }).FirstOrDefault();
        }

        public UsuarioClaim ObterPorClaimType(string id, string claimType)
        {
            var conexao = Db.Database.Connection;
            const string query = "SELECT [uc].[Id], [uc].[ClaimType] " +
                                 "FROM [AspNetUserClaims] [uc] " +
                                 "WHERE [uc].[UserId] = @pId AND " +
                                 "[uc].[ClaimType] = @pClaimType";

            return conexao.Query<UsuarioClaim>(query, new
            {
                pId = id,
                pClaimType = claimType
            }).FirstOrDefault();
        }

        public IEnumerable<ListarUsuarioClaimCommandOutput> ObterUsuarioClaim(string id)
        {
            var conexao = Db.Database.Connection;
            const string query = "SELECT " +
                                 "[uc].[Id], [uc].[UserId], [uc].[ClaimType], [uc].[ClaimValue], [u].[Username] " +
                                 "FROM [AspNetUserClaims] [uc] " +
                                 "LEFT JOIN [AspNetUsers] [u] ON [uc].[UserId] = [u].[Id] " +
                                 "WHERE [uc].[UserId]=@pId";

            return conexao.Query<ListarUsuarioClaimCommandOutput>(query, new { pId = id });
        }
    }
}