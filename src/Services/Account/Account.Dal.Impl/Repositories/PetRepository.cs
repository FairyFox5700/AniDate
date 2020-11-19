using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.Entities;
using Account.Dal.Abstract.Repositories;
using Account.Dal.Impl.Seeders;

namespace Account.Dal.Impl.Repositories
{
    public class PetRepository:IPetRepository<int>
    {
        private readonly List<Pet> _petsListHolder;
        public PetRepository()
        {
            this._petsListHolder = PetRepositorySeeder.Pets;
        }
        public async Task<IEnumerable<Pet>> GetPets()
        {
            return await Task.FromResult(_petsListHolder);
        }

        public async Task<Pet> GetPetById(int petId)
        {
            return await Task.FromResult(_petsListHolder
                .FirstOrDefault(p => p.PetId == petId));
        }

        public async Task<Pet> GetPetByUserId(int userId)
        {
            return await Task.FromResult(_petsListHolder
                .FirstOrDefault(p => p.UserId == userId));
        }

        public async Task<int> AddPet(Pet pet)
        {
            pet.PetId = _petsListHolder.Count + 1;
            _petsListHolder.Add(pet);
            return await Task.FromResult(pet.PetId);

        }

        public async Task<Pet> UpdatePet(Pet petPutRequest)
        {
            var pet = await GetPetById(petPutRequest.PetId);
            if (pet == null)
                throw new ArgumentNullException(nameof(pet));
            _petsListHolder.Remove(pet);
            _petsListHolder.Add(pet);
            return await Task.FromResult(pet);
        }

        public async Task<int> DeletePet(int petId)
        {
            var pet = await GetPetById(petId);
            if (pet == null)
                throw new ArgumentNullException(nameof(pet));
            _petsListHolder.Remove(pet);
            return await Task.FromResult(petId);
        }
    }
}