﻿using System;
using System.Collections.Generic;
using SAD.Cobranca.Domain.Producao.Entities;

namespace SAD.Cobranca.Domain.Producao.Services
{
    public interface IAnaliticoProducaoService
    {
        IEnumerable<AnaliticoProducao> ObterAnaliticoProducaoPorDataAtendimento(DateTime dataStart, DateTime dataEnd, string operador);
        IEnumerable<AnaliticoProducao> ObterAnaliticoProducaoPorDataFonada(DateTime dataStart, DateTime dataEnd, string operador);
    }
}
