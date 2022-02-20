using System;

namespace OnlineShopping.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
        public string Photo { get; set; }
    }
}