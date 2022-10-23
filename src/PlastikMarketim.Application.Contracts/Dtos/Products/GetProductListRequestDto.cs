using Volo.Abp.Application.Dtos;

namespace PlastikMarketim.Dtos.Products
{
    public class GetProductListRequestDto : PagedAndSortedResultRequestDto
    {
        public string NameFilter { get; set; }
    }
}