using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
