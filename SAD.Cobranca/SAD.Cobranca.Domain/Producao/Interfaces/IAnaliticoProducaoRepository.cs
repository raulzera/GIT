using System;
using System.Collections.Generic;
using SAD.Cobranca.Domain.Producao.Entities;

namespace SAD.Cobranca.Domain.Producao.Interfaces
{
   public interface IAnaliticoProducaoRepository
   {
       IEnumerable<AnaliticoProducao> ObterAnaliticoProducaoPorDataAtendimento(DateTime dataStart, DateTime dataEnd, string operador);
       IEnumerable<AnaliticoProducao> ObterAnaliticoProducaoPorDataFonada(DateTime dataStart, DateTime dataEnd, string operador);
   }
}
