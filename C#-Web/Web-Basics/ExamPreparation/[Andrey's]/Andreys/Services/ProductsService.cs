using Andreys.Data;
using Andreys.Data.Models;
using Andreys.Data.Models.Enums;
using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void Create(AddProductInputModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Category = Enum.Parse<Category>(model.Category),
                Gender = Enum.Parse<Gender>(model.Gender)
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = this.db.Products
                .FirstOrDefault(p => p.Id == id);

            this.db.Remove(product);
            this.db.SaveChanges();
        }

        public ICollection<ProductViewModel> GetAllProducts()
        {
            var products = this.db.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .ToList();

            return products;
        }

        public ProductDetailsViewModel GetProductDetails(int id)
        {
            var product = this.db.Products.Find(id);

            var model = new ProductDetailsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Category = product.Category.ToString(),
                Gender = product.Gender.ToString(),
                Price = product.Price
            };

            return model;
        }
    }
}
