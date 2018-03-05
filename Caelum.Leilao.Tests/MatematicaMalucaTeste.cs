using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class MatematicaMalucaTeste
    {
        [Test]
        public void DeveRetornar160QuandoPassado40()
        {
            var matematicaMaluca = new MatematicaMaluca();
            var result = matematicaMaluca.ContaMaluca(40);

            Assert.AreEqual(160, result);
        }

        [Test]
        public void DeveRetornar90QuandoPassado30()
        {
            var matematicaMaluca = new MatematicaMaluca();
            var result = matematicaMaluca.ContaMaluca(30);

            Assert.AreEqual(90, result);
        }

        [Test]
        public void DeveRetornar20QuandoPassado10()
        {
            var matematicaMaluca = new MatematicaMaluca();
            var result = matematicaMaluca.ContaMaluca(10);

            Assert.AreEqual(20, result);
        }

        [Test]
        public void DeveRetornar0QuandoPassado0()
        {
            var matematicaMaluca = new MatematicaMaluca();
            var result = matematicaMaluca.ContaMaluca(0);

            Assert.AreEqual(0, result);
        }
    }
}
