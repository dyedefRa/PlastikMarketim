using AutoMapper;
using PlastikMarketim.Entities.Categories;
using PlastikMarketim.Entities.Products;

namespace PlastikMarketim.Web
{
    public class PlastikMarketimWebAutoMapperProfile : Profile
    {
        public PlastikMarketimWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.

            #region Product
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Pages.Admin.Product.CreateModel.CreateProductViewModel, ProductDto>();
            CreateMap<Pages.Admin.Product.EditModel.EditProductViewModel, ProductDto>().ReverseMap();
            #endregion


            #region Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Pages.Admin.Category.CreateModel.CreateCategoryViewModel, CategoryDto>();
            CreateMap<Pages.Admin.Category.EditModel.EditCategoryViewModel, CategoryDto>().ReverseMap();
            #endregion
        }
    }
}
