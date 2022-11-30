using Volo.Abp.Application.Dtos;

namespace PlastikMarketim.Dtos.ContactForms
{
    public class GetContactFormListRequestDto : PagedAndSortedResultRequestDto
    {
        public string FullNameFilter { get; set; }
        public string EmailFilter { get; set; }
    }
}
