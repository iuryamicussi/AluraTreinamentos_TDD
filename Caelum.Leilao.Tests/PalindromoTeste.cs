using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class PalindromoTeste
    {
        [Test]
        public void RetornaTrueParaUmPalindromo()
        {
            var palindromoClass = new Palindromo();

            var result = palindromoClass.EhPalindromo("ROMA ME TEM AMOR");

            Assert.IsTrue(result);
        }

        [Test]
        public void RetornaFalseParaUmNaoPalindromo()
        {
            var palindromoClass = new Palindromo();

            var result = palindromoClass.EhPalindromo("ROMA METRO TEM AMOR");

            Assert.IsFalse(result);
        }
    }
}
