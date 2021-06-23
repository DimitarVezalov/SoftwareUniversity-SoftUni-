using IRunes.ViewModels.Albums;
using IRunes.ViewModels.Tracks;
using IRunes.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services
{
    public interface IValidator
    {
        bool ValidateUserRegister(UserRegisterInputModel model);

        bool ValidateAlbumCreate(CreateAlbumInputModel model);

        bool ValidateTrackCreate(CreateTrackInputModel model);
    }
}
