using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.Entities;
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

        public async Task<ApiResponse<IEnumerable<PetDetailsResponse>>> GetPets()
        {
            var result = (await _petRepository.GetPets())
                .Select(model=>new PetDetailsResponse()
                {
                    AboutMe = model.AboutMe,
                    Breed = model.Breed,
                    AnimalType = model.AnimalType,
                    ImageFileName = "TODO/image-change",
                    ImageUri = "/image/uri/TODO-change-me",
                    IsMail = model.IsMail,
                    PetId = model.PetId,
                    PetName = model.PetName,
                    UserId = model.UserId
                })
                .ToList();
            //TODO call image service
            return new ApiResponse<IEnumerable<PetDetailsResponse>>(result);
        }

        public async Task<ApiResponse<PetDetailsResponse>> GetPetById(int petId)
        {
            var petFounded = (await _petRepository.GetPetById(petId));
            if(petFounded==null)
                return ApiResponse<PetDetailsResponse>.NotFound;
            return new ApiResponse<PetDetailsResponse>(new PetDetailsResponse()
            {
                AboutMe = petFounded.AboutMe,
                Breed = petFounded.Breed,
                AnimalType = petFounded.AnimalType,
                ImageFileName = "TODO/image-change",
                ImageUri = "/image/uri/TODO-change-me",
                IsMail = petFounded.IsMail,
                PetId = petFounded.PetId,
                PetName = petFounded.PetName,
                UserId =petFounded.UserId
            });
            //TODO call image service
        }

        public async Task<ApiResponse<PetDetailsResponse>> GetPetByUserId(int userId)
        {
            var petFounded = (await _petRepository.GetPetByUserId(userId));
            if(petFounded==null)
                return ApiResponse<PetDetailsResponse>.NotFound;
            return new ApiResponse<PetDetailsResponse>(new PetDetailsResponse()
            {
                AboutMe = petFounded.AboutMe,
                Breed = petFounded.Breed,
                AnimalType = petFounded.AnimalType,
                ImageFileName = "TODO/image-change",
                ImageUri = "/image/uri/TODO-change-me",
                IsMail = petFounded.IsMail,
                PetId = petFounded.PetId,
                PetName = petFounded.PetName,
                UserId =petFounded.UserId
            });
            //TODO call image service
        }

        public async Task<ApiResponse<int>> AddPet(PetPostFullRequest model)
        {
            try
            {
                var pet = new Pet()
                {
                    AboutMe = model.AboutMe,
                    Breed = model.Breed,
                    AnimalType = model.AnimalType,
                    PetName = model.PetName,
                    //TODO go to image service and add image then return image id
                    IsMail = model.IsMail,
                    //TODO check if user exists !!!
                    UserId = model.UserId
                };

                var result = await _petRepository.AddPet(pet);
                return new ApiResponse<int>(result);
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.ServerError;
            }
        }

        public async Task<ApiResponse<int>> UpdatePet(int petId, PetPutRequest petPutRequest)
        {
            var pet = await _petRepository.GetPetById(petId);
            if (pet == null)
            {
                return ApiResponse<int>.NotFound;
            }
            pet.Breed = petPutRequest.Breed;
            pet.AboutMe = petPutRequest.AboutMe;
            pet.AnimalType = petPutRequest.AnimalType;
            pet.IsMail = petPutRequest.IsMail;
            pet.PetName = petPutRequest.PetName;
           //TODO add image for pet
            var savedQuestion = await _petRepository.UpdatePet(pet);
            return new ApiResponse<int>(savedQuestion.PetId);
        }

        public async Task<ApiResponse<int>> DeletePet(int petId)
        {
            //TODO in transaction
            try
            {
                var pet = await _petRepository.GetPetById(petId);
                if (pet == null)
                    return ApiResponse<int>.NotFound;
                //TODO delete image in service accordingly
                var deletedId = await _petRepository.DeletePet(pet.PetId);
                return new ApiResponse<int>(deletedId);
            }
            catch (Exception ex)
            {
                return  ApiResponse<int>.ServerError;
            }
            
        }
    }
}