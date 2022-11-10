using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Models.Data.Models
{
    public class ListProduct
    {
        [Key]
        public int Id { get; set; }

        public bool IsBought { get; set; } = false;

        public int ShopListId { get; set; }

        [ForeignKey(nameof(ShopListId))]
        public ShopList ShopList { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
