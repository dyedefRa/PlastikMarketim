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
    public class EditModel : PlastikMarketimAdminPageModel
    {
        [BindProperty]
        public EditCategoryViewModel Category { get; set; }

        private readonly ICategoryAppService _categoryAppService;
        private readonly IFileAppService _fileAppService;

        public EditModel(
             ICategoryAppService categoryAppService,
            IFileAppService fileAppService
            )
        {
            _categoryAppService = categoryAppService;
            _fileAppService = fileAppService;
        }

        public async Task OnGetAsync(int id)
        {
            var categoryDto = await _categoryAppService.GetAsync(id);
            Category = ObjectMapper.Map<CategoryDto, EditCategoryViewModel>(categoryDto);
            Category.ImageUrl = _fileAppService.GetAsync(Category.ImageId).Result.FilePath;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EditCategoryViewModel, CategoryDto>(Category);

            if (Category.ImageFile != null)
            {
                var fileResult = await _fileAppService.SaveFileAsync(Category.ImageFile, UploadType.Category);
                if (!fileResult.Success)
                {
                    //TODO:Hata döndürülecek
                }
                dto.ImageId = fileResult.Data.Id;
            }

            await _categoryAppService.UpdateAsync(dto.Id, dto);

            return NoContent();
        }

        public class EditCategoryViewModel
        {
            [HiddenInput]
            public int Id { get; set; }
            [Required]
            [StringLength(128)]
            [DisplayName("CategoryName")]
            public string Name { get; set; }
            [Required]
            public IFormFile ImageFile { get; set; }
            public int ImageId { get; set; }
            public string ImageUrl { get; set; }
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
