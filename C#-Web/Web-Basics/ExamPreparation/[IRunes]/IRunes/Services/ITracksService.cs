using IRunes.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services
{
    public interface ITracksService
    {
        string Create(string name, string link, decimal price);

        public void AddTrackToAlbum(string albumId, string trackId);

        TrackDetailsViewModel GetDetails(string albumId, string trackId);
    }
}
