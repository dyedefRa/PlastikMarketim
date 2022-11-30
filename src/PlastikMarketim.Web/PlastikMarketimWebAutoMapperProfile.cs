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

            //CreateMap<GameDto, Pages.Game.EditModel.EditGameViewModel>();
            //CreateMap<Pages.Game.EditModel.EditGameViewModel, CreateOrUpdateGameDto>();
            #endregion


            #region Category
            CreateMap<Pages.Admin.Category.CreateModel.CreateCategoryViewModel, CategoryDto>();
            //CreateMap<GameDto, Pages.Game.EditModel.EditGameViewModel>();
            //CreateMap<Pages.Game.EditModel.EditGameViewModel, CreateOrUpdateGameDto>();
            #endregion
        }
    }
}
