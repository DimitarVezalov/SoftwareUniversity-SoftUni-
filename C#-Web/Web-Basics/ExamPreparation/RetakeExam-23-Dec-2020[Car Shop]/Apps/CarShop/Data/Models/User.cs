using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Data.Models
{
    using static DataConstants;

    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();

        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsMechanic { get; set; }
    }

}
