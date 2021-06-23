using IRunes.Data;
using IRunes.ViewModels.Albums;
using IRunes.ViewModels.Tracks;
using IRunes.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services
{
    using static DataConstants;

    public class Validator : IValidator
    {
        public bool ValidateUserRegister(UserRegisterInputModel model)
        {
            if (String.IsNullOrEmpty(model.Username) ||
                model.Username.Length < MinUsernameLength ||
                model.Username.Length > MaxUsernameLength)
            {
                return false;
            }

            if (String.IsNullOrEmpty(model.Email))
            {
                return false;
            }

            if (String.IsNullOrEmpty(model.Password) ||
                model.Password.Length < MinPasswordLength ||
                model.Password.Length > MaxPasswordLength)
            {
                return false;
            }

            if (model.ConfirmPassword != model.Password)
            {
                return false;
            }

            return true;
        }

        public bool ValidateAlbumCreate(CreateAlbumInputModel model)
        {
            if (String.IsNullOrEmpty(model.Name) ||
                model.Name.Length < MinAlbumNameLength ||
                model.Name.Length > MaxAlbumNameLength)
            {
                return false;
            }

            if (String.IsNullOrEmpty(model.Cover))
            {
                return false;
            }

            return true;
        }

        public bool ValidateTrackCreate(CreateTrackInputModel model)
        {
            if (String.IsNullOrEmpty(model.Name) ||
                model.Name.Length < MinTrackNameLength ||
                model.Name.Length > MaxTrackNameLength)
            {
                return false;
            }

            if (String.IsNullOrEmpty(model.Link))
            {
                return false;
            }

            return true;
        }
    }
}
