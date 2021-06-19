using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Data
{
    public static class DataConstants
    {
        //Repository
        public const int RepoNameMinLength = 3;
        public const int RepoNameMaxLength = 10;

        //User
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20;

        //Issue
        public const int DescriptionMinLength = 5;
    }
}
