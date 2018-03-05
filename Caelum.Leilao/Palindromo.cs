using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Palindromo
    {
        public bool EhPalindromo(String frase)
        {
            String fraseFiltrada = frase
                    .ToUpper().Replace(" ", "").Replace("-", "");

            for (int i = 0; i < fraseFiltrada.Length; i++)
            {
                if (fraseFiltrada[i] != fraseFiltrada[(fraseFiltrada.Length-1) - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
