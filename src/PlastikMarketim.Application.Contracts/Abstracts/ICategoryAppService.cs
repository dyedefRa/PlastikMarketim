using PlastikMarketim.Dtos.Categories;
using PlastikMarketim.Entities.Categories;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PlastikMarketim.Abstracts
{
    public interface ICategoryAppService : ICrudAppService<CategoryDto, int, PagedAndSortedResultRequestDto, CategoryDto, CategoryDto>
    {
        Task<ListResultDto<CategoryLookupDto>> GetLookupAsync();
    }
}
