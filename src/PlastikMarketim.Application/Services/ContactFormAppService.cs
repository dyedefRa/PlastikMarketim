using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PlastikMarketim.Abstracts;
using PlastikMarketim.Dtos.ContactForms;
using PlastikMarketim.Dtos.ContactForms.ViewModels;
using PlastikMarketim.Entities.ContactForms;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace PlastikMarketim.Services
{
    [Authorize]
    public class ContactFormAppService : CrudAppService<ContactForm, ContactFormDto, int, PagedAndSortedResultRequestDto, ContactFormDto, ContactFormDto>, IContactFormAppService
    {
        public ContactFormAppService(IRepository<ContactForm, int> repository) : base(repository)
        {
        }

        public async Task<PagedResultDto<ContactFormViewModel>> GetProductListAsync(GetContactFormListRequestDto input)
        {
            var result = new PagedResultDto<ContactFormViewModel>();

            var query = Repository.AsQueryable();

            if (!string.IsNullOrEmpty(input.FullNameFilter))
                query = query.Where(x => x.FullName.Contains(input.FullNameFilter));
            if (!string.IsNullOrEmpty(input.EmailFilter))
                query = query.Where(x => x.Email.Contains(input.EmailFilter));

            var totalCount = await query.CountAsync();
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await query.ToListAsync();

            var models = entities.Select(x =>
            {
                var viewModel = ObjectMapper.Map<ContactForm, ContactFormViewModel>(x);
                return viewModel;
            }).ToList();

            result.Items = models;
            result.TotalCount = totalCount;

            return result;
        }
    }
}
