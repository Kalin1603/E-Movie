using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMovies.Models
{
    public class ShoppingCardItem
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public string ShoppingCardId { get; set; }
    }
}
