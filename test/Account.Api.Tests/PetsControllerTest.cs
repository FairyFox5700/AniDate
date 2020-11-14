using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.Controllers;
using Account.API.Entities;
using Account.Dal.Abstract.Repositories;
using AniDate.Common.Wrappers;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Account.Api.Tests
{
    public class PetsControllerTest
    {
        private PetsController petsController;
        private Mock<IPetRepository<int>> mockDataRepository;

        public PetsControllerTest()
       {
           var mockQuestions = new List<Pet>();
           for (int i = 1; i <= 10; i++)
           {
               mockQuestions.Add(
                   new Pet()
                   {
                       PetId = i,
                       AboutMe = $"I am cat {i}",
                       AnimalType = AnimalType.Cat,
                       Breed = $"meat {i}",
                       ImageId = i,
                       IsMail = true,
                       UserId = i
                   });
           }

          this.mockDataRepository = new Mock<IPetRepository<int>>();
           mockDataRepository
               .Setup(repo => repo.GetPets())
               .Returns(() => Task.FromResult(mockQuestions.AsEnumerable()));

           var mockConfigurationRoot = new Mock<IConfigurationRoot>();
           mockConfigurationRoot.SetupGet(config => 
               config[It.IsAny<string>()]).Returns("some setting");

           this.petsController = new PetsController(mockDataRepository.Object);
       }

       
        [Fact]
        public async void GetPets_WhenNoParameters_ReturnsAllPets()
        {
            var result = await petsController.GetAllPets();
            Assert.IsAssignableFrom<ApiResponse<IEnumerable<Pet>>>(result);
            Assert.NotNull(result.Data);
            Assert.False(result.IsError);
            Assert.Null(result.ResponseException);
            Assert.Equal(200,result.StatusCode);
            Assert.Equal(10, result.Data.Count());
            mockDataRepository.Verify(mock => mock.GetPets(), Times.Once());
        }

    }
}