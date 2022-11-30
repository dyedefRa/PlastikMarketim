using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PlastikMarketim.Abstracts;
using PlastikMarketim.Dtos.Categories;
using PlastikMarketim.Dtos.Categories.ViewModels;
using PlastikMarketim.Dtos.Products;
using PlastikMarketim.Entities.Categories;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace PlastikMarketim.Services
{
    [Authorize]
    public class CategoryAppService : CrudAppService<Category, CategoryDto, int, PagedAndSortedResultRequestDto, CategoryDto, CategoryDto>, ICategoryAppService
    {
        public CategoryAppService(
           IRepository<Category, int> repository) : base(repository)
        {

        }

        public async Task<PagedResultDto<CategoryViewModel>> GetCategoryListAsync(GetProductListRequestDto input)
        {
            var result = new PagedResultDto<CategoryViewModel>();

            var query = Repository.AsQueryable();

            //FILTER
            if (!string.IsNullOrEmpty(input.NameFilter))
                query = query.Where(x => x.Name.Contains(input.NameFilter));

            var totalCount = await query.CountAsync();
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var categoryDtos = await query.ToListAsync();

            var data = categoryDtos.Select(x =>
            {
                var categoryViewModel = ObjectMapper.Map<Category, CategoryViewModel>(x);
                return categoryViewModel;
            }).ToList();

            result.Items = data;
            result.TotalCount = totalCount;

            return result;
        }

        public async Task<ListResultDto<CategoryLookupDto>> GetLookupAsync()
        {
            try
            {
                var data = await Repository.ToListAsync();
                if (data != null)
                    return new ListResultDto<CategoryLookupDto>(ObjectMapper.Map<List<Category>, List<CategoryLookupDto>>(data));

                return null;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "CategoryAppService > GetLookupAsync has error!");
                return null;
            }
        }

    }
}
