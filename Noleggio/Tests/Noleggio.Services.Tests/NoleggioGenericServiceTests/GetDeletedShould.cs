﻿using Moq;
using Noleggio.Data.Contracts;
using Noleggio.DbModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Services.Tests.NoleggioGenericServiceTests
{
    [TestFixture]
    public class GetDeletedShould
    {
        //TODO check this test
        //[Test]
        //public void GetDeletedShouldCallRepositoryGetAllOnce()
        //{
        //    //Arrange
        //    var mockeRepository = new Mock<IGenericEfRepository<Category>>();
        //    var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //    var genericService = new NoleggioGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
        //    mockeRepository.Setup(x => x.GetAll(y => y.IsDeleted)).Verifiable();

        //    //Act
        //    genericService.GetDeleted();

        //    //Assert
        //    mockeRepository.Verify(x => x.GetAll(y => y.IsDeleted), Times.Once);
        //}
    }
}