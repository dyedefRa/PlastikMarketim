using PlastikMarketim.Entities.Categories;
using PlastikMarketim.Entities.Products;
using PlastikMarketim.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace PlastikMarketim.Entities.Files
{
    [Table(PlastikMarketimConsts.DbTablePrefix + "Files")]
    public class File : Entity<int>
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public long? FileSize { get; set; }
        public string FilePath { get; set; }
        public string FullPath { get; set; }
        public string Title { get; set; }
        public string ContentType { get; set; }
        public Status Status { get; set; }

        [NotMapped]
        public virtual ICollection<Category> CategoryImage { get; set; }
        [NotMapped]
        public virtual ICollection<Product> ProductImage { get; set; }
        [NotMapped]
        public virtual ICollection<Product> ProductDetailImage { get; set; }
    }
}
