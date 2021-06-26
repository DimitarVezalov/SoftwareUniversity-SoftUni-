namespace SharedTrip.Services
{
    using System.Linq;
    using SharedTrip.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;
        private readonly IPasswordHasher passwordHasher;

        public UsersService(ApplicationDbContext db, IPasswordHasher passwordHasher)
        {
            this.db = db;
            this.passwordHasher = passwordHasher;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.passwordHasher.HashPassword(password)
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var hashedPassword = this.passwordHasher.HashPassword(password);

            var userId = this.db.Users
                .Where(u => u.Username == username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            return userId;
        }
    }
}
