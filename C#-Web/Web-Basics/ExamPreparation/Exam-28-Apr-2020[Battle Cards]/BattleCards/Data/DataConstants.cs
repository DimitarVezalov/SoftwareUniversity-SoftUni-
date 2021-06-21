using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Data
{
    public static class DataConstants
    {
        //User
        public const int MinUsernameLength = 5;
        public const int MaxUsernameLength = 20;
        public const int MinPasswordLength = 6;
        public const int MaxPasswordLength = 20;

        //Card
        public const int MinCardNameLength = 5;
        public const int MaxCardNameLength = 15;
        public const int MaxDescriptionLength = 200;
    }
}
