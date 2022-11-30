using Microsoft.AspNetCore.Mvc;
using PlastikMarketim.Abstracts;
using PlastikMarketim.Entities.Categories;
using PlastikMarketim.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PlastikMarketim.Web.Pages.Admin.Category
{
    public class CreateModel : PlastikMarketimAdminPageModel
    {
        [BindProperty]
        public CreateCategoryViewModel Category { get; set; }

        private readonly ICategoryAppService _categoryAppService;

        public CreateModel(
            ICategoryAppService categoryAppService
            )
        {
            _categoryAppService = categoryAppService;
        }

        public void OnGet()
        {
            Category = new CreateCategoryViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateCategoryViewModel, CategoryDto>(Category);

            await _categoryAppService.CreateAsync(dto);

            return NoContent();
        }

        public class CreateCategoryViewModel
        {
            [Required]
            [StringLength(128)]
            [DisplayName("CategoryName")]
            public string Name { get; set; }
            [Required]
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
