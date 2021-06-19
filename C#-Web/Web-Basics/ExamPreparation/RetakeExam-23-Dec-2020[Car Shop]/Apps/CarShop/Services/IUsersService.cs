using CarShop.ViewModels.Cars;

namespace CarShop.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void Create(string username, string email, string password, string userType);

        bool IsUsernameAvailable(string username);

        bool IsUserMechanic(string userid);

        void AddCar(AddCarInputModel model, string userId);

        

    }
}
