using Andreys.Data;
using Andreys.ViewModels.Products;
using Andreys.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services
{
    using static DataConstants;
    using static ExceptionMessages;

    public class Validator : IValidator
    {
        public bool ValidateAddProductInputModel(AddProductInputModel model)
        {
            if (String.IsNullOrEmpty(model.Name) ||
                model.Name.Length < MinProductNameLength ||
                model.Name.Length > MaxProductNameLength)
            {
                return false;
            }

            if (String.IsNullOrEmpty(model.Description) ||
                model.Description.Length > MaxDescriptionLength)
            {
                return false;
            }

            return true;
        }

        public bool ValidateRegisterInputModel(RegisterInputModel model)
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
    }
}
