using System.ComponentModel.DataAnnotations.Schema;

namespace Waitrose.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public double Count { get; set; }
       
        public Ingredient Ingredient { get; set; }
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }
    }
}
