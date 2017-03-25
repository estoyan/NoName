using Moq;
using Noleggio.Common.Contracts;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using Noleggio.DtoModels.CommentsDto;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Noleggio.Services.Tests.CommentServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void CallRepostioryGetAllOnce()
        {
            //Arrange
            var mockedRepository = new Mock<IGenericEfRepository<Comment>>();
            mockedRepository.Setup(x => x.GetAll()).Verifiable();
            var mockedResult = new List<Comment>();
            mockedResult.Add(new Comment());
            mockedRepository.Setup(x => x.GetAll()).Returns(mockedResult.AsQueryable());
            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var service = new CommentService(mockedRepository.Object, mockedUnitOfwork.Object, mockedMapper.Object);

            //Act
            var result = service.GetAll();
            //Assert
            mockedRepository.Verify(x => x.GetAll(), Times.Once);
        }


        [Test]
        public void CallsMapperServiceOnce()
        {
            //Arrange
            var mockedRepository = new Mock<IGenericEfRepository<Comment>>();
            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var mockedResult = new List<Comment>();
            var categoryStub = new Comment();
            mockedResult.Add(categoryStub);
            mockedRepository.Setup(x => x.GetAll()).Returns(mockedResult.AsQueryable());

            mockedMapper.Setup(x => x.Map<List<CommentDtoModel>>(mockedResult)).Verifiable();
            var service = new CommentService(mockedRepository.Object, mockedUnitOfwork.Object, mockedMapper.Object);

            //Act
            var result = service.GetAll(new Guid());
            //Assert
            mockedMapper.Verify(x => x.Map<List<CommentDtoModel>>(mockedResult), Times.Once);
        }
    }
}
