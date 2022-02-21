using System;

namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public long CardNumber { get; set; }
    }
}