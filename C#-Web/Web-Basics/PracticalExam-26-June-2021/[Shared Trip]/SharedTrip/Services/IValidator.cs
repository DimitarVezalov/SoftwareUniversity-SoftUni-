using SharedTrip.ViewModels.Trips;
using SharedTrip.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface IValidator
    {
        bool ValidateUserRegister(RegisterUserInputModel model);

        bool ValidateLogin(LoginUserInputModel model);

        bool ValidateAddTrip(AddTripInputModel model);
    }
}
