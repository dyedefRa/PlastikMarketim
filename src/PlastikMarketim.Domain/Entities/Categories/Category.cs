using PlastikMarketim.Entities.Files;
using PlastikMarketim.Entities.Products;
using PlastikMarketim.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace PlastikMarketim.Entities.Categories
{
    [Table(PlastikMarketimConsts.DbTablePrefix + "Categories")]
    public class Category : Entity<int>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> ImageId { get; set; }
        [ForeignKey("ImageId")]
        public virtual File Image { get; set; }
        public DateTime InsertedDate { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
