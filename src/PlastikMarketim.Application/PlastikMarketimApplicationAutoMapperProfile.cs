using AutoMapper;
using PlastikMarketim.Dtos.Categories;
using PlastikMarketim.Dtos.Categories.ViewModels;
using PlastikMarketim.Dtos.ContactForms.ViewModels;
using PlastikMarketim.Dtos.Files;
using PlastikMarketim.Dtos.Products.ViewModels;
using PlastikMarketim.Entities.Categories;
using PlastikMarketim.Entities.ContactForms;
using PlastikMarketim.Entities.Files;
using PlastikMarketim.Entities.Products;

namespace PlastikMarketim
{
    public class PlastikMarketimApplicationAutoMapperProfile : Profile
    {
        public PlastikMarketimApplicationAutoMapperProfile()
        {
            #region Product
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductViewModel>();
            #endregion

            #region Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryLookupDto>();
            CreateMap<Category, CategoryViewModel>();
            #endregion

            #region ContactForm
            CreateMap<ContactForm, ContactFormDto>().ReverseMap();
            CreateMap<ContactForm, ContactFormViewModel>();
            #endregion

            #region File
            CreateMap<File, FileDto>().ReverseMap();
            #endregion
        }
    }
}
