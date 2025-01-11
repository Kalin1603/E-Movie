using eMovies.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMovies.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Movie image URL is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string MovieImageURL { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public MovieCategory Category { get; set; }

        public ICollection<ActorMovie> Actors { get; set; }

        [ForeignKey(nameof(Cinema))]
        public int CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        [ForeignKey(nameof(Producer))]
        public int ProducerId { get; set; }

        public Producer Producer { get; set; }
    }
}
