using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models.Data.Models
{
    public class ShopList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<ListProduct> ListProducts { get; set; } = new HashSet<ListProduct>();

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category >();
    }
}
