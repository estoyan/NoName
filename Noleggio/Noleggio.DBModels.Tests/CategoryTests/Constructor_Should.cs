using NUnit.Framework;
using Ploeh.AutoFixture;

using Noleggio.DbModels;

namespace Noleggio.DBModels.CategoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnNewInstance()
        {
            //Arrange
            var fixture = new Fixture();
            var name = fixture.Create<string>().Substring(0, 10);

            //Act
            var category = new Category(name);

            //Assert
            Assert.IsNotNull(category);
        }

        [Test]
        public void ReturnNewInstanceOfCategory()
        {
            //Arrange
            var fixture = new Fixture();
            var name = fixture.Create<string>().Substring(0, 10);

            //Act
            var category = new Category(name);

            //Assert
            Assert.IsInstanceOf<Category>(category);
        }

        [Test]
        public void SetsNameCorectly()
        {
            //Arrange
            var fixture = new Fixture();
            var name = fixture.Create<string>().Substring(0, 10);

            //Act
            var category = new Category(name);

            //Assert
            Assert.AreSame(name,category.Name);
        }

        [Test]
        public void InitialiazeItemsCollecion()
        {
            //Arrange
            var fixture = new Fixture();
            var name = fixture.Create<string>().Substring(0, 10);

            //Act
            var category = new Category(name);

            //Assert
            Assert.IsNotNull(category.Items);
        }
    }
}