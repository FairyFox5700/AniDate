using System.Collections.Generic;
using System.Threading.Tasks;
using Account.API.Entities;

namespace Account.Dal.Abstract.Repositories
{
    public interface IImageRepository<in T> where T:struct
    {
        Task<int> AddImage(Image newImage);
        Task<Pet> UpdateImage(Image imageForUpdate);
        Task<bool> DeleteImage(T imageId);
        Task<Image> GetImageById(int imageId);
    }
}