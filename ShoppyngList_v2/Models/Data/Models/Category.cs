using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }
        
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

        public virtual ICollection<ShopList> ShopLists { get; set; } = new HashSet<ShopList>();

    }
}
