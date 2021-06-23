using IRunes.Services;
using IRunes.ViewModels.Albums;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;
        private readonly IValidator validator;

        public AlbumsController(IAlbumsService albumsService, IValidator validator)
        {
            this.albumsService = albumsService;
            this.validator = validator;
        }


        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var albumsModel = this.albumsService.GetAll();

            return this.View(albumsModel);
        }


        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateAlbumInputModel input)
        {
            if (!this.validator.ValidateAlbumCreate(input))
            {
                return this.Redirect("/Albums/Create");
            }

            this.albumsService.Create(input.Name, input.Cover);

            return this.Redirect("/Albums/All");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var album = this.albumsService.GetDetails(id);

            return this.View(album);
        }
    }
}
