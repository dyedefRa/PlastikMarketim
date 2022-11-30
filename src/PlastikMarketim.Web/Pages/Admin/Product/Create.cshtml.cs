using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlastikMarketim.Abstracts;
using PlastikMarketim.Entities.Products;
using PlastikMarketim.Enums;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace PlastikMarketim.Web.Pages.Admin.Product
{
    public class CreateModel : PlastikMarketimAdminPageModel
    {
        [BindProperty]
        public CreateProductViewModel Product { get; set; }
        public List<SelectListItem> Categories { get; set; }

        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IFileAppService _fileAppService;

        public CreateModel(
            IProductAppService productAppService,
            ICategoryAppService categoryAppService,
            IFileAppService fileAppService
            )
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
            _fileAppService = fileAppService;
        }

        public async Task OnGet()
        {
            Product = new CreateProductViewModel();

            var categoryLookUpDtos = await _categoryAppService.GetLookupAsync();
            Categories = categoryLookUpDtos.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateProductViewModel, ProductDto>(Product);

            if (Product.File != null)
            {
                var fileResult = await _fileAppService.SaveFileAsync(Product.File, UploadType.Product);
                if (!fileResult.Success)
                {
                    //TODO:Hata döndürülecek
                }
                dto.FileUrl = fileResult.Message;
            }
            await _productAppService.CreateAsync(dto);

            return NoContent();
        }

        public class CreateProductViewModel
        {
            [Required]
            [StringLength(128)]
            [DisplayName("ProductName")]
            public string Name { get; set; }
            [Required]
            public int Unit { get; set; }
            [Required]
            [DisplayName("Price")]
            public decimal Price { get; set; }

            [Required]
            [DisplayName("Image")]
            public IFormFile File { get; set; }
            public string FileUrl { get; set; }
            [Required]
            [SelectItems(nameof(Categories))]
            [DisplayName("Category")]
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
