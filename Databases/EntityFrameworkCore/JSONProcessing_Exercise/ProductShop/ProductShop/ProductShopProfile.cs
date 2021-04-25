using AutoMapper;
using ProductShop.DTO.Categories;
using ProductShop.DTO.Products;
using ProductShop.DTO.Users;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Products
            this.CreateMap<Product, ProductsInRangeDto>()
                .ForMember(x => x.SellerName, y => y.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            this.CreateMap<Product, ProductDto>();

            this.CreateMap<User, SoldProductsDto>()
                .ForMember(x => x.Products, y => y.MapFrom(s => s.ProductsSold.Where(p => p.Buyer != null)));

            //Users
            this.CreateMap<Product, ProductsWithBuyerDto>()
                .ForMember(x => x.BuyerFirstName, y => y.MapFrom(s => s.Buyer.FirstName))
                .ForMember(x => x.BuyerLastName, y => y.MapFrom(s => s.Buyer.LastName));

            this.CreateMap<User, UsersWithSoldProductsDto>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(s => s.ProductsSold.Where(p => p.Buyer != null)));

            this.CreateMap<Category, CategoriesByCountDto>()
                .ForMember(x => x.ProductsCount, y => y.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice, y => y.MapFrom(s => s.CategoryProducts
                                                .Select(cp => cp.Product.Price).Average().ToString("F2")))
                .ForMember(x => x.TotalRevenue, y => y.MapFrom(s => s.CategoryProducts
                                                .Select(cp => cp.Product.Price).Sum().ToString("F2")));

            this.CreateMap<User, UsersWithProductsCountDto>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(s => s.ProductsSold.Where(p => p.Buyer != null)));

        }
    }
}
