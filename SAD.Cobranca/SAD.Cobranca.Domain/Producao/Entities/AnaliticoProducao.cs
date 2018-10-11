namespace SAD.Cobranca.Domain.Producao.Entities
{
    public class AnaliticoProducao
    {
        public string IdRegiao { get; set; }
        public string Regiao { get; set; }
        public string Operador { get; set; }
        public string HoraInicial { get; set; }
        public string HoraFinal { get; set; }
        public string TipoEvento { get; set; }
        public string Situacao { get; set; }
        public string TpDiscador { get; set; }
        public int IdGrupo { get; set; }
        public string Grupo { get; set; }
        public int IdResultado { get; set; }
        public string Resultado { get; set; }
        public int ContTabulacao { get; set; }
        public int ContDiscagem { get; set; }
        public int ContAlo { get; set; }
        public int ContCpc { get; set; }
        public int ContCpcProd { get; set; }
        public int ContCpcImprod { get; set; }
        public int Seq { get; set; }
        public int Tentativa { get; set; }
        public int TabPos { get; set; }
        public int TabProm { get; set; }
        public int Propo { get; set; }
        public int Reneg { get; set; }
        public int Ea { get; set; }
        public decimal TabAlo { get; set; }
        public decimal PercAlo { get; set; }
        public decimal PercCpc { get; set; }
        public decimal PerCpcXAlo { get; set; }
        public decimal PercCpcNovo { get; set; }
        public decimal PercCpcRecente { get; set; }
        public decimal PercProm { get; set; }
    } 
}