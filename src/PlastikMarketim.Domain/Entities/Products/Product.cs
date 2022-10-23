using PlastikMarketim.Entities.Categories;
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
        public int Unit { get; set; }
        public decimal Price { get; set; }
        [Required]
        public string FileUrl { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [Required]
        public virtual Category Category { get; set; }
        public DateTime InsertedDate { get; set; }
        public Status Status { get; set; }
    }
}
