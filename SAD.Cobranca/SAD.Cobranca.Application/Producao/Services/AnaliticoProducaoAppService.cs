using System;
using System.Collections.Generic;
using AutoMapper;
using SAD.Cobranca.Application.Producao.Interfaces;
using SAD.Cobranca.Application.Producao.ViewModel;

namespace SAD.Cobranca.Application.Producao.Services
{
    public class AnaliticoProducaoAppService : IAnaliticoProducaoAppService
    {
        private readonly IAnaliticoProducaoAppService _analiticoProducaoAppService;

        public AnaliticoProducaoAppService(IAnaliticoProducaoAppService analiticoProducaoAppService)
        {
            _analiticoProducaoAppService = analiticoProducaoAppService;
        }

        public IEnumerable<AnaliticoViewModel> ObterAnaliticoProducaoPorDataAtendimento(DateTime dataStart,DateTime dataEnd, string operador)
        {
            return Mapper.Map<IEnumerable<AnaliticoViewModel>>(
                _analiticoProducaoAppService.ObterAnaliticoProducaoPorDataAtendimento(dataStart, dataEnd, operador));
        }

        public IEnumerable<AnaliticoViewModel> ObterAnaliticoProducaoPorDataFonada(DateTime dataStart, DateTime dataEnd,string operador)
        {
            return Mapper.Map<IEnumerable<AnaliticoViewModel>>(_analiticoProducaoAppService.ObterAnaliticoProducaoPorDataFonada(dataStart, dataEnd, operador));
        }
    }
}
