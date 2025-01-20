using eMovies.Base;
using eMovies.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMovies.Models
{
    public class Movie : IEntityBase
    {
        public Movie()
        {
            this.Actors = new HashSet<ActorMovie>();
        }

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

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required.")]
        public MovieCategory Category { get; set; }

        [Display(Name = "Actors")]
        public ICollection<ActorMovie> Actors { get; set; }

        [Display(Name = "Cinema")]
        [ForeignKey(nameof(Cinema))]
        public int CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        [Display(Name = "Producer")]
        [ForeignKey(nameof(Producer))]
        public int ProducerId { get; set; }

        public Producer Producer { get; set; }
    }
}
