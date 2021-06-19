using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Users;

namespace CarShop.Services
{
    public interface IValidator
    {
        string ValidateUserRegistrationModel(RegisterInputModel model);

        string ValidateCarInputModel(AddCarInputModel model);
    }
}
