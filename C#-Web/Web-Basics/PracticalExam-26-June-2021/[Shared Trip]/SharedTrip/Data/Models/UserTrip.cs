using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SharedTrip.Data.Models
{
    public class UserTrip
    {
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        [ForeignKey(nameof(Trip))]
        public string TripId { get; set; }

        public Trip Trip { get; set; }
    }
}
