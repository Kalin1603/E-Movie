using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMovies.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        [Display(Name = "Order")]
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Display(Name = "Movie")]
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
