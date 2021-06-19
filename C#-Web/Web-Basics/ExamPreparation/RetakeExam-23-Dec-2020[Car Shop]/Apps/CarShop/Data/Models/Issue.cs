using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarShop.Data.Models
{
    public class Issue
    {
        public Issue()
        {
            this.Id = Guid.NewGuid().ToString();

        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsFixed { get; set; }

        [Required]
        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }
         
        public virtual Car Car { get; set; }
    }
}
