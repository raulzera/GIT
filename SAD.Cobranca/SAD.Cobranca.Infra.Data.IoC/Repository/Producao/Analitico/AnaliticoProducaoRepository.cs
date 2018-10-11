using System;
using System.Collections.Generic;
using Dapper;
using SAD.Cobranca.Domain.Producao.Entities;
using SAD.Cobranca.Domain.Producao.Interfaces;
using SAD.Cobranca.Infra.Data.IoC.Context;

namespace SAD.Cobranca.Infra.Data.IoC.Repository.Producao.Analitico
{
    public class AnaliticoProducaoRepository : AppDbContext<AnaliticoProducaoRepository>, IAnaliticoProducaoRepository
    {
        public AnaliticoProducaoRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public IEnumerable<AnaliticoProducao> ObterAnaliticoProducaoPorDataAtendimento(DateTime dataStart, DateTime dataEnd, string operador)
        {
            var conexao = Db.Database.Connection;
            var ds = dataStart.ToString("yyyy MMMM dd");
            var de = dataEnd.ToString("yyyy MMMM dd");
            var Op = operador;

            const string sql = @"Select A.id_regiao_cbr IdRegiao " +
                               ", Upper(A.regiao_cobr) Regiao " +
                               ", Operador = C.Operador " +
                               ", A.hora_inicial HoraInicial " +
                               ", A.hora_final HoraFinal " +
                               ", A.Tipo_evento TipoEvento " +
                               ", A.situacao_do_acionamento Situacao " +
                               ", A.tp_discador TpDiscador" +
                               ", B.Id_Resultado IdResultado " +
                               ", B.dsc_Resultado Resultado " +
                               ", B.Cont_Tabulacao ContTabulacao " +
                               ", B.Cont_Discagem ContDiscagem" +
                               ", B.Cont_Tent ContTent" +
                               ", B.Cont_Alo ContAlo" +
                               ", B.Cont_Cpc ContCpc" +
                               ", B.Cont_CpcProd ContCpcProd" +
                               ", B.Cont_cpcImprod ContCpcImprod " +
                               ", B.Situacao " +
                               ", B.Seq Seq" +
                               ", C.Id_Grupo_Totalip IdGrupo " +
                               ", C.Grupo_Totalip Grupo " +
                               "From tesis.dbo.todos_os_acionamentos A with(nolock) " +
                               "Inner Join SadCob.dbo.Analise_Cpc B with(nolock) on A.Cod_resultado = B.Id_resultado " +
                               "Inner Join SadCob.dbo.Users C with(nolock) on A.Operador = C.Operador " +
                               "Where C.operador in ('@Operador')" +
                               "And Convert(date, dt_ult_atend,101) between '@DataStart' and '@DataEnd' " +
                               "And Tipo_evento = 'Atendimento' Order By dt_ult_atend, hora_inicial ";

            var retorno = conexao.Query<AnaliticoProducao>(sql, new
            {
                dInicio = ds,
                dFinal = de,
                operador = Op


            });
            return retorno;
        }

        public IEnumerable<AnaliticoProducao> ObterAnaliticoProducaoPorDataFonada(DateTime dataStart, DateTime dataEnd, string operador)
        {
            var conexao = Db.Database.Connection;
            var ds = dataStart.ToString("yyyy MMMM dd");
            var de = dataEnd.ToString("yyyy MMMM dd");
            var Op = operador;

            const string sql = @"Select A.id_regiao_cbr IdRegiao " +
                               ", Upper(A.regiao_cobr) Regiao " +
                               ", Operador = C.Operador " +
                               ", A.hora_inicial HoraInicial " +
                               ", A.hora_final HoraFinal " +
                               ", A.Tipo_evento TipoEvento " +
                               ", A.situacao_do_acionamento Situacao " +
                               ", A.tp_discador TpDiscador" +
                               ", B.Id_Resultado IdResultado " +
                               ", B.dsc_Resultado Resultado " +
                               ", B.Cont_Tabulacao ContTabulacao " +
                               ", B.Cont_Discagem ContDiscagem" +
                               ", B.Cont_Tent ContTent" +
                               ", B.Cont_Alo ContAlo" +
                               ", B.Cont_Cpc ContCpc" +
                               ", B.Cont_CpcProd ContCpcProd" +
                               ", B.Cont_cpcImprod ContCpcImprod " +
                               ", B.Situacao " +
                               ", B.Seq Seq" +
                               ", C.Id_Grupo_Totalip IdGrupo " +
                               ", C.Grupo_Totalip Grupo " +
                               "From tesis.dbo.todos_os_acionamentos A with(nolock) " +
                               "Inner Join SadCob.dbo.Analise_Cpc B with(nolock) on A.Cod_resultado = B.Id_resultado " +
                               "Inner Join SadCob.dbo.Users C with(nolock) on A.Operador = C.Operador " +
                               "Where C.operador in (@Operador) " +
                               "And Convert(date, dt_ult_fonada,101) between '@DataStart' and '@DataEnd' " +
                               "And Tipo_evento = 'Atendimento' Order By dt_ult_atend, hora_inicial ";

            var retorno = conexao.Query<AnaliticoProducao>(sql, new
            {
                dInicio = ds,
                dFinal = de,
                operador = Op

            });
            return retorno;
        }
    }
}