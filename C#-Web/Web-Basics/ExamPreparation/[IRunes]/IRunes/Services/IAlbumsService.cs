using IRunes.ViewModels.Albums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services
{
    public interface IAlbumsService
    {
        AllAlbumsViewModel GetAll();

        void Create(string name, string cover);

        AlbumDetailsViewModel GetDetails(string albumId);
    }
}
