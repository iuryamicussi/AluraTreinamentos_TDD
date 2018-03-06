using System;
using System.Collections.Generic;
using System.Linq;
namespace Caelum.Leilao
{

    public class Leilao
    {

        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            if (lance.Valor <= 0)
                throw new ArgumentException("O valor do lance deve ser maior que 0");
            if (Lances.Count == 0 || podeDarLance(lance.Usuario))
            {
                Lances.Add(lance);
            }
        }

        private bool podeDarLance(Usuario usuario)
        {
            return !ultimoLanceDado().Usuario.Equals(usuario)
                    && qtdDelancesDo(usuario) < 5;
        }

        private Lance ultimoLanceDado()
        {
            return Lances[Lances.Count - 1];
        }

        private int qtdDelancesDo(Usuario usuario)
        {
            int total = 0;
            foreach (Lance lance in Lances)
            {
                if (lance.Usuario.Equals(usuario)) total++;
            }
            return total;
        }

        public void DobrarLance(Usuario usuario)
        {
            if(Lances.Count > 0 && podeDarLance(usuario))
            {
                var ultimoLanceDoUsuario = buscarUltimoLanceDoUsuario(usuario);
                if (ultimoLanceDoUsuario == null) return;

                Lances.Add(new Lance(usuario, ((Lance)ultimoLanceDoUsuario).Valor * 2));
            }
        }

        private Lance buscarUltimoLanceDoUsuario(Usuario usuario)
        {
            Lance lance = null;
            for (int i = Lances.Count - 1; i >= 0; i--)
            {
                if (Lances[i].Usuario.Equals(usuario))
                {
                    lance = Lances[i];
                }
            }
            return lance;
        }
    }
}