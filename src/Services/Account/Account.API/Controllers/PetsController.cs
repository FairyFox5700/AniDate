using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Account.API.Entities;
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
        private readonly IPetRepository<int> _petRepository;

        public PetsController(IPetRepository<int>petRepository)
        {
            _petRepository = petRepository;
        }
        
        //api/pets
        //TODO DTOs!!!
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<Pet>>> GetAllPets()
        {
            return new ApiResponse<IEnumerable<Pet>>(await _petRepository.GetPets());
        }
        
        //api/pets?petId={petId}
        [HttpGet]
        [Route("{petId}")]
        public async Task<ApiResponse<IEnumerable<Pet>>> GetPetById(int petId)
        {
            return new ApiResponse<IEnumerable<Pet>>(await _petRepository.GetPetById(petId));
        }
        
       
}