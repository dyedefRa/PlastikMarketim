using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using PlastikMarketim.Abstracts;
using PlastikMarketim.Dtos.Files;
using PlastikMarketim.Entities.Files;
using PlastikMarketim.Enums;
using PlastikMarketim.Helpers;
using PlastikMarketim.Utilities.Results.Abstract;
using PlastikMarketim.Utilities.Results.Concrete;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace PlastikMarketim.Services
{
    [Authorize]
    public class FileAppService : CrudAppService<File, FileDto, int, PagedAndSortedResultRequestDto, FileDto, FileDto>, IFileAppService
    {
        public FileAppService(IRepository<File, int> repository) : base(repository)
        {
        }

        public async Task<IDataResult<FileDto>> SaveFileAsync(IFormFile fromFile, UploadType uploadType)
        {
            try
            {
                var data = await UploadHelper.UploadAsync(fromFile, uploadType);
                var entity = ObjectMapper.Map<FileDto, File>(data.Data);
                var insertedData = await Repository.InsertAsync(entity, true);
                var resultDto = ObjectMapper.Map<File, FileDto>(insertedData);
                return new SuccessDataResult<FileDto>(resultDto);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "FileAppService > SaveFileAsync has error !");

                return new ErrorDataResult<FileDto>(new FileDto(), "Dosya eklenirken sorun oluştu.");
            }
        }

        public async Task SoftDeleteAsync(int Id)
        {
            var entity = Repository.FirstOrDefault(x => x.Id == Id);
            entity.Status = Enums.Status.Deleted;
            await Repository.UpdateAsync(entity);
        }
    }
}
