using MyWebServer.Controllers;
using MyWebServer.Http;

namespace SharedTrip.App.Controllers
{


    public class HomeController : Controller
    { 
        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }


    }
}