﻿using System.ComponentModel.DataAnnotations;
{
    public class AddAuthorDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
    }
}