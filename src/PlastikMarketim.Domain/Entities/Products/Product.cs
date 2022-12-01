using PlastikMarketim.Entities.Categories;
using PlastikMarketim.Entities.Files;
using PlastikMarketim.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace PlastikMarketim.Entities.Products
{
    [Table(PlastikMarketimConsts.DbTablePrefix + "Products")]
    public class Product : Entity<int>
    {
        [Required]
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

        public int ImageId { get; set; }
        public virtual File Image { get; set; }
        public Nullable<int> DetailImageId { get; set; }
        public virtual File DetailImage { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
