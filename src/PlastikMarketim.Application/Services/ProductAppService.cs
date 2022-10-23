using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PlastikMarketim.Abstracts;
using PlastikMarketim.Dtos.Products;
using PlastikMarketim.Dtos.Products.ViewModels;
using PlastikMarketim.Entities.Products;
using PlastikMarketim.Permissions;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace PlastikMarketim.Services
{
    [Authorize(PlastikMarketimPermissions.Products.Default)]
    public class ProductAppService : CrudAppService<Product, ProductDto, int, PagedAndSortedResultRequestDto, ProductDto, ProductDto>
  , IProductAppService
    {
        public ProductAppService(
           IRepository<Product, int> repository) : base(repository)
        {
        }

        public async Task<PagedResultDto<ProductViewModel>> GetProductListAsync(GetProductListRequestDto input)
        {
            var result = new PagedResultDto<ProductViewModel>();

            var query = Repository.AsQueryable();

            query = query.Include(x => x.Category);

            //FILTER
            if (!string.IsNullOrEmpty(input.NameFilter))
                query = query.Where(x => x.Name.Contains(input.NameFilter));

            var totalCount = await query.CountAsync();
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var productDtos = await query.ToListAsync();

            var data = productDtos.Select(x =>
            {
                var relatedCategory = x.Category;
                var productViewModel = ObjectMapper.Map<Product, ProductViewModel>(x);
                productViewModel.CategoryName = relatedCategory.Name;
                return productViewModel;
            }).ToList();

            result.Items = data;
            result.TotalCount = totalCount;

            return result;
        }
    }
}
