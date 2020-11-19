
using System;
using System.IO;
using System.Threading.Tasks;
using Account.API.Entities;
using Account.Dal.Abstract.Repositories;
using Account.Model.Models;
using AniDate.Common.Wrappers;
using Microsoft.AspNetCore.Hosting;

namespace Account.Bl.Impl.Services
{
    public class ImageUploaderService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageRepository<int> _imageRepository;

        public ImageUploaderService(IWebHostEnvironment webHostEnvironment, IImageRepository<int> imageRepository )
        {
            _webHostEnvironment = webHostEnvironment;
            _imageRepository = imageRepository;
        }
        //TODO refactor this
        public async Task<ApiResponse> UploadImage(ImageModel imageModel)
        {
            //Save image to wwwroot/image
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            var uploadImageName =  fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.ImageName = fileName = uploadImageName;
            string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            await using var fileStream = new FileStream(path, FileMode.Create);
                await imageModel.ImageFile.CopyToAsync(fileStream);
            //Insert record
            var newImage = new Image()
            {
                ImageFileName = uploadImageName,
                ImageUri = path,
                Extension = extension
                
            };
            //TODO on error response 
            var imageId = await _imageRepository.AddImage(newImage);
            return  new ApiResponse<int>()
            {
                Data = imageId,
                StatusCode = 200,
                IsError = false
            };
        }
        
        public async Task<ApiResponse<int>> DeleteImage(int imageId)
        {
            var image = await _imageRepository.GetImageById(imageId);
            if (image == null)
                return ApiResponse<int>.NotFound;

            //delete image from wwwroot/image
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath,"image",image.ImageFileName);
            if (File.Exists(imagePath))
                File.Delete(imagePath);
            //delete the record
            var deleteResponse =  await _imageRepository.DeleteImage(imageId);
            if(deleteResponse)
                return  new ApiResponse<int>()
                {
                    Data = imageId,
                    StatusCode = 200,
                    IsError = false
                };
            return ApiResponse<int>.BadRequest;
        }
    }
}