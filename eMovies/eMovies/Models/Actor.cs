using eMovies.Base;
using System.ComponentModel.DataAnnotations;

namespace eMovies.Models
{
    public class Actor : IEntityBase
    {
        public Actor()
        {
            this.Movies = new HashSet<ActorMovie>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(30, ErrorMessage = "First name cannot exceed 30 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(30, ErrorMessage = "Last name cannot exceed 30 characters.")]
        public string LastName { get; set; }

        [Display(Name = "Biography")]
        [MaxLength(1000, ErrorMessage = "Bio cannot exceed 100 characters.")]
        public string Bio { get; set; }

        [Display(Name = "Profile picture")]
        [Required(ErrorMessage = "Profile picture URL is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string ProfilePictureURL { get; set; }

        public ICollection<ActorMovie> Movies { get; set; }
    }
}
