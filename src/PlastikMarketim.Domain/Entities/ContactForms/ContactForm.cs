using PlastikMarketim.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace PlastikMarketim.Entities.ContactForms
{
    [Table(PlastikMarketimConsts.DbTablePrefix + "ContactForms")]
    public class ContactForm : Entity<int>
    {
        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime InsertedDate { get; set; }
        public Status Status { get; set; }
    }
}
