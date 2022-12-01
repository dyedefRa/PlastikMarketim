using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlastikMarketim.Abstracts;
using PlastikMarketim.Entities.Categories;
using PlastikMarketim.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace PlastikMarketim.Web.Pages.Admin.Category
{
    public class CreateModel : PlastikMarketimAdminPageModel
    {
        [BindProperty]
        public CreateCategoryViewModel Category { get; set; }

        private readonly ICategoryAppService _categoryAppService;
        private readonly IFileAppService _fileAppService;

        public CreateModel(
            ICategoryAppService categoryAppService,
            IFileAppService fileAppService
            )
        {
            _categoryAppService = categoryAppService;
            _fileAppService = fileAppService;
        }

        public void OnGet()
        {
            Category = new CreateCategoryViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateCategoryViewModel, CategoryDto>(Category);

            if (Category.ImageFile != null)
            {
                var fileResult = await _fileAppService.SaveFileAsync(Category.ImageFile, UploadType.Category);
                if (!fileResult.Success)
                {
                    //TODO:Hata döndürülecek
                }
                dto.ImageId = fileResult.Data.Id;
            }

            await _categoryAppService.CreateAsync(dto);

            return NoContent();
        }

        public class CreateCategoryViewModel
        {
            [Required]
            [StringLength(128)]
            [DisplayName("CategoryName")]
            public string Name { get; set; }
            public IFormFile ImageFile { get; set; }
            public Nullable<int> ImageId { get; set; }
            [Required]
            [TextArea(Rows = 2)]
            public string Description { get; set; }
            [Required]
            [DataType(DataType.Date)]
            [HiddenInput]
            public DateTime InsertedDate { get; set; } = DateTime.Now;
            [HiddenInput]
            public Status Status { get; set; } = Status.Active;
        }
    }
}
