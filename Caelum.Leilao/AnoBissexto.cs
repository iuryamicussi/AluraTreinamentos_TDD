using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class AnoBissexto
    {
        public bool EhBissexto(int ano)
        {
            if (ano % 400 == 0)
                return true;
            if (ano % 100 == 0)
                return false;

            return ano % 4 == 0;
        }
    }
}
