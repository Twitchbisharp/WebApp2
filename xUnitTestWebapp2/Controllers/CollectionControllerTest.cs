using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebApp2.Controllers;
using WebApp2.DAL;
using WebApp2.Models;


namespace xUnitTestWebapp2.Controllers
{
    public class CollectionControllerTest
    {
        [Fact]
        public async Task TestGetAll()
        {
            // Arrange
            var collectionList = new[]
            {
                new Collection
                {
                    CollectionId = 1,
                    CollectionName = "City",
                   
                    
                },
                new Collection
                {
                    CollectionId = 2,
                    CollectionName = "Foods",
                   
                }
            };
            var mockCollectionRepository = new Mock<ICollectionRepository>();
            mockCollectionRepository.Setup(repo => repo.GetAll()).ReturnsAsync(collectionList);
            var mockLogger = new Mock<ILogger<CollectionController>>();
            var collectionController = new CollectionController(mockCollectionRepository.Object, mockLogger.Object);

            // Act
            var result = await collectionController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Collection[]>(okResult.Value);
            Assert.Equal(collectionList, model);
        }

        [Fact]
        public async Task TestCreateNotOk()
        {
            // Arrange
            var testCollection = new Collection
            {
                CollectionId = 1,
                CollectionName = "Cakes",
                
            };
            var mockCollectionRepository = new Mock<ICollectionRepository>();
            mockCollectionRepository.Setup(repo => repo.Create(testCollection)).ReturnsAsync(false);
            var mockLogger = new Mock<ILogger<CollectionController>>();
            var collectionController = new CollectionController(mockCollectionRepository.Object, mockLogger.Object);

            // Act
            var result = await collectionController.Create(testCollection);

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsAssignableFrom<object>(viewResult.Value);
           
        }

    }
}
