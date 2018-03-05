using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class MatematicaMaluca
    {
        public int ContaMaluca(int numero)
        {
            if (numero > 30) return numero * 4;
            else if (numero > 10) return numero * 3;
            else return numero * 2;
        }
    }
}
