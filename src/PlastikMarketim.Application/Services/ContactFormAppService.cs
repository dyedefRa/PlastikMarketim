using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PlastikMarketim.Abstracts;
using PlastikMarketim.Dtos.ContactForms;
using PlastikMarketim.Dtos.ContactForms.ViewModels;
using PlastikMarketim.Entities.ContactForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace PlastikMarketim.Services
{
    [Authorize]
    public class ContactFormAppService : CrudAppService<ContactForm, ContactFormDto, int, PagedAndSortedResultRequestDto, ContactFormDto, ContactFormDto>
  , IContactFormAppService
    {
        public ContactFormAppService(
                       IRepository<ContactForm, int> repository
            ) : base(repository)
        {
        }

        public async Task<PagedResultDto<ContactFormViewModel>> GetProductListAsync(GetContactFormListRequestDto input)
        {
            var result = new PagedResultDto<ContactFormViewModel>();

            var query = Repository.AsQueryable();

            //FILTER
            if (!string.IsNullOrEmpty(input.FullNameFilter))
                query = query.Where(x => x.FullName.Contains(input.FullNameFilter));
            if (!string.IsNullOrEmpty(input.EmailFilter))
                query = query.Where(x => x.Email.Contains(input.EmailFilter));

            var totalCount = await query.CountAsync();
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var contactFormDtos = await query.ToListAsync();

            var data = contactFormDtos.Select(x =>
            {
                var contactFormViewModel = ObjectMapper.Map<ContactForm, ContactFormViewModel>(x);
                return contactFormViewModel;
            }).ToList();

            result.Items = data;
            result.TotalCount = totalCount;

            return result;
        }
    }
}
