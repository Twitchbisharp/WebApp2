using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp2.Controllers;
using WebApp2.DAL;
using WebApp2.Models;

namespace xUnitTestWebapp2.Controllers
{
    public class ContributerControllerTests
    {
        [Fact]
        public async Task TestGetAll()
        {
            // Arrange
            var contributerList = new[]
            {
                new Contributer
                {
                    ContributerId = 1,
                    Name = "AJ",
                    
                },
                new Contributer
                {
                    ContributerId = 2,
                    Name = "Mickey",
                    
                }
            };
            var mockContributerRepository = new Mock<IContributerRepository>();
            mockContributerRepository.Setup(repo => repo.GetAll()).ReturnsAsync(contributerList);
            var mockLogger = new Mock<ILogger<ContributerController>>();
            var contributerController = new ContributerController(mockContributerRepository.Object, mockLogger.Object);

            // Act
            var result = await contributerController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Contributer[]>(okResult.Value);
            Assert.Equal(contributerList, model);
        }

        [Fact]
        public async Task TestCreateNotOk()
        {
            // Arrange
            var testContributer = new Contributer
            {
                ContributerId = 1,
                Name = "Lina",
            };
            var mockContributerRepository = new Mock<IContributerRepository>();
            mockContributerRepository.Setup(repo => repo.Create(testContributer)).ReturnsAsync(false);
            var mockLogger = new Mock<ILogger<ContributerController>>();
            var contributerController = new ContributerController(mockContributerRepository.Object, mockLogger.Object);

            // Act
            var result = await contributerController.Create(testContributer);

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsAssignableFrom<object>(viewResult.Value);
            
        }

    }
}
