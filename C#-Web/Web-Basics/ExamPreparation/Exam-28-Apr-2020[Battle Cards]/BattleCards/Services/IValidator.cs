using BattleCards.ViewModels.Users;
using BattleCards.ViewModels.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface IValidator 
    {
        bool ValidateUserRegister(RegisterUserInputModel model);

        bool ValidateCardAdd(AddCardInputModel model);

    }
}
