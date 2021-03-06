using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.ViewModels.Tracks
{
    public class CreateTrackInputModel
    {
        public string AlbumId { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public decimal Price { get; set; }
    }
}
