﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserImportDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [RegularExpression("^[A-Z][a-z]{1,} [A-Z][a-z]{1,}$")]
        public string FullName { get; set; }

        [Required]       
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3,103)]
        public int Age { get; set; }

        public CardImportDto[] Cards { get; set; }
    }
}
