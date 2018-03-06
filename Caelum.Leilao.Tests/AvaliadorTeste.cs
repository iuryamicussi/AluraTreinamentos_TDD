using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class AvaliadorTeste
    {
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario maria;
        private Usuario jose;

        [SetUp]
        public void SetUp()
        {
            joao = new Usuario("Joao");
            jose = new Usuario("José");
            maria = new Usuario("Maria");

            leiloeiro = new Avaliador();
            Console.WriteLine("inicializando teste!");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Finalizando teste!");
        }

        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
            .Lance(joao, 100.0)
            .Lance(maria, 200.0)
            .Lance(joao, 300.0)
            .Lance(maria, 400.0)
            .Constroi();

            // executando a acao 
            leiloeiro.Avalia(leilao);
            // comparando a saida com o esperado 
            double maiorEsperado = 400;
            double menorEsperado = 100;
            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void DeveAcertarOValorMedioDosLances()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
            .Lance(maria, 250.0)
            .Lance(joao, 300.0)
            .Lance(maria, 400.0)
            .Constroi();

            // executando a acao 
            leiloeiro.Avalia(leilao);

            double valorMedioEsperado = 316.666666666;
            Assert.AreEqual(valorMedioEsperado, leiloeiro.ValorMedioLance, 0.0001);
        }

        [Test]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation 3 Novo")
            .Lance(joao, 250.0)
            .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(250, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(250, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 400.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            IList<Lance> maiores = leiloeiro.TresMaioresLances;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.00001);
            Assert.AreEqual(300, maiores[1].Valor, 0.00001);
            Assert.AreEqual(200, maiores[2].Valor, 0.00001);
        }

        [Test]
        public void DeveEncontrarOsDoisMaioresLances()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            IList<Lance> maiores = leiloeiro.TresMaioresLances;

            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(200, maiores[0].Valor, 0.00001);
            Assert.AreEqual(100, maiores[1].Valor, 0.00001);
        }

        [Test]
        [Ignore("Agora o método avalia lança uma exceção caso o leilão não possua lances")]
        public void DeveDevolverUmaListaVazia()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            IList<Lance> maiores = leiloeiro.TresMaioresLances;

            Assert.AreEqual(0, maiores.Count);
        }

        [Test]
        public void DeveEntenderLancesEmOrdemAleatoria()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 1000));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 550));
            leilao.Propoe(new Lance(maria, 50));
            leilao.Propoe(new Lance(joao, 9999.59));
            leilao.Propoe(new Lance(maria, 50));


            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(50, leiloeiro.MenorLance, 0.00001);
            Assert.AreEqual(9999.59, leiloeiro.MaiorLance, 0.00001);
        }

        [Test]
        public void DeveEntenderLancesEmOrdemDecrescente()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 400.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 100.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(400, leiloeiro.MaiorLance, 0.00001);
            Assert.AreEqual(100, leiloeiro.MenorLance, 0.00001);
        }

        [Test]
        public void DeveLancarUmaExcessaoCasoLeilaoNaoPossuaLances()
        {
            var leilao = new CriadorDeLeilao()
                .Para("Nintendo Swift")
                .Constroi();

            Assert.Throws<Exception>(() => leiloeiro.Avalia(leilao));
        }


    }
}
