using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Account.API.Entities;
using Account.Bl.Abstract.Services;
using Account.Dal.Abstract.Repositories;
using Account.Model.Request;
using Account.Model.Response;
using AniDate.Common.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers
{
    [ApiController]
    [Route("api/pets")]
    public class PetsController:ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
        
        //api/pets
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<PetDetailsResponse>>> GetAllPets()
        {
            return await _petService.GetPets();
        }
        
        //api/pets/{petId:int}
        [HttpGet]
        [Route("{petId}")]
        public async Task<ApiResponse<PetDetailsResponse>> GetPetById(int petId)
        {
            return await _petService.GetPetById(petId);
        }
        
        //api/pets/fotUser/{userId}
        [HttpGet]
       [Route("fotUser/{userId:int}")]
        public async Task<ApiResponse<PetDetailsResponse>> GetPetByUserId(int userId)
        {
            return await _petService.GetPetByUserId(userId);
        }
        
        [HttpPost]
        public async Task<ApiResponse<int>> PostPet([FromBody]PetPostRequest petPostRequest)
        {
            var savedPet = await _petService.AddPet(new PetPostFullRequest
            {
              AboutMe = petPostRequest.AboutMe,
              AnimalType = petPostRequest.AnimalType,
              ImageUri = "someImageUri",
              Breed = petPostRequest.Breed,
              //ImageFileName = petPostRequest.ImageFileName,
              IsMail = petPostRequest.IsMail,
              UserId = 1,//User.FindFirst(ClaimTypes.NameIdentifier).Value,
            });
            return savedPet;
        }
        
        [HttpPut("{petId:int}")]
        public async Task<ApiResponse<int>> PutPet([FromRoute]int petId, [FromBody]PetPutRequest petPutRequest)
        {
            return await _petService.UpdatePet(petId, petPutRequest);
        }
        
        [HttpDelete("{petId:int}")]
        public async Task<ApiResponse<int>> DeletePet([FromRoute]int petId)
        {
            return await _petService.DeletePet(petId);
        }

    }
}