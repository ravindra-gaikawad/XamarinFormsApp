using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsApp.Core.Models;
using XamarinFormsApp.Repository.Definitions;
using XamarinFormsApp.Services.Definitions;
using Xunit;

namespace XamarinFormsApp.Services.UnitTests.ItemService
{
    public class GetAsync
    {
        [Fact]
        public async void RecordExists_ReturnsList()
        {
            // Arrange
            var httpServiceMock = new Mock<IHttpService>();
            var sqLiteRepositoryMock = new Mock<ISQLiteRepository>();

            List<Item> itemsList = new List<Item>()
            {
                new Item()
                {
                    Id=1,
                    Text="sdfgh"
                }
            };
            sqLiteRepositoryMock.Setup(x => x.GetAsync<Item>()).Returns(Task.FromResult(itemsList));

            IItemService itemService = new Services.Implementations.ItemService(httpServiceMock.Object, sqLiteRepositoryMock.Object);

            // Act
            var actualResult = await itemService.GetAsync();

            // Assert
            Assert.NotEmpty(actualResult);
        }

        [Fact]
        public async void RecordNotExists_ReturnsEmptyList()
        {
            // Arrange
            var httpServiceMock = new Mock<IHttpService>();
            var sqLiteRepositoryMock = new Mock<ISQLiteRepository>();

            List<Item> itemsList = new List<Item>();
            sqLiteRepositoryMock.Setup(x => x.GetAsync<Item>()).Returns(Task.FromResult(itemsList));

            IItemService itemService = new Services.Implementations.ItemService(httpServiceMock.Object, sqLiteRepositoryMock.Object);

            // Act
            var actualResult = await itemService.GetAsync();

            // Assert
            Assert.Empty(actualResult);
        }
    }
}
