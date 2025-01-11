﻿using System.ComponentModel.DataAnnotations;

namespace eMovies.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(30, ErrorMessage = "First name cannot exceed 30 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(30, ErrorMessage = "Last name cannot exceed 30 characters.")]
        public string LastName { get; set; }

        [MaxLength(1000, ErrorMessage = "Bio cannot exceed 100 characters.")]
        public string Bio { get; set; }

        [Required(ErrorMessage = "Profile picture URL is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string ProfilePictureURL { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
