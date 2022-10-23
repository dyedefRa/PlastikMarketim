using PlastikMarketim.Enums;
using System;
using Volo.Abp.Application.Dtos;

namespace PlastikMarketim.Entities.ContactForms
{
    public class ContactFormDto : EntityDto<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;
    }
}
