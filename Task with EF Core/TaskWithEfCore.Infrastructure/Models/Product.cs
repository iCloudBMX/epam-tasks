﻿using System.Collections.Generic;

namespace TaskWithEFCore.Infrastructure.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        
        public IEnumerable<Order> Orders { get; set; }
    }
}
