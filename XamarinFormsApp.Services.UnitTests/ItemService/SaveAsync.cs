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
    public class SaveAsync
    {
        [Fact]
        public async void NoId_Insert()
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
            sqLiteRepositoryMock.Setup(x => x.SaveAsync<Item>(It.IsAny<Item>())).Returns(Task.FromResult(1));
            
            IItemService itemService = new Services.Implementations.ItemService(httpServiceMock.Object, sqLiteRepositoryMock.Object);

            Item item = new Item()
            {
                Text = "inserted"
            };

            // Act
            var actualResult = await itemService.SaveAsync(item);

            // Assert
            Assert.True(actualResult > 0);
        }

        [Fact]
        public async void HasId_Update()
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
            sqLiteRepositoryMock.Setup(x => x.SaveAsync<Item>(It.IsAny<Item>())).Returns(Task.FromResult(1));

            IItemService itemService = new Services.Implementations.ItemService(httpServiceMock.Object, sqLiteRepositoryMock.Object);

            Item item = new Item()
            {
                Id = 1,
                Text = "new"
            };

            // Act
            var actualResult = await itemService.SaveAsync(item);

            // Assert
            Assert.True(actualResult > 0);
        }

        [Fact]
        public async void NoRecordExist_CannotNotUpdate()
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
            sqLiteRepositoryMock.Setup(x => x.SaveAsync<Item>(It.IsAny<Item>())).Returns(Task.FromResult(0));

            IItemService itemService = new Services.Implementations.ItemService(httpServiceMock.Object, sqLiteRepositoryMock.Object);

            Item item = new Item()
            {
                Id = 2,
                Text = "update"
            };

            // Act
            var actualResult = await itemService.SaveAsync(item);

            // Assert
            Assert.True(actualResult == 0);
        }
    }
}
