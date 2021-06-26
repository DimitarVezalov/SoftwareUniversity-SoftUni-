using SharedTrip.Data;

namespace SharedTrip.Services
{
    using System;
    using System.Linq;

    using SharedTrip.ViewModels.Trips;
    using SharedTrip.ViewModels.Users;

    using static DataConstants;

    public class Validator : IValidator
    {
        private readonly ApplicationDbContext db;
        private readonly IPasswordHasher passwordHasher;

        public Validator(ApplicationDbContext db, IPasswordHasher passwordHasher)
        {
            this.db = db;
            this.passwordHasher = passwordHasher;
        }

        public bool ValidateAddTrip(AddTripInputModel model)
        {
            if (String.IsNullOrEmpty(model.StartPoint) || String.IsNullOrEmpty(model.EndPoint) ||
                String.IsNullOrEmpty(model.DepartureTime))
            {
                return false;
            }

            if (model.Seats < MinSeats || model.Seats > MaxSeats)
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

        public bool ValidateLogin(LoginUserInputModel model)
        {
            if (!db.Users.Any(u => u.Username == model.Username))
            {
                return false;
            }

            if (!db.Users.Any(u => u.Password == this.passwordHasher.HashPassword(model.Password)))
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
