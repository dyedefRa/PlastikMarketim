using PlastikMarketim.Enums;
using System;

namespace PlastikMarketim.Dtos.ContactForms.ViewModels
{
    public class ContactFormViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;
    }
}
