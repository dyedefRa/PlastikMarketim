using Microsoft.AspNetCore.Http;
using PlastikMarketim.Enums;
using PlastikMarketim.Extensions;
using PlastikMarketim.Utilities.Results.Abstract;
using PlastikMarketim.Utilities.Results.Concrete;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PlastikMarketim.Helpers
{
    public static class UploadHelper
    {
        public static async Task<IDataResult<string>> UploadAsync(IFormFile file, UploadType uploadType)
        {
            try
            {
                if (file.Length <= 0)
                    return new ErrorDataResult<string>("Dosya boş.");

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

                return new SuccessDataResult<string>(filePath);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "UploadHelper > UploadAsync has error !");
                return new ErrorDataResult<string>("Dosya eklenirken sorun oluştu.");
            }
        }

        private static string GenerateFileName(string fileName) => string.Format($"{Guid.NewGuid()}_{DateTime.Now.ToString("dd-M-yyyy-HH-mm-ss")}{Path.GetExtension(fileName)}");

    }
}
