using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Data
{
    public static class ExceptionMessages
    {
        //Register
        public const string InvalidInput = "{0} should be between {1} and {2} characters long.";
        public const string RequiredField = "{0} is required.";
        public const string NotEqualPasswords = "The passwords don't match.";

        //Login
        public const string InvalidLogin = "Wrong {0}!";

        //OTher
        public const string InvalidNumericInput = "{0} shoud be a number between {1} and {2}";

        
    }
}

