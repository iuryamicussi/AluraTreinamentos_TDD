using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class LeilaoTeste
    {

        [Test]
        public void DeveReceberUmLance()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            Assert.AreEqual(0, leilao.Lances.Count);

            leilao.Propoe(new Lance(new Usuario("Steve Jobs"), 2000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
        }

        [Test]
        public void DeveReceberVariosLances()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            leilao.Propoe(new Lance(new Usuario("Steve Jobs"), 2000));
            leilao.Propoe(new Lance(new Usuario("Steve Wozniak"), 3000));

            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
            Assert.AreEqual(3000, leilao.Lances[1].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveAceitarDoisLancesSeguidosDoMesmoUsuario()
        {
            var leilao = new Leilao("Impressora HP Deskjet 2540");
            var usuario = new Usuario("João");
            leilao.Propoe(new Lance(usuario, 1000));
            leilao.Propoe(new Lance(usuario, 2000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(1000, leilao.Lances[0].Valor, 0.0001);
        }

        [Test]
        public void NaoDeveAceitarMaisQueCincoLancesDoMesmoUsuario()
        {
            var leilao = new Leilao("Impressora HP Deskjet 2540");
            var joao = new Usuario("João");
            var maria = new Usuario("Maria");

            leilao.Propoe(new Lance(joao, 1000));
            leilao.Propoe(new Lance(maria, 2000));

            leilao.Propoe(new Lance(joao, 3000));
            leilao.Propoe(new Lance(maria, 4000));

            leilao.Propoe(new Lance(joao, 5000));
            leilao.Propoe(new Lance(maria, 6000));

            leilao.Propoe(new Lance(joao, 7000));
            leilao.Propoe(new Lance(maria, 8000));

            leilao.Propoe(new Lance(joao, 9000));
            leilao.Propoe(new Lance(maria, 10000));

            leilao.Propoe(new Lance(joao, 11000));

            Assert.AreEqual(10, leilao.Lances.Count);
            Assert.AreEqual(10000, leilao.Lances[9].Valor, 0.0001);
        }

        [Test]
        [Category("Dobrar")]
        public void DeveRealizarUmNovoLanceDobrandoOValorDoUltimoLanceDado()
        {
            var leilao = new Leilao("Impressora HP Deskjet 2540");
            var joao = new Usuario("João");
            var maria = new Usuario("Maria");

            leilao.Propoe(new Lance(joao, 20000));
            leilao.Propoe(new Lance(maria, 30000));
            leilao.DobrarLance(joao);

            Assert.AreEqual(3, leilao.Lances.Count);
            Assert.AreEqual(20000 * 2, leilao.Lances[2].Valor, 0.0001);
        }

        [Test]
        [Category("Dobrar")]
        public void NaoDeveAceitarDoisLancesSeguidosDoMesmoUsuarioComODobrar()
        {
            var leilao = new Leilao("Impressora HP Deskjet 2540");
            var usuario = new Usuario("João");
            leilao.Propoe(new Lance(usuario, 1000));
            leilao.DobrarLance(usuario);

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(1000, leilao.Lances[0].Valor, 0.0001);
        }

        [Test]
        [Category("Dobrar")]
        public void NaoDeveAceitarMaisQueCincoLancesDoMesmoUsuarioComODobrar()
        {
            var leilao = new Leilao("Impressora HP Deskjet 2540");
            var joao = new Usuario("João");
            var maria = new Usuario("Maria");

            leilao.Propoe(new Lance(joao, 1000));
            leilao.Propoe(new Lance(maria, 2000));

            leilao.Propoe(new Lance(joao, 3000));
            leilao.Propoe(new Lance(maria, 4000));

            leilao.Propoe(new Lance(joao, 5000));
            leilao.Propoe(new Lance(maria, 6000));

            leilao.Propoe(new Lance(joao, 7000));
            leilao.Propoe(new Lance(maria, 8000));

            leilao.Propoe(new Lance(joao, 9000));
            leilao.Propoe(new Lance(maria, 10000));

            leilao.DobrarLance(joao);

            Assert.AreEqual(10, leilao.Lances.Count);
            Assert.AreEqual(10000, leilao.Lances[9].Valor, 0.0001);
        }

        [Test]
        [Category("Dobrar")]
        public void NaoDeveAcrescentarUmLanceCasoOUsuarioDobreMasNaoTenhaDadoUmLanceAnteriormente()
        {
            var leilao = new Leilao("Impressora HP Deskjet 2540");
            var joao = new Usuario("João");
            var maria = new Usuario("Maria");
            leilao.Propoe(new Lance(maria, 1000));
            leilao.DobrarLance(joao);

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(1000, leilao.Lances[0].Valor, 0.0001);
        }


    }
}
