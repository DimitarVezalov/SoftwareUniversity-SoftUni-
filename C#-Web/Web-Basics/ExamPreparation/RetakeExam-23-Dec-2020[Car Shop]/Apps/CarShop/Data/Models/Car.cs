using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarShop.Data.Models
{
    using static DataConstants;

    public class Car
    {
        public Car()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Issues = new HashSet<Issue>();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public string PlateNumber { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }

    }

}
