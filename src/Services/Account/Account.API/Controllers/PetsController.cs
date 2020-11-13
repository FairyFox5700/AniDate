using System.Collections.Generic;
using System.Linq;
using Account.API.Entities;
using AniDate.Common.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers
{
    [ApiController]
    [Route("api/pets")]
    public class PetsController:ControllerBase
    {
        public PetsController()
        {
            
        }
        //TODO DTOs!!!
        [HttpGet]
        public ApiResponse<IEnumerable<Pet>> GetAllPets()
        {
           return  new ApiResponse<IEnumerable<Pet>>()
           {
               Data = new List<Pet>
               {
                   new Pet()
                   {
                       PetId = 1,
                       AboutMe = "I am cat",
                       AnimalType = AnimalType.Cat,
                       Breed = "meat",
                       ImageId = 1,
                       IsMail = true,
                       UserId = 1
                   },
                   new Pet()
                   {
                       PetId = 2,
                       AboutMe = "I am cat",
                       AnimalType = AnimalType.Cat,
                       Breed = "meat",
                       ImageId = 1,
                       IsMail = true,
                       UserId = 1
                   }
               }
           };
           
        }
    }
}