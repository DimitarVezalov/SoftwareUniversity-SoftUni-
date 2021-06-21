using Andreys.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Andreys.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Index()
        {
            var products = this.productsService.GetAllProducts();

            return this.View(products);
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }
    }
}
