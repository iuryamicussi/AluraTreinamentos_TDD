using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
namespace Caelum.Leilao.Tests
{
    [TestFixture]
    [TestOf(typeof(AnoBissexto))]
    public class AnoBissextoTeste
    {
        [Test]
        [TestCase(2016,ExpectedResult = true)]
        [TestCase(2015, ExpectedResult = false)]
        [TestCase(2500, ExpectedResult = false)]
        [TestCase(2000, ExpectedResult = true)]
        public bool RetornaTrueParaAnoBissexto(int ano) => new AnoBissexto().EhBissexto(ano);

    }
}
