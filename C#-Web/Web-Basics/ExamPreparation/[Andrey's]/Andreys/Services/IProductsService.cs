using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services
{
    public interface IProductsService
    {
        void Create(AddProductInputModel model);

        ICollection<ProductViewModel> GetAllProducts();

        ProductDetailsViewModel GetProductDetails(int id);

        void Delete(int id);
    }
}
