using Microsoft.AspNetCore.Http;
using PlastikMarketim.Dtos.Files;
using PlastikMarketim.Enums;
using PlastikMarketim.Extensions;
using PlastikMarketim.Utilities.Results.Abstract;
using PlastikMarketim.Utilities.Results.Concrete;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PlastikMarketim.Helpers
{
    public static class UploadHelper
    {
        public static async Task<IDataResult<FileDto>> UploadAsync(IFormFile file, UploadType uploadType)
        {
            if (file.Length <= 0)
                return new ErrorDataResult<FileDto>("Dosya boş.");

            string relatedSettingFolder = EnumExtensions.GetEnumDescription(uploadType);

            var uploads = Path.Combine(Directory.GetCurrentDirectory(), relatedSettingFolder);
            string fileName = GenerateFileName(file.FileName);
            string filePath = Path.Combine(uploads, fileName);

            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var media = new FileDto();
            media.ContentType = file.ContentType;
            media.FileName = fileName;
            media.FilePath = Path.Combine(relatedSettingFolder.ToFileShownPath(), fileName);
            media.FullPath = filePath;
            media.FileExtension = Path.GetExtension(filePath);
            media.FileSize = file.Length;
            media.Status = Status.Active;

            return new SuccessDataResult<FileDto>(media);
        }

        private static string GenerateFileName(string fileName) => string.Format($"{Guid.NewGuid()}_{DateTime.Now.ToString("dd-M-yyyy-HH-mm-ss")}{Path.GetExtension(fileName)}");

    }
}
