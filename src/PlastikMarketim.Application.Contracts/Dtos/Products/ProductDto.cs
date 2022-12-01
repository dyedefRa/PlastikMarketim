using PlastikMarketim.Dtos.Files;
using PlastikMarketim.Entities.Categories;
using PlastikMarketim.Enums;
using System;
using Volo.Abp.Application.Dtos;

namespace PlastikMarketim.Entities.Products
{
    public class ProductDto : EntityDto<int>
    {
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
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;
        public int ImageId { get; set; }
        public FileDto Image { get; set; }
        public Nullable<int> DetailImageId { get; set; }
        public FileDto DetailImage { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Categories { get; set; }
    }
}
