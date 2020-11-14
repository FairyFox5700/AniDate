using Account.API.Entities;
using Microsoft.AspNetCore.Http;

namespace Account.Model.Request
{
    public class PetPutRequest
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public int UserId { get; set; }
        public bool IsMail { get; set; }
        public string Breed { get; set; }
        public AnimalType AnimalType { get; set; }
        public string AboutMe { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}