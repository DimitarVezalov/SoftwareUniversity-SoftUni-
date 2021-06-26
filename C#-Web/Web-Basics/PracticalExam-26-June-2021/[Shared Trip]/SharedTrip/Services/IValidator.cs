namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;
    using SharedTrip.ViewModels.Users;

    public interface IValidator
    {
        bool ValidateUserRegister(RegisterUserInputModel model);

        bool ValidateLogin(LoginUserInputModel model);

        bool ValidateAddTrip(AddTripInputModel model);
    }
}
