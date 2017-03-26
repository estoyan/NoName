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

namespace Noleggio.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnNewInstance()
        {
            //Arrange
            var mockedRepository = new Mock<IGenericEfRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();

            //Act&Assert
            Assert.IsNotNull(new UserService(mockedRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object));

        }
        [Test]
        public void ThrowWhenMapperIsNull()
        {
            //Arrange
            var mockedRepository = new Mock<IGenericEfRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            //Act&Assert
            Assert.Throws<ArgumentNullException>(()=>new UserService(mockedRepository.Object, mockedUnitOfWork.Object,null));

        }
    }
}
