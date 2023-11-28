
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


/////////////////Intended Code

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;  
using Moq;
using WebApp2.Controllers;
using WebApp2.DAL;
using WebApp2.Models;
using Xunit;

namespace WebApp2.Tests.Controllers
{
    public class FlashcardControllerTests
    {
        [Fact]
        public async Task TestGetAll()
        {
            // Arrange
            var flashcardList = new[]
            {
                new Flashcard
                {
                    FlashcardId = 1,
                    Name = "Fake LMAO",
                    Description = "My N John Cut his ",
                    ImageUrl = "/None.png"
                },
                new Flashcard
                {
                    FlashcardId = 2,
                    Name = "True Rn",
                    Description = "Happens ig",
                    ImageUrl = "/NoneAgain.png"
                }
            };
            var mockFlashcardRepository = new Mock<IFlashcardRepository>();
            mockFlashcardRepository.Setup(repo => repo.GetAll()).ReturnsAsync(flashcardList);
            var mockLogger = new Mock<ILogger<FlashcardController>>();
            var flashcardController = new FlashcardController(mockFlashcardRepository.Object, mockLogger.Object);

            // Act
            var result = await flashcardController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Flashcard[]>(okResult.Value);
            Assert.Equal(flashcardList, model);
        }

        [Fact]
        public async Task TestCreateNotOk()
        {
            // Arrange
            var testFlashcard = new Flashcard
            {
                FlashcardId = 1,
                Name = "SmtIg",
                Description = "Number20",
                ImageUrl = "/picture/Dir/chick.png"
            };
            var mockFlashcardRepository = new Mock<IFlashcardRepository>();
            mockFlashcardRepository.Setup(repo => repo.Create(testFlashcard)).ReturnsAsync(false);
            var mockLogger = new Mock<ILogger<FlashcardController>>();
            var flashcardController = new FlashcardController(mockFlashcardRepository.Object, mockLogger.Object);

            // Act
            var result = await flashcardController.Create(testFlashcard);

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsAssignableFrom<object>(viewResult.Value);
           
        }
    }
}
