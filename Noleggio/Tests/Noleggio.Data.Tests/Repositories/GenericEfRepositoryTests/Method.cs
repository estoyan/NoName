using Moq;
using Noleggio.Data.Contracts;
using Noleggio.Data.Repositories;
using Noleggio.DbModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Data.Tests.Repositories.GenericEfRepositoryTests
{
    [TestFixture]
    public class Method
    {
        [Test]
        public void GetByIdCallsDbStOnces()
        {
            //Arrange
            var mockDbSet = new Mock<IDbSet<IDeletableEntity>>();
            var entity = new Mock<IDeletableEntity>();
            mockDbSet.Setup(x => x.Add(entity.Object)).Verifiable();
            var context = new Mock<INoleggioDbContext>();
            context.Setup(x => x.Set<IDeletableEntity>()).Returns(mockDbSet.Object);
            var repository = new GenericEfRepository<IDeletableEntity>(context.Object);

            //Act
            repository.GetById(1);

            //Assert
            mockDbSet.Verify(x => x.Find(1), Times.Once);
        }

        [Test]
        public void GetByIdCallsDbStOncesWithSameArguments()
        {
            //Arrange
            var mockDbSet = new Mock<IDbSet<IDeletableEntity>>();
            var entity = new Mock<IDeletableEntity>();
            mockDbSet.Setup(x => x.Add(entity.Object)).Verifiable();
            var context = new Mock<INoleggioDbContext>();
            context.Setup(x => x.Set<IDeletableEntity>()).Returns(mockDbSet.Object);
            var repository = new GenericEfRepository<IDeletableEntity>(context.Object);

            //Act
            repository.GetById(1);

            //Assert
            mockDbSet.Verify(x => x.Find(It.Is<int>(y=>y==1)), Times.Once);
        }


        [Test]
        public void GetByIdObjectCallsDbStOnces()
        {
            //Arrange
            var mockDbSet = new Mock<IDbSet<IDeletableEntity>>();
            var entity = new Mock<IDeletableEntity>();
            mockDbSet.Setup(x => x.Add(entity.Object)).Verifiable();
            var context = new Mock<INoleggioDbContext>();
            context.Setup(x => x.Set<IDeletableEntity>()).Returns(mockDbSet.Object);
            var repository = new GenericEfRepository<IDeletableEntity>(context.Object);
            var obj = new Object();

            //Act
            repository.GetById(obj);

            //Assert
            mockDbSet.Verify(x => x.Find(obj), Times.Once);
        }

        [Test]
        public void GetByIdObjectCallsDbStOncesWithSameArguments()
        {
            //Arrange
            var mockDbSet = new Mock<IDbSet<IDeletableEntity>>();
            var entity = new Mock<IDeletableEntity>();
            mockDbSet.Setup(x => x.Add(entity.Object)).Verifiable();
            var context = new Mock<INoleggioDbContext>();
            context.Setup(x => x.Set<IDeletableEntity>()).Returns(mockDbSet.Object);
            var repository = new GenericEfRepository<IDeletableEntity>(context.Object);
            var obj = new Object();

            //Act
            repository.GetById(obj);

            //Assert
            mockDbSet.Verify(x => x.Find(It.Is<object>(y => y == obj)), Times.Once);
        }

        //[Test]
        //public void GetAllShoulReturnMocedQueriable()
        //{
        //    //Arrange
        //    var mockDbSet = new Mock<IDbSet<IDeletableEntity>>();
        //    var entity = new Mock<IDeletableEntity>();
        //    mockDbSet.Setup(x => x.Add(entity.Object)).Verifiable();
        //    mockDbSet.Setup(x=>x.Select)
        //    //var mockedResult = new List<IDeletableEntity>().AsQueryable();
        //    //mockDbSet.Setup(x => x.OfType<IDeletableEntity>()).Returns(mockedResult);
        //    var context = new Mock<INoleggioDbContext>();
        //    context.Setup(x => x.Set<IDeletableEntity>()).Returns(mockDbSet.Object);
        //    var repository = new GenericEfRepository<IDeletableEntity>(context.Object);

        //    //Act
        //    var actualResult =repository.GetAll();

        //    //Assert
        //    mockDbSet.Verify(x => x.OfType<IDeletableEntity>(), Times.Once);
        //}
    }
}
