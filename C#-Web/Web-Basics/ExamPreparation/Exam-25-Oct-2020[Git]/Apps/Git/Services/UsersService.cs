using Git.Data;
using Git.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Git.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = HashPassword(password)
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user.Id;
        }

        public string GetUserId(string username, string password)
        {
            var hashedPassword = HashPassword(password);

            var userId = this.db.Users
                .Where(u => u.Username == username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            return userId;
        }

        public bool IsEmailAvailable(string email)
        {
            var isInDatabase = this.db.Users
                .Any(u => u.Email == email);

            if (isInDatabase)
            {
                return false;
            }

            return true;
        }

        public bool IsUsernameAvailable(string username)
        {
            var isInDatabase = this.db.Users
              .Any(u => u.Username == username);

            if (isInDatabase)
            {
                return false;
            }

            return true;
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
