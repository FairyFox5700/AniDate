using Microsoft.AspNetCore.Http;

namespace Account.Model.Models
{
    public class ImageModel
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}