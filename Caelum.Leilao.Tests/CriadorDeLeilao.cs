using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Tests
{
    public class CriadorDeLeilao
    {
        private Leilao leilao;

        public CriadorDeLeilao() { }

        public CriadorDeLeilao Para(String descricao)
        {
            this.leilao = new Leilao(descricao);
            return this;
        }

        public CriadorDeLeilao Lance(Usuario usuario, double valor)
        {
            leilao.Propoe(new Lance(usuario, valor));
            return this;
        }

        public Leilao Constroi()
        {
            return leilao;
        }
    }
}
