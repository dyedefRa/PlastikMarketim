using PlastikMarketim.Enums;
using System;

namespace PlastikMarketim.Dtos.Categories.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InsertedDate { get; set; }
        public Status Status { get; set; }

        public string ImageUrl { get; set; }
    }
}
