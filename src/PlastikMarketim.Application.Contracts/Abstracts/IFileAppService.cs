using Microsoft.AspNetCore.Http;
using PlastikMarketim.Dtos.Files;
using PlastikMarketim.Enums;
using PlastikMarketim.Utilities.Results.Abstract;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PlastikMarketim.Abstracts
{
    public interface IFileAppService : ICrudAppService<FileDto, int, PagedAndSortedResultRequestDto, FileDto, FileDto>
    {
        Task<IDataResult<FileDto>> SaveFileAsync(IFormFile fromFile, UploadType uploadType);
        Task SoftDeleteAsync(int Id);
    }
}
