using PlastikMarketim.Enums;
using System;

namespace PlastikMarketim.Dtos.Products.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public int Unit { get; set; }
        public decimal Price { get; set; }
        public string FileUrl { get; set; }
        public string CategoryName { get; set; }
        public DateTime InsertedDate { get; set; }
        public Status Status { get; set; }
    }
}
