using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dapper;
using SAD.Cobranca.Domain.Identity.Interfaces;
using SAD.Cobranca.Infra.Data.IoC.Context;

namespace SAD.Cobranca.Infra.Data.IoC.Identity.Repository
{
    public class ClaimsRepository : AppDbContext<IClaimsRepository>, IClaimsRepository
    {
        public ClaimsRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public Domain.Identity.Claims Registrar(Domain.Identity.Claims claim)
        {
            return Db.Claims.Add(claim);
        }

        public Domain.Identity.Claims Editar(Domain.Identity.Claims claim)
        {
            var entry = Db.Entry(claim);
            Db.Claims.Attach(claim);
            entry.State = EntityState.Modified;

            return claim;
        }

        public void Remover(Guid id)
        {
            Db.Claims.Remove(Db.Claims.Find(id));
        }

        public IEnumerable<Domain.Identity.Claims> ObterTodos()
        {
            var conexao = Db.Database.Connection;
            const string query = "SELECT [c].[Id], [c].[Name] FROM [AspNetClaims] [c]";
            return conexao.Query<Domain.Identity.Claims>(query);
        }

        public Domain.Identity.Claims ObterPorId(Guid id)
        {
            var conexao = Db.Database.Connection;
            const string query = "SELECT " +
                                 "[c].[Id], [c].[Name] " +
                                 "FROM [AspNetClaims] [c] WHERE [Id]=@pId";

            return conexao.Query<Domain.Identity.Claims>(query, new
            {
                pId = id
            }).FirstOrDefault();
        }

        public Domain.Identity.Claims ObterPorNome(string nomeClaim)
        {
            var conexao = Db.Database.Connection;
            const string query = "SELECT [c].[Id], [c].[Name] " +
                                 "FROM [AspNetClaims] [c]" +
                                 "WHERE [c].[Name] = @pName";

            return conexao.Query<Domain.Identity.Claims>(query, new
            {
                pName = nomeClaim
            }).FirstOrDefault();
        }
    }
}