using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Bl.Abstract.Services;
using Account.Dal.Abstract.Repositories;
using Account.Model.Request;
using Account.Model.Response;
using AniDate.Common.Wrappers;

namespace Account.Bl.Impl.Services
{
    public class PetService:IPetService
    {
        private readonly IPetRepository<int> _petRepository;

        public PetService(IPetRepository<int> petRepository)
        {
            _petRepository = petRepository;
        }

        public Task<ApiResponse<IEnumerable<PetDetailsResponse>>> GetPets()
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResponse<PetDetailsResponse>> GetPetById(int petId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResponse<PetDetailsResponse>> GetPetByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResponse<int>> AddPet(PetPostFullRequest petPostFullRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResponse<PetDetailsResponse>> UpdatePet(int petId, PetPutRequest petPutRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResponse> DeletePet(int petId)
        {
            throw new System.NotImplementedException();
        }
    }
}