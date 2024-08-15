using AutoMapper;
using StoreAPI.AppServices.Products;
using StoreAPI.Entities;

namespace StoreAPI.AppServices
{
    public class AppMapperProfile :Profile
    {

        public AppMapperProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(src => src.CategoryName, 
                des => des.MapFrom(s => s.Category.Name));

            CreateMap<CreateProductDto, Product>().ReverseMap();
        }
    }
}
