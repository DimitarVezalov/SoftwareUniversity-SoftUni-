using IRunes.Data;
using IRunes.Data.Models;
using IRunes.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services
{
    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext db;

        public TracksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Create(string name, string link, decimal price)
        {
            var track = new Track 
            {
                Name = name,
                Link = link,
                Price = price
            };

            this.db.Tracks.Add(track);
            this.db.SaveChanges();

            return track.Id;
        }

        public void AddTrackToAlbum(string albumId, string trackId)
        {
            var album = this.db.Albums.Find(albumId);
            var track = this.db.Tracks.Find(trackId);

            album.Tracks.Add(track);

            this.db.Update(album);
            this.db.SaveChanges();
        }

        public TrackDetailsViewModel GetDetails(string albumId, string trackId)
        {
            var track = this.db.Tracks.Find(trackId);

            var trackModel = new TrackDetailsViewModel
            {
                AlbumId = albumId,
                Name = track.Name,
                Price = track.Price.ToString("F2"),
                Link = track.Link
            };

            return trackModel;
        }
    }
}
