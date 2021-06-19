using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Data
{
    public static class DataConstants
    {
        //Car
        public const int ModelMinLength = 5;
        public const int ModelMaxLength = 20;
        public const string PlateRegex = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";

        //User
        public const int UsernameMinLength = 4;
        public const int UsernameMaxLength = 20;
        public const int PasswordMinLength = 4;
        public const int PasswordMaxLength = 20;

        //Issue
        public const int DescriptionMinLength = 5;
    }
}
