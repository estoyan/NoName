using Moq;
using Noleggio.Data.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Data.Tests.Repositories.UnitOfWorkTests
{
    [TestFixture]
    public class CommitShould
    {
        [Test]
        public void SetsSameDbContext()
        {
            //Arrange
            var mockedContext = new Mock<INoleggioDbContext>();
            mockedContext.Setup(x => x.SaveChanges()).Verifiable();
            var actulaUnitOfWork = new FakeUnitOfWork(mockedContext.Object);

            //Act
            actulaUnitOfWork.Commit();

            //Assert
            mockedContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
