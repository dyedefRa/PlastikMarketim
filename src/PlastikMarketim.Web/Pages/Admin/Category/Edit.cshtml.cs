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

        public EditModel(
             ICategoryAppService categoryAppService
            )
        {
            _categoryAppService = categoryAppService;
        }

        public async Task OnGetAsync(int id)
        {
            var categoryDto = await _categoryAppService.GetAsync(id);
            Category = ObjectMapper.Map<CategoryDto, EditCategoryViewModel>(categoryDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<EditCategoryViewModel, CategoryDto>(Category);

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
