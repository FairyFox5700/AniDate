using System.Collections.Generic;
using System.Threading.Tasks;
using Account.API.Entities;
using Account.Model.Request;

namespace Account.Dal.Abstract.Repositories
{
    public interface IPetRepository<T> where T:struct
    {
        Task<IEnumerable<Pet>> GetPets();
        Task<Pet> GetPetById(int petId);
        Task<Pet> GetPetByUserId(int userId);
        Task<int> AddPet(Pet newPet);
        Task<Pet> UpdatePet(int petId, Pet petPutRequest);
        Task<bool> DeletePet(int petId);
    }
}