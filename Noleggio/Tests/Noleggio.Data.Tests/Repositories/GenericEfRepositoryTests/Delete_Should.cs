using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Data.Tests.Repositories.GenericEfRepositoryTests
{
    [TestFixture]
    public class Delete_Should
    {


        [Test]
        public void CallOnce_DbSet_Add_WithSameArguments()
        {

            //Arrange
            var entity = new Mock<IDeletableEntity>();
            var mockDbSet = new Mock<IDbSet<IDeletableEntity>>();

            mockDbSet.Setup(x => x.Add(entity.Object)).Verifiable();
            var context = new Mock<INoleggioDbContext>();
            context.Setup(x => x.Set<IDeletableEntity>()).Returns(mockDbSet.Object);
            var sut = new GenericEfRepository<IDeletableEntity>(context.Object);

            //Act
            sut.Add(entity.Object);

            //Assert
            mockDbSet.Verify(x => x.Add(entity.Object), Times.Once);
        }

        [Test]
        public void ThrowWhenEntityisNull()
        {
            //Arrange
            var mockDbSet = new Mock<IDbSet<IDeletableEntity>>();
            var mockedContext = new Mock<INoleggioDbContext>();
            mockedContext.Setup(x => x.Set<IDeletableEntity>()).Returns(mockDbSet.Object);
            var sut = new GenericEfRepository<IDeletableEntity>(mockedContext.Object);


            //Act&Assert
            Assert.Throws<ArgumentNullException>(() => sut.Add(null));
        }


    }
}

}
