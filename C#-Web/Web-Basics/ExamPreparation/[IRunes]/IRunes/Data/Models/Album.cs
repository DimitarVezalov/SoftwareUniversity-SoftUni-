using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace IRunes.Data.Models
{
    using static DataConstants;

    public class Album
    {
        public Album()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Tracks = new HashSet<Track>();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(MaxAlbumNameLength)]
        public string Name { get; set; }

        [Required]
        public string Cover { get; set; }

        public decimal FullPrice => this.Tracks.Sum(t => t.Price);

        public decimal Price => this.FullPrice - (this.FullPrice * 0.15m);

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
