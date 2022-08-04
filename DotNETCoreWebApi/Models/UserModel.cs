﻿using System.ComponentModel.DataAnnotations;

namespace DotNETCoreWebApi.Models
{
    public class UserModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50, ErrorMessage = "First name length can't be more than 50")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name length can't be more than 50")]
        public string? LastName { get; set; }
    }
}
