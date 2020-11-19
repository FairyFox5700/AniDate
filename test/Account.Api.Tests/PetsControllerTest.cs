using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Account.API.Controllers;
using Account.API.Entities;
using Account.Bl.Abstract.Services;
using Account.Bl.Impl.Services;
using Account.Dal.Abstract.Repositories;
using Account.Model.Request;
using Account.Model.Response;
using AniDate.Common;
using AniDate.Common.Extensions;
using AniDate.Common.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Account.Api.Tests
{
    public class PetsControllerTest
    {
        private Mock<IPetService> _petsServiceMock;
        private PetsController _controller;
        private List<PetDetailsResponse> mockPets;

        public PetsControllerTest()
        {
            this._petsServiceMock = new Mock<IPetService>();
            this.mockPets = new List<PetDetailsResponse>();
            for (int i = 1; i <= 10; i++)
            {
                mockPets.Add(
                    new PetDetailsResponse()
                    {
                        PetId = i,
                        AboutMe = $"I am cat {i}",
                        AnimalType = AnimalType.Cat,
                        Breed = $"meat {i}",
                        ImageFileName = $"TODO/image-change-{i}",
                        ImageUri = $"/image/uri/TODO-change-me-{i}",
                        IsMail = true,
                        UserId = i
                    });
            }
            _controller = new PetsController(_petsServiceMock.Object);
        }
        
        
        [Fact]
        public async void GetPetById_WhenPetNotFound_ReturnsNotFound()
        {
            _petsServiceMock.Setup(x => x.GetPetById(-1))
                .Returns(() =>Task.FromResult(ApiResponse<PetDetailsResponse>.NotFound));
            var result = await _controller.GetPetById(-1);
            Assert.IsType<ApiResponse<PetDetailsResponse>>(result);
            Assert.True(result.IsError);
            Assert.Null(result.Data);
            Assert.NotNull(result.ResponseException);
            Assert.IsAssignableFrom<ApiErrorResponse>(result.ResponseException);
            Assert.Equal(ErrorMessage.NotFound.GetDescription(),result.ResponseException.Message );
            Assert.Equal(404,result.StatusCode);
            _petsServiceMock.Verify(mock => mock.GetPetById(-1), Times.Once());
        }

        [Fact]
        public async void GetPetById_WhenPetFound_ReturnsCorrectPet()
        {
            _petsServiceMock.Setup(x => x.GetPetById(It.IsAny<int>()))
                .Returns(() =>Task.FromResult(new ApiResponse<PetDetailsResponse>(mockPets[0])));
            var result = await _controller.GetPetById(1);
            Assert.IsType<ApiResponse<PetDetailsResponse>>(result);
            Assert.False(result.IsError);
            Assert.NotNull(result.Data);
            Assert.Null(result.ResponseException);
            Assert.Equal(1,result.Data.PetId);
            Assert.Equal(200,result.StatusCode);
            _petsServiceMock.Verify(mock => mock.GetPetById(It.IsAny<int>()), Times.Once());
        }
        
        [Fact]
        public async void GetPets_WhenNoParameters_ReturnsAllPets()
        {
            _petsServiceMock.Setup(x => x.GetPets())
                .Returns(() =>Task.FromResult(new ApiResponse<IEnumerable<PetDetailsResponse>>(mockPets)));
            _controller = new PetsController(_petsServiceMock.Object);
            var result = await _controller.GetAllPets();
            Assert.IsAssignableFrom<ApiResponse<IEnumerable<PetDetailsResponse>>>(result);
            Assert.NotNull(result.Data);
            Assert.False(result.IsError);
            Assert.Null(result.ResponseException);
            Assert.Equal(200,result.StatusCode);
            Assert.Equal(10, result.Data.Count());
            _petsServiceMock.Verify(mock => mock.GetPets(), Times.Once());
        }
        
        [Fact]
        public async void GetPetByUserId_WhenPetNotFound_ReturnsNotFound()
        {
            _petsServiceMock.Setup(x => x.GetPetByUserId(-1))
                .Returns(() =>Task.FromResult(ApiResponse<PetDetailsResponse>.NotFound));
            var result = await _controller.GetPetByUserId(-1);
            Assert.IsType<ApiResponse<PetDetailsResponse>>(result);
            Assert.True(result.IsError);
            Assert.Null(result.Data);
            Assert.NotNull(result.ResponseException);
            Assert.IsAssignableFrom<ApiErrorResponse>(result.ResponseException);
            Assert.Equal(ErrorMessage.NotFound.GetDescription(),result.ResponseException.Message );
            Assert.Equal(404,result.StatusCode);
            _petsServiceMock.Verify(mock => mock.GetPetByUserId(It.IsAny<int>()), Times.Once());
        }
        
        [Fact]
        public async void GetPetByUserId_WhenPetFound_ReturnsCorrectPet()
        {
            _petsServiceMock.Setup(x => x.GetPetByUserId(It.IsAny<int>()))
                .Returns(() =>Task.FromResult(new ApiResponse<PetDetailsResponse>(mockPets[0])));
            var result = await _controller.GetPetByUserId(1);
            Assert.IsType<ApiResponse<PetDetailsResponse>>(result);
            Assert.False(result.IsError);
            Assert.NotNull(result.Data);
            Assert.Null(result.ResponseException);
            Assert.Equal(1,result.Data.PetId);
            Assert.Equal(1, result.Data.UserId);
            Assert.Equal(200,result.StatusCode);
            _petsServiceMock.Verify(mock => mock.GetPetByUserId(1), Times.Once());
        }
        
        
        
        [Fact]
        public async void PostPet_WhenNewAdded_ReturnsCreatedPetId()
        {
            var postPet = new PetPostRequest
            {
                AboutMe = "about pet",
                AnimalType = AnimalType.Dog,
                Breed = "meat",
                IsMail = true,
                ImageFile = null

            };
            var newPet = new PetPostFullRequest
            {
                AboutMe = postPet.AboutMe,
                AnimalType = postPet.AnimalType,
                ImageUri = "someImageUri",
                Breed = postPet.Breed,
                IsMail = postPet.IsMail,
                ImageFileName = "image file name",
                UserId = 1
            };
            _petsServiceMock.Setup(x => x.AddPet(It.IsAny<PetPostFullRequest>()))
                .Returns(() =>Task.FromResult(new ApiResponse<int>(mockPets[^1].PetId)));
            // Act
            var result =await _controller.PostPet(postPet);
            // Assert
            Assert.IsType<ApiResponse<int>>(result);
            Assert.False(result.IsError);
            Assert.Null(result.ResponseException);
            Assert.Equal(mockPets[^1].PetId,result.Data);
            Assert.Equal(200, result.StatusCode);
            _petsServiceMock.Verify(mock => mock.AddPet(It.IsAny<PetPostFullRequest>()), Times.Once());
        }
        
        [Fact]
        public async void PutPet_WhenNewAdded_ReturnsCreatedPetId()
        {
            var putPet = new PetPutRequest()
            {
                AboutMe = "about pet 1",
                AnimalType = AnimalType.Cat,
                Breed = "meat 2",
                IsMail = false,
                ImageFile = null,
                PetId = 1,
                UserId = 1
            };
            _petsServiceMock.Setup(x => x.UpdatePet(It.IsAny<int>(),It.IsAny<PetPutRequest>()))
                .Returns(() =>Task.FromResult(new ApiResponse<int>(1)));
            // Act
            var result =await _controller.PutPet(1,putPet);
            // Assert
            Assert.IsType<ApiResponse<int>>(result);
            Assert.False(result.IsError);
            Assert.Null(result.ResponseException);
            Assert.Equal(1,result.Data);
            Assert.Equal(200, result.StatusCode);
            _petsServiceMock.Verify(mock => mock.UpdatePet(It.IsAny<int>(),It.IsAny<PetPutRequest>()), Times.Once());
        }
              
        [Fact]
        public async void DeletePet_WhenNotFound_ReturnsNotFound()
        {
            _petsServiceMock.Setup(x => x.DeletePet(-1))
                .Returns(() =>Task.FromResult(ApiResponse<int>.NotFound));
            // Act
            var result =await _controller.DeletePet(-1);
            // Assert
            Assert.IsType<ApiResponse<int>>(result);
            Assert.True(result.IsError);
            Assert.NotNull(result.ResponseException);
            Assert.IsAssignableFrom<ApiErrorResponse>(result.ResponseException);
            Assert.Equal(ErrorMessage.NotFound.GetDescription(),result.ResponseException.Message );
            Assert.Equal(404,result.StatusCode);
            _petsServiceMock.Verify(mock => mock.DeletePet(It.IsAny<int>()), Times.Once());
        }
        
        
        [Fact]
        public async void DeletePet_WhenFound_ReturnDeletedPetId()
        {
            _petsServiceMock.Setup(x => x.DeletePet(It.IsAny<int>()))
                .Returns(() =>Task.FromResult(new ApiResponse<int>(1)));
            // Act
            var result =await _controller.DeletePet(1);
            // Assert
            Assert.IsType<ApiResponse<int>>(result);
            Assert.False(result.IsError);
            Assert.Null(result.ResponseException);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(1, result.Data);
            _petsServiceMock.Verify(mock => mock.DeletePet(It.IsAny<int>()), Times.Once());
        }


    }
}