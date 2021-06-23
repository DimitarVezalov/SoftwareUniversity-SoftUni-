using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Data
{
    public static class DataConstants
    {
        //User
        public const int MinUsernameLength = 4;
        public const int MaxUsernameLength = 10;
        public const int MinPasswordLength = 6;
        public const int MaxPasswordLength = 20;

        //Album
        public const int MinAlbumNameLength = 4;
        public const int MaxAlbumNameLength = 20;
        public const int MaxDescriptionLength = 200;

        //Track
        public const int MinTrackNameLength = 4;
        public const int MaxTrackNameLength = 20;
    }
}
