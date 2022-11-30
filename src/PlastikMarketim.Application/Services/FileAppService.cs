using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using PlastikMarketim.Abstracts;
using PlastikMarketim.Enums;
using PlastikMarketim.Helpers;
using PlastikMarketim.Utilities.Results.Abstract;
using PlastikMarketim.Utilities.Results.Concrete;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace PlastikMarketim.Services
{
    [Authorize]
    public class FileAppService : ApplicationService, IFileAppService
    {
        public async Task<IDataResult<string>> SaveFileAsync(IFormFile fromFile, UploadType uploadType)
        {
            try
            {
                var data = await UploadHelper.UploadAsync(fromFile, uploadType);

                if (data.Success)
                    return new SuccessDataResult<string>(data.Message);

                return new ErrorDataResult<string>("Dosya eklenirken sorun oluştu.");

            }
            catch (Exception ex)
            {
                Log.Error(ex, "FileAppService > SaveFileAsync");
                return new ErrorDataResult<string>("Dosya eklenirken sorun oluştu.");
            }
        }
        //[AllowAnonymous]
        //public async Task<IDataResult<GetFileRequestDto>> GetFileAsync(Guid fileId)
        //{
        //    try
        //    {
        //        var file = await Repository.GetAsync(fileId);
        //        if (file == null)
        //        {
        //            //burada standart bir resim dönülebilir.
        //            return new ErrorDataResult<GetFileRequestDto>(await GetErrorMessage("FileNotFound", "Dosya bulunamadı."));

        //        }
        //        Byte[] fileBytes = System.IO.File.ReadAllBytes(file.FullPath);

        //        return new SuccessDataResult<GetFileRequestDto>(new GetFileRequestDto
        //        {
        //            FileBytes = fileBytes,
        //            ContentType = file.ContentType
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "FileAppService > GetFileAsync");
        //        return new ErrorDataResult<GetFileRequestDto>();
        //    }
        //}

        //public async Task SoftDeleteAsync(Guid Id)
        //{
        //    var entity = Repository.FirstOrDefault(x => x.Id == Id);
        //    entity.Status = Enums.Status.Deleted;
        //    await Repository.UpdateAsync(entity);
        //}
    }
}
