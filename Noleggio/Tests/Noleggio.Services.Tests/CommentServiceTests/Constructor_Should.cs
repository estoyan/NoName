using Moq;
using Noleggio.Common.Contracts;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Services.Tests.CommentServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnNewInstance()
        {
            //Arrange
            var mockeGenericRepository = new Mock<IGenericEfRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();

            //Act
            var sut = new CommentService(mockeGenericRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Assert
            Assert.IsNotNull(sut);
        }

        [Test]
        public void ThrowsIfIMappingServiceIsNull()
        {
            //Arrange
            var mockeGenericRepository = new Mock<IGenericEfRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(()=>new CommentService(mockeGenericRepository.Object, mockedUnitOfWork.Object, null));
        }
    }
}
