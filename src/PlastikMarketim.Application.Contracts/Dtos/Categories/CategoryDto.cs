using PlastikMarketim.Dtos.Files;
using PlastikMarketim.Entities.Products;
using PlastikMarketim.Enums;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace PlastikMarketim.Entities.Categories
{
    public class CategoryDto : EntityDto<int>
    {
        public CategoryDto()
        {
            Products = new List<ProductDto>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> ImageId { get; set; }
        public FileDto Image { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;
        public List<ProductDto> Products { get; set; }
    }
}
