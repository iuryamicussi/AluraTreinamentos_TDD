using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        public double MaiorLance { get; private set; }
        public double MenorLance { get; private set; }
        public double ValorMedioLance { get; private set; }
        public List<Lance> TresMaioresLances { get; private set; } = new List<Lance>();

        public void Avalia(Leilao leilao)
        {
            if (leilao.Lances.Count <= 0)
                throw new Exception("Não é possível avaliar um leilão sem lances");

            MenorLance = leilao.Lances.Min(m => m.Valor);
            MaiorLance = leilao.Lances.Max(m => m.Valor);
            ValorMedioLance = leilao.Lances.Average(a => a.Valor);
            TresMaioresLances = leilao.Lances.OrderByDescending(o => o.Valor).Take(3).ToList();
        }
    }
}
