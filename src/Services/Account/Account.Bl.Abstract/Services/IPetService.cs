using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Model.Request;
using Account.Model.Response;
using AniDate.Common.Wrappers;

namespace Account.Bl.Abstract.Services
{
    public interface IPetService
    {
        Task<ApiResponse<IEnumerable<PetDetailsResponse>>> GetPets();
        Task<ApiResponse<PetDetailsResponse>> GetPetById(int petId);
        Task<ApiResponse<PetDetailsResponse>> GetPetByUserId(int userId);
        Task<ApiResponse<int>> AddPet(PetPostFullRequest petPostFullRequest);
        Task<ApiResponse<PetDetailsResponse>> UpdatePet(int petId, PetPutRequest petPutRequest);
        Task<ApiResponse> DeletePet(int petId);
    }
}