using System.Collections.Generic;
using Account.API.Entities;

namespace Account.Dal.Impl.Seeders
{
    public  class PetRepositorySeeder
    {
        public static List<Pet> Pets = new List<Pet>()
        {
            new Pet()
            {
                PetId = 1,
                PetName = "Musya",
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
                PetName = "pet",
                Breed = "meat",
                ImageId = 1,
                IsMail = true,
                UserId = 1
            }
        };
    }
}