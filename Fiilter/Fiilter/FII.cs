using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiilter
{
    class FII
    {
        //public List<string> dados { get; set; }
        public string  Codigo { get; set; }
        public string Setor { get; set; }
        public decimal PrecoAtual { get; set; }
        public int Liquidez { get; set; }
        public decimal Dividendo { get; set; }
        public decimal DY { get; set; }
        public decimal DY12Acumulado { get; set; }
        public decimal DY12Media { get; set; }
        public decimal RentabilidadePeriodo { get; set; }
        public decimal PVPA { get; set; }
        public decimal RentabilidadePatr { get; set; }
        public decimal VacanciaFisica { get; set; }
        public decimal VacanciaFinanceira { get; set; }
        public int QtdeAtivos { get; set; }


        public FII(List<string> dadosBrutos)
        {
            Codigo = dadosBrutos[0];
            Setor = dadosBrutos[1];
            PrecoAtual = MoneyParse(dadosBrutos[2]);
            Liquidez = int.Parse(dadosBrutos[3].Replace(".0", ""));
            Dividendo = MoneyParse(dadosBrutos[4]);
            DY = PercentParse(dadosBrutos[5]);
            DY12Acumulado = PercentParse(dadosBrutos[8]);
            DY12Media = PercentParse(dadosBrutos[11]);
            RentabilidadePeriodo = PercentParse(dadosBrutos[14]);
            PVPA = PercentParse(dadosBrutos[18]);
            RentabilidadePatr = PercentParse(dadosBrutos[21]);
            VacanciaFisica = PercentParse(dadosBrutos[23]);
            VacanciaFinanceira = PercentParse(dadosBrutos[24]);
            QtdeAtivos = int.Parse(dadosBrutos[25].Replace(".0", ""));
        }

        private decimal MoneyParse(string valor)
        {
            if (valor == "N/A")
                return -1;
           return decimal.Parse(valor.Replace("R$ ", "").Replace(".", ""));
        }

        private decimal PercentParse(string valor)
        {
            if (valor == "N/A")
                return -999;
            return decimal.Parse(valor.Replace("%", "").Replace(".", ""));
        }
    }
}
