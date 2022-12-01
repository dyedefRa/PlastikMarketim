using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PlastikMarketim.Abstracts;
using PlastikMarketim.Dtos.Products;
using PlastikMarketim.Dtos.Products.ViewModels;
using PlastikMarketim.Entities.Products;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace PlastikMarketim.Services
{
    [Authorize]
    public class ProductAppService : CrudAppService<Product, ProductDto, int, PagedAndSortedResultRequestDto, ProductDto, ProductDto>, IProductAppService
    {
        public ProductAppService(IRepository<Product, int> repository) : base(repository)
        {
        }

        public async Task<PagedResultDto<ProductViewModel>> GetProductListAsync(GetProductListRequestDto input)
        {
            var result = new PagedResultDto<ProductViewModel>();

            var query = Repository.AsQueryable();

            query = query.Include(x => x.Category).Include(x => x.Image).Include(x => x.DetailImage);

            if (!string.IsNullOrEmpty(input.NameFilter))
                query = query.Where(x => x.Name.Contains(input.NameFilter));

            var totalCount = await query.CountAsync();
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await query.ToListAsync();
            var models = entities.Select(x =>
            {
                var relatedCategory = x.Category;
                var viewModel = ObjectMapper.Map<Product, ProductViewModel>(x);
                viewModel.CategoryName = relatedCategory.Name;
                viewModel.ImageUrl = x.Image.FilePath;
                viewModel.DetailImageUrl = x.DetailImage?.FilePath;
                return viewModel;
            }).ToList();

            result.Items = models;
            result.TotalCount = totalCount;

            return result;
        }
    }
}
