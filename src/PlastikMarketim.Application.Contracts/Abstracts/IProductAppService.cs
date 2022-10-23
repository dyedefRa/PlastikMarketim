using PlastikMarketim.Dtos.Products;
using PlastikMarketim.Dtos.Products.ViewModels;
using PlastikMarketim.Entities.Products;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PlastikMarketim.Abstracts
{
    public interface IProductAppService : ICrudAppService<ProductDto, int, PagedAndSortedResultRequestDto, ProductDto, ProductDto>
    {
        Task<PagedResultDto<ProductViewModel>> GetProductListAsync(GetProductListRequestDto input);
    }
}
