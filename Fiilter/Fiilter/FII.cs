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
        public string  Codigo { get; }
        public string Setor { get; }
        public decimal PrecoAtual { get;  }
        public int Liquidez { get; }
        public decimal Dividendo { get;  }
        public decimal DY { get;  }
        public decimal DY12Acumulado { get;  }
        public decimal DY12Media { get; }
        public decimal RentabilidadePeriodo { get; }
        public decimal PVPA { get;  }
        public decimal RentabilidadePatr { get;  }
        public decimal VacanciaFisica { get; }
        public decimal VacanciaFinanceira { get; }
        public int QtdeAtivos { get; }


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
