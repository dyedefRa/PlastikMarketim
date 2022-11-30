using Microsoft.AspNetCore.Http;
using PlastikMarketim.Enums;
using PlastikMarketim.Utilities.Results.Abstract;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace PlastikMarketim.Abstracts
{
    public interface IFileAppService : IApplicationService
    {
        Task<IDataResult<string>> SaveFileAsync(IFormFile fromFile, UploadType uploadType);
    }
}
