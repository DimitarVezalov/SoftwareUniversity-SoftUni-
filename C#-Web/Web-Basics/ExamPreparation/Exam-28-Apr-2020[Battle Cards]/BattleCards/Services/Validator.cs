using BattleCards.Data;
using BattleCards.ViewModels.Cards;
using BattleCards.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    using static DataConstants;

    public class Validator : IValidator
    {
        public bool ValidateCardAdd(AddCardInputModel model)
        {
            if (String.IsNullOrEmpty(model.Name)||
                model.Name.Length < MinCardNameLength ||
                model.Name.Length > MaxCardNameLength)
            {
                return false;
            }

            if (String.IsNullOrEmpty(model.Image))
            {
                return false;
            }

            if (String.IsNullOrEmpty(model.Keyword))
            {
                return false;
            }

            if (model.Attack < 0)
            {
                return false;
            }

            if (model.Health < 0)
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

        public bool ValidateUserRegister(RegisterUserInputModel model)
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
