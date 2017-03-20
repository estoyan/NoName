using Noleggio.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Common.Tests.AgeCalculatorTests
{
    [TestFixture]
    public class AgeShould
    {
        [Test]
        public void REturnsNullIfDateIsValid()
        {
            //Arrange & Act & Assert

            Assert.AreEqual(null, AgeCalculator.Age(null));
        }
    }

    //TODO mock DateTIme
}
