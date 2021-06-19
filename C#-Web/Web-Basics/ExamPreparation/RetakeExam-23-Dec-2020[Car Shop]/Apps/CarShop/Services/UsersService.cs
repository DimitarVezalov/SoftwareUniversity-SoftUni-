using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CarShop.Services
{
    public class UsersService: IUsersService
    {
        private readonly ApplicationDbContext db;
        private readonly ICarsService carsService;

        public UsersService(ApplicationDbContext db, ICarsService carsService)
        {
            this.db = db;
            this.carsService = carsService;
        }

        public void AddCar(AddCarInputModel input, string userId)
        {
            var car = this.carsService.CreateCar(input.Model, input.Year, input.Image, input.PlateNumber);

            car.OwnerId = userId;

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public void Create(string username, string email, string password, string userType)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = HashPassword(password),
                IsMechanic = userType == "Mechanic" ? true : false
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var hasherdPassword = HashPassword(password);

            var userId = this.db.Users
                .Where(u => u.Username == username && u.Password == hasherdPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            return userId;
        }

        public bool IsUserMechanic(string userid)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Id == userid);

            return user.IsMechanic;
        }

        public bool IsUsernameAvailable(string username)
        {
            return this.db.Users.Any(u => u.Username == username);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
