using IRunes.Data;
using IRunes.Data.Models;
using IRunes.ViewModels.Albums;
using IRunes.ViewModels.Tracks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext db;

        public AlbumsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string cover)
        {
            var album = new Album
            { 
                Cover = cover,
                Name = name,
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();

        }

        public AllAlbumsViewModel GetAll()
        {
            var albumsModel = new AllAlbumsViewModel
            {
                Albums = this.db.Albums
                .Select(a => new AlbumListViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToList()
            };

            return albumsModel;
        }

        public AlbumDetailsViewModel GetDetails(string albumId)
        {
            var album = this.db.Albums
                .Include(a => a.Tracks)
                .FirstOrDefault(a => a.Id == albumId);

            var albumModel = new AlbumDetailsViewModel
            {
                Id = album.Id,
                Name = album.Name,
                Cover = album.Cover,
                Price = album.Price.ToString("F2"),
                Tracks = album.Tracks.Select(t => new TracksInAlbumViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList()
            };

            return albumModel;
        }
    }
}
