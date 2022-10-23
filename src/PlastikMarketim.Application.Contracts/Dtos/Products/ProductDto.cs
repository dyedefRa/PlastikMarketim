using PlastikMarketim.Entities.Categories;
using PlastikMarketim.Enums;
using System;
using Volo.Abp.Application.Dtos;

namespace PlastikMarketim.Entities.Products
{
    public class ProductDto : EntityDto<int>
    {
        public string Name { get; set; }
        public int Unit { get; set; }
        public decimal Price { get; set; }
        public string FileUrl { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Categories { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;
    }
}
