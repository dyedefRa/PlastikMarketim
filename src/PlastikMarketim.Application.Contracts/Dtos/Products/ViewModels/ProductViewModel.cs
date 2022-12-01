using PlastikMarketim.Enums;
using System;

namespace PlastikMarketim.Dtos.Products.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Material { get; set; }
        public decimal Weight { get; set; }
        public string Dimension { get; set; }
        public string Description { get; set; }
        public Nullable<int> KoliUnit { get; set; }
        public Nullable<decimal> KoliPrice { get; set; }
        public Nullable<int> PackageUnit { get; set; }
        public Nullable<decimal> PackagePrice { get; set; }
        public Nullable<int> Unit { get; set; }
        public Nullable<decimal> Price { get; set; }
        public DateTime InsertedDate { get; set; }
        public Status Status { get; set; }

        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public string DetailImageUrl { get; set; }
    }
}
