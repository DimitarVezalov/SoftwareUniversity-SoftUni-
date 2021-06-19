using Git.Data;
using Git.ViewModels.Repositories;
using Git.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Git.Services
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

        public string ValidateCreateRepositoryInputModel(CreateRepositoryInputModel model)
        {
            var sb = new StringBuilder();

            if (String.IsNullOrEmpty(model.Name) ||
                model.Name.Length < RepoNameMinLength ||
                model.Name.Length > RepoNameMaxLength)
            {
                sb.AppendLine($"Name should be between {RepoNameMinLength} and {RepoNameMaxLength} characters!");
            }
          
            return sb.ToString().TrimEnd();
        }

        public string ValidateCommitDescription(string description)
        {
            var sb = new StringBuilder();

            if (String.IsNullOrEmpty(description) || description.Length < DescriptionMinLength)
            {
                sb.AppendLine($"Description should be at least {DescriptionMinLength} characters long!");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
