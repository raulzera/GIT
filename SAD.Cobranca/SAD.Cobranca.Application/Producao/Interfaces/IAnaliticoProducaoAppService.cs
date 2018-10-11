using System;
using System.Collections.Generic;
using SAD.Cobranca.Application.Producao.ViewModel;

namespace SAD.Cobranca.Application.Producao.Interfaces
{
    public interface IAnaliticoProducaoAppService
    {
        IEnumerable<AnaliticoViewModel> ObterAnaliticoProducaoPorDataAtendimento(DateTime dataStart, DateTime dataEnd, string operador);
        IEnumerable<AnaliticoViewModel> ObterAnaliticoProducaoPorDataFonada(DateTime dataStart, DateTime dataEnd, string operador);
    }
}