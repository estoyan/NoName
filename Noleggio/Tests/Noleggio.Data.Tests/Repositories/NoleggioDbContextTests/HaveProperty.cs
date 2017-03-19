using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Data.Tests.Repositories.NoleggioDbContextTests
{
    [TestFixture]
   public class HaveProperty
    {
        [Test]
        public void RentItems()
        {
            //Arrange& Act
            var noleggioDbcontext = new NoleggioDbContext();

            //Assert
            Assert.IsNotNull(noleggioDbcontext.RentItems);
        }

        [Test]
        public void Comments()
        {
            //Arrange& Act
            var noleggioDbcontext = new NoleggioDbContext();

            //Assert
            Assert.IsNotNull(noleggioDbcontext.Comments);
        }

        [Test]
        public void Leases()
        {
            //Arrange& Act
            var noleggioDbcontext = new NoleggioDbContext();
            
            //Assert
            Assert.IsNotNull(noleggioDbcontext.Leases);
        }

        [Test]
        public void Categories()
        {
            //Arrange& Act
            var noleggioDbcontext = new NoleggioDbContext();
        
            //Assert
            Assert.IsNotNull(noleggioDbcontext.Categories);
        }

        [Test]
        public void Ratings()
        {
            //Arrange& Act
            var noleggioDbcontext = new NoleggioDbContext();
            
            //Assert
            Assert.IsNotNull(noleggioDbcontext.Ratings);
        }
    }
}
