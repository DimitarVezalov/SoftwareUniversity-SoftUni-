using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using ProductShop.Dtos.Export;
using System.Text;

namespace ProductShop
{
    public class StartUp
    {
        private const string ExportDirectoryPath = "../../../Datasets/Export";

        public static void Main(string[] args)
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<ProductShopProfile>();
            });


            using (var context = new ProductShopContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //string usersString = File.ReadAllText("../../../Datasets/users.xml");
                //Console.WriteLine(ImportUsers(context, usersString));

                //string productsString = File.ReadAllText("../../../Datasets/products.xml");
                //Console.WriteLine(ImportProducts(context, productsString));

                //string categoriesString = File.ReadAllText("../../../Datasets/categories.xml");
                //Console.WriteLine(ImportCategories(context, categoriesString));

                //string catProString = File.ReadAllText("../../../Datasets/categories-products.xml");
                //Console.WriteLine(ImportCategoryProducts(context, catProString));

                EnsureExportDirectoryExists();

                //string exportProducts = GetProductsInRange(context);
                //File.WriteAllText(ExportDirectoryPath + "/products-in-range.xml", exportProducts);

                //string exportUsersWithProducts = GetSoldProducts(context);
                //File.WriteAllText(ExportDirectoryPath + "/users-sold-products.xml", exportUsersWithProducts);

                //string exportCategories = GetCategoriesByProductsCount(context);
                //File.WriteAllText(ExportDirectoryPath + "/categories-by-products.xml", exportCategories);

                string exportUsers = GetUsersWithProducts(context);
                File.WriteAllText(ExportDirectoryPath + "/users-and-products.xml", exportUsers);
            }


        }

        private static void EnsureExportDirectoryExists()
        {
            if (!Directory.Exists(ExportDirectoryPath))
            {
                Directory.CreateDirectory(ExportDirectoryPath);
            }
        }

        //Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(UserImportDto[]),
                                                    new XmlRootAttribute("Users"));

            UserImportDto[] userDtos;

            using (var reader = new StringReader(inputXml))
            {
                userDtos = (UserImportDto[])xmlSerializer.Deserialize(reader);
            }

            var users = Mapper.Map<User[]>(userDtos);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ProductImportDto[]),
                                                    new XmlRootAttribute("Products"));

            ProductImportDto[] productDtos;

            using (var reader = new StringReader(inputXml))
            {
                productDtos = (ProductImportDto[])xmlSerializer.Deserialize(reader);
            }

            List<Product> products = new List<Product>();

            foreach (var dto in productDtos)
            {
                Product product = new Product();
                product.Name = dto.Name;
                product.Price = dto.Price;
                product.SellerId = dto.SellerId;
                product.BuyerId = dto.BuyerId;

                products.Add(product);
            }


            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryImportDto[]),
                                                    new XmlRootAttribute("Categories"));

            CategoryImportDto[] categoryDtos;

            using (var reader = new StringReader(inputXml))
            {
                categoryDtos = (CategoryImportDto[])xmlSerializer.Deserialize(reader);
            }

            List<Category> categories = new List<Category>();

            foreach (var dto in categoryDtos.Where(x => x.Name != null))
            {
                Category category = new Category();
                category.Name = dto.Name;
                
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryProductImportDto[]),
                                                    new XmlRootAttribute("CategoryProducts"));

            CategoryProductImportDto[] categoryProductsDtos;

            using (var reader = new StringReader(inputXml))
            {
                categoryProductsDtos = (CategoryProductImportDto[])xmlSerializer.Deserialize(reader);
            }

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            var categoriesIds = context.Categories.Select(c => c.Id).ToList();
            var productsIds = context.Products.Select(p => p.Id).ToList();

            foreach (var dto in categoryProductsDtos
                .Where(x => categoriesIds.Contains(x.CategoryId)
                        && productsIds.Contains(x.ProductId)))
            {
                CategoryProduct cp = new CategoryProduct();
                cp.CategoryId = dto.CategoryId;
                cp.ProductId = dto.ProductId;
                categoryProducts.Add(cp);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Export Products In Range
        public static string GetProductsInRange(ProductShopContext context) 
        {
            StringBuilder sb = new StringBuilder();

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductExportDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            XmlSerializer serializer = 
                new XmlSerializer(typeof(ProductExportDto[]), new XmlRootAttribute("Products"));


            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
               serializer.Serialize(writer, products, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var usersWithProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new UserWithSoldProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Select(p => new UserSoldProductsExportDto 
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()          
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(UserWithSoldProductsDto[]),
                new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, usersWithProducts, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(c => new CategoriesByProductsCountExportDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Select(cp => cp.Product.Price).Average(),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(CategoriesByProductsCountExportDto[]),
                new XmlRootAttribute("Categories"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("","");

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, categories, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var allUsers = new UsersAllDto
            {
                Count = context.Users.Where(x => x.ProductsSold.Any(p => p.Buyer != null)).Count(),
                Users = context.Users
                .ToList()
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new UserExportDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsExportDto
                    {
                        Count = u.ProductsSold.Where(ps => ps.Buyer != null).Count(),
                        Products = u.ProductsSold.Where(ps => ps.Buyer != null)
                        .Select(p => new UserSoldProductsExportDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(x => x.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .Take(10)
                .ToArray()
            };

            XmlSerializer serializer = 
                        new XmlSerializer(typeof(UsersAllDto), new XmlRootAttribute("Users"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("","");

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, allUsers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}