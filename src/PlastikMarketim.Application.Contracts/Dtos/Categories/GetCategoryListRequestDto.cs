using Volo.Abp.Application.Dtos;

namespace PlastikMarketim.Dtos.Products
{
    public class GetCategoryListRequestDto : PagedAndSortedResultRequestDto
    {
        public string NameFilter { get; set; }
    }
}