using System.Collections.Generic;
using System.Threading.Tasks;
using Account.API.Entities;
using Account.Dal.Abstract.Repositories;

namespace Account.Dal.Impl.Repositories
{
    public class PetRepository:IPetRepository<int>
    {
        public async Task<IEnumerable<Pet>> GetPets()
        {
            return  await Task.FromResult(new List<Pet>()
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
            });
        }

        public Task<Pet> GetPetById(int petId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Pet> GetPetByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> AddPet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public Task<Pet> UpdatePet(int petId, Pet petPutRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeletePet(int petId)
        {
            throw new System.NotImplementedException();
        }
    }
}