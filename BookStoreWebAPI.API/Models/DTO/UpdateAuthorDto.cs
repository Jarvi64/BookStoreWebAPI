﻿using System.ComponentModel.DataAnnotations;
{
    public class UpdateAuthorDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
    }
}