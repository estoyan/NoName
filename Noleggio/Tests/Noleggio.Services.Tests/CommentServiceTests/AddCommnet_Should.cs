using Moq;
using Noleggio.Common.Contracts;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using Noleggio.DtoModels;
using Noleggio.DtoModels.CommentsDto;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Noleggio.Services.Tests.CommentServiceTests
{
    [TestFixture]
    public class AddCommnet_Should
    {
        [Test]
        public void CallMapperServiceOnce()
        {
            //Arrange
            var mockeGenericRepository = new Mock<IGenericEfRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var commentStub = new CommentDtoModel();

            mockedMapper.Setup(x => x.Map<Comment>(It.IsAny<CommentDtoModel>())).Verifiable();
            var sut = new CommentService(mockeGenericRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Act
            sut.AddCommnet(commentStub);

            //Assert
            mockedMapper.Verify(x => x.Map<Comment>(It.IsAny<CommentDtoModel>()), Times.Once);
        }

        [Test]
        public void PassSameCommentWithDateToMapper()
        {
            //Arrange
            var mockeGenericRepository = new Mock<IGenericEfRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var commentStub = new CommentDtoModel();

            mockedMapper.Setup(x => x.Map<Comment>(commentStub)).Verifiable();
            var sut = new CommentService(mockeGenericRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Act
            commentStub.Date = DateTime.Now;
            sut.AddCommnet(commentStub);

            //Assert
            mockedMapper.Verify(x => x.Map<Comment>(It.Is<CommentDtoModel>(y=>y==commentStub)), Times.Once);
        }

        [Test]
        public void CallRepositoryOnce()
        {
           //Arrange
            var mockeGenericRepository = new Mock<IGenericEfRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var commentStub = new CommentDtoModel();
            var commnetDbStub = new Comment();
            mockedMapper.Setup(x => x.Map<Comment>(It.IsAny<CommentDtoModel>())).Returns(commnetDbStub);
            mockeGenericRepository.Setup(x => x.Add(commnetDbStub)).Verifiable();
            var sut = new CommentService(mockeGenericRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Act
            sut.AddCommnet(commentStub);

            //Assert
            mockeGenericRepository.Verify(x => x.Add(commnetDbStub), Times.Once);
        }

        [Test]
        public void CallRepositoryWithSameCommentObject()
        {
            //Arrange
            var mockeGenericRepository = new Mock<IGenericEfRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapingService>();
            var commentStub = new CommentDtoModel();
            var commnetDbStub = new Comment();
            mockedMapper.Setup(x => x.Map<Comment>(It.IsAny<CommentDtoModel>())).Returns(commnetDbStub);
            mockeGenericRepository.Setup(x => x.Add(commnetDbStub)).Verifiable();
            var sut = new CommentService(mockeGenericRepository.Object, mockedUnitOfWork.Object, mockedMapper.Object);

            //Act
            sut.AddCommnet(commentStub);

            //Assert
            mockeGenericRepository.Verify(x => x.Add(It.Is<Comment>(y => y.Equals(commnetDbStub))), Times.Once);
        }
    }
}
