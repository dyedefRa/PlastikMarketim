using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlastikMarketim.Abstracts;
using PlastikMarketim.Entities.Products;
using PlastikMarketim.Enums;
using PlastikMarketim.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace PlastikMarketim.Web.Pages.Admin.Product
{
    public class EditModel : PlastikMarketimAdminPageModel
    {
        [BindProperty]
        public EditProductViewModel Product { get; set; }
        public List<SelectListItem> Categories { get; set; }

        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IFileAppService _fileAppService;

        public EditModel(
            IProductAppService productAppService,
            ICategoryAppService categoryAppService,
            IFileAppService fileAppService
            )
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
            _fileAppService = fileAppService;
        }

        public async Task OnGetAsync(int id)
        {
            var productDto = await _productAppService.GetAsync(id);
            Product = ObjectMapper.Map<ProductDto, EditProductViewModel>(productDto);
            Product.ImageUrl = _fileAppService.GetAsync(Product.ImageId).Result.FilePath;
            if (Product.DetailImageId.HasValue)
                Product.DetailImageUrl = _fileAppService.GetAsync(Product.DetailImageId.Value).Result.FilePath;


            var categoryLookUpDtos = await _categoryAppService.GetLookupAsync();
            Categories = categoryLookUpDtos.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EditProductViewModel, ProductDto>(Product);

            if (Product.ImageFile != null)
            {
                var fileResult = await _fileAppService.SaveFileAsync(Product.ImageFile, UploadType.Product);
                if (!fileResult.Success)
                {
                    //TODO:Hata döndürülecek
                }
                dto.ImageId = fileResult.Data.Id;
            }
            if (Product.DetailImageFile != null)
            {
                var fileResult = await _fileAppService.SaveFileAsync(Product.DetailImageFile, UploadType.Product);
                if (!fileResult.Success)
                {
                    //TODO:Hata döndürülecek
                }
                dto.DetailImageId = fileResult.Data.Id;
            }

            await _productAppService.UpdateAsync(dto.Id, dto);

            return NoContent();
        }

        public class EditProductViewModel
        {
            [HiddenInput]
            public int Id { get; set; }
            [Required]
            [StringLength(128)]
            //[DisplayName("ProductName")]
            public string Name { get; set; }
            public string Brand { get; set; }
            public string Material { get; set; }
            public decimal Weight { get; set; }
            public string Dimension { get; set; }
            [TextArea(Rows = 2)]
            public string Description { get; set; }
            public Nullable<int> KoliUnit { get; set; }
            public decimal KoliPrice { get; set; }
            public Nullable<int> PackageUnit { get; set; }
            public decimal PackagePrice { get; set; }
            public Nullable<int> Unit { get; set; }
            public decimal Price { get; set; }
            [Required]
            //[DisplayName("Image")]
            public IFormFile ImageFile { get; set; }
            public int ImageId { get; set; }
            public string ImageUrl { get; set; }
            public IFormFile DetailImageFile { get; set; }
            public Nullable<int> DetailImageId { get; set; }
            public string DetailImageUrl { get; set; }
            [Required]
            [SelectItems(nameof(Categories))]
            //[DisplayName("Category")]
            public int CategoryId { get; set; }
            [Required]
            [DataType(DataType.Date)]
            [HiddenInput]
            public DateTime InsertedDate { get; set; } = DateTime.Now;
            [HiddenInput]
            public Status Status { get; set; } = Status.Active;
        }
    }
}
