using CarShop.Data;
using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarShop.Services
{
    using static DataConstants;

    public class Validator : IValidator
    {
        public string ValidateUserRegistrationModel(RegisterInputModel model)
        {
            var sb = new StringBuilder();

            if (String.IsNullOrEmpty(model.Username) ||
                model.Username.Length < UsernameMinLength ||
                model.Username.Length > UsernameMaxLength)
            {
                sb.AppendLine($"Username should be between {UsernameMinLength} and {UsernameMaxLength} characters!");
            }

            if (String.IsNullOrEmpty(model.Email))
            {
                sb.AppendLine("Email is required!");
            }

            if (String.IsNullOrEmpty(model.Password) ||
              model.Username.Length < PasswordMinLength ||
              model.Username.Length > PasswordMaxLength)
            {
                sb.AppendLine($"Password should be between {UsernameMinLength} and {UsernameMaxLength} characters!");
            }

            if (model.Password != model.ConfirmPassword)
            {
                sb.AppendLine("Passwords do not match!");
            }

            return sb.ToString().TrimEnd();
        }

        public string ValidateCarInputModel(AddCarInputModel model)
        {
            var sb = new StringBuilder();

            if (String.IsNullOrEmpty(model.Model) ||
                model.Model.Length < ModelMinLength ||
                model.Model.Length > ModelMaxLength)
            {
                sb.AppendLine($"Username should be between {ModelMinLength} and {ModelMaxLength} characters!");
            }

            if (String.IsNullOrEmpty(model.Image))
            {
                sb.AppendLine("Image is required!");
            }

            if (!Regex.IsMatch(model.PlateNumber, PlateRegex))
            {
                sb.AppendLine($"{model.PlateNumber} is not a valid plate number!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
