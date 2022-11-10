using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
        
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}
