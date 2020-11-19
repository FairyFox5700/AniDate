using System.Threading.Tasks;
using Account.API.Entities;
using Account.Dal.Abstract.Repositories;

namespace Account.Dal.Impl.Repositories
{
    public class ImageRepository:IImageRepository<int>
    {
        public Task<int> AddImage(Image newImage)
        {
            throw new System.NotImplementedException();
        }

        public Task<Pet> UpdateImage(Image imageForUpdate)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteImage(int imageId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Image> GetImageById(int imageId)
        {
            throw new System.NotImplementedException();
        }
    }
}