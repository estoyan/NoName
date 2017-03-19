using Noleggio.Data.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Data.Tests.Repositories.NoleggioDbContextTests
{
    [TestFixture]
    public class Create
    {
        [Test]
        public void ReturnsNewInstance()
        {
            //Arrange & Act
            var newInstance = NoleggioDbContext.Create();
            
            //Assert
            Assert.IsNotNull(newInstance);
        }

        [Test]
        public void ReturnsNewInstanceOfNoleggioDbContext()
        {
            //Arrange & Act
            var newInstance = NoleggioDbContext.Create();

            //Assert
            Assert.IsInstanceOf<INoleggioDbContext>(newInstance);
        }
    }
}
