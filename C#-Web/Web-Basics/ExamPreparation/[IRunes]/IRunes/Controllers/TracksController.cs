using IRunes.Services;
using IRunes.ViewModels.Tracks;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService trackService;
        private readonly IValidator validator;

        public TracksController(ITracksService trackService, IValidator validator)
        {
            this.trackService = trackService;
            this.validator = validator;
        }


        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View(albumId);
        }

        [HttpPost]
        public HttpResponse Create(CreateTrackInputModel input)
        {
            if (!this.validator.ValidateTrackCreate(input))
            {
                return this.Redirect($"/Tracks/Create?albumId={input.AlbumId}");
            }

            var trackId = this.trackService.Create(input.Name, input.Link, input.Price);

            this.trackService.AddTrackToAlbum(input.AlbumId, trackId);

            return this.Redirect($"/Albums/Details?id={input.AlbumId}");
        }

        public HttpResponse Details(string albumId, string trackId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var track = this.trackService.GetDetails(albumId, trackId);

            return this.View(track);
        }
    }
}
