using AutoMapper;
using PlastikMarketim.Dtos.Categories;
using PlastikMarketim.Dtos.Categories.ViewModels;
using PlastikMarketim.Dtos.Products.ViewModels;
using PlastikMarketim.Entities.Categories;
using PlastikMarketim.Entities.Products;

namespace PlastikMarketim
{
    public class PlastikMarketimApplicationAutoMapperProfile : Profile
    {
        public PlastikMarketimApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            #region Product
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductViewModel>();
            //CreateMap<Team, CreateOrUpdateTeamDto>().ReverseMap();
            #endregion

            #region Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryLookupDto>();
            CreateMap<Category, CategoryViewModel>();
            //CreateMap<Team, CreateOrUpdateTeamDto>().ReverseMap();
            #endregion
        }
    }
}
