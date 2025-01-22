using eMovies.Enums;
using System.ComponentModel.DataAnnotations;

namespace eMovies.ViewModels
{
    public class EditMovieViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public double Price { get; set; }

        [Display(Name = "Movie image")]
        [Required(ErrorMessage = "Movie image URL is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string MovieImageURL { get; set; }

        [Display(Name = "Start date")]
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select category")]
        [Required(ErrorMessage = "Category is required.")]
        public MovieCategory Category { get; set; }

        [Display(Name = "Select actor(s)")]
        public List<int>? ActorIds { get; set; }

        [Display(Name = "Select a cinema")]
        [Required(ErrorMessage = "Movie cinema is required")]
        public int CinemaId { get; set; }

        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Movie producer is required")]
        public int ProducerId { get; set; }
    }
}
