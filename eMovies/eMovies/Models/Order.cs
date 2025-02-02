using eMovies.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMovies.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        [ForeignKey(nameof(AppUser))]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
