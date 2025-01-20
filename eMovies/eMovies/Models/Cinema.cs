using eMovies.Base;
using System.ComponentModel.DataAnnotations;

namespace eMovies.Models
{
    public class Cinema : IEntityBase
    {
        public Cinema()
        {
            this.Movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo is required.")]
        [StringLength(255, ErrorMessage = "Logo cannot exceed 255 characters.")]
        public string Logo { get; set; }

        [Display(Name = "Cinema name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        [Display(Name = "Contact email")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string ContactEmail { get; set; }

        [Display(Name = "Phone number")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Working hours")]
        [Required]
        public string OpeningHours { get; set; }

        [Display(Name = "Cinema's capacity")]
        [Range(0, int.MaxValue, ErrorMessage = "Capacity must be a positive number.")]
        public int Capacity { get; set; }

        [Display(Name = "Website")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string Website { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
