using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserImportDto, User>();

            this.CreateMap<ProductImportDto, Product>();

            this.CreateMap<CategoryImportDto, Category>();

            this.CreateMap<Product, ProductExportDto>()
                .ForMember(x => x.BuyerFullName,
                y => y.MapFrom(s => s.Buyer.FirstName + ' ' + s.Buyer.LastName));
        }
    }
}
