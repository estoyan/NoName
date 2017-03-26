using Moq;
using Noleggio.Common.Contracts;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using Noleggio.DtoModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class GetByUserName_Should
    {

        [Test]
        public void CallRepositoryGetAllOnce()
        {
            //Arrange
            var mockedRepository = new Mock<IGenericEfRepository<User>>();
            mockedRepository.Setup(x => x.GetAll()).Returns(new List<User>().AsQueryable()).Verifiable();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var sut = new UserService(mockedRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Act
            sut.GetByUserName("test");

            //Assert
            mockedRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void CallsMapperOnce()
        {
            //Arrange
            var mockedRepository = new Mock<IGenericEfRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            mockedRepository.Setup(x => x.GetAll()).Returns(new List<User>().AsQueryable());
            var mockedMapper = new Mock<IMapingService>();
            mockedMapper.Setup(x => x.Map<List<UserDtoModel>>( new List<User>())).Verifiable();

            var sut = new UserService(mockedRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Act
            sut.GetByUserName("test");


            //Assert
            mockedMapper.Verify(x => x.Map<List<UserDtoModel>>(new List<User>()), Times.Once);
        }

        [Test]
        public void ThrowsWhenUserNameIsNull()
        {
            //Arrange
            var mockedRepository = new Mock<IGenericEfRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();

            var sut = new UserService(mockedRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Act&Assert
            Assert.Throws<ArgumentException>(() => sut.GetByUserName(""));
        }
    }
}
