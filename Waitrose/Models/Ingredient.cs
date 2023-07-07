using System.Collections.Generic;

namespace Waitrose.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<ProductIngredient> ProductIngredients { get; set; }
        public Inventory Inventory { get; set; }
    }
}
