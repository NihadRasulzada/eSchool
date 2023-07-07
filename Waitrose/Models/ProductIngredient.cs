﻿namespace Waitrose.Models
{
    public class ProductIngredient
    {
        public int Id { get; set; }
        public double Need { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }
    }
}
