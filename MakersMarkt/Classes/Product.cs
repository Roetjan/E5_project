﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersMarkt.Classes
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }
        public ICollection<ProductPortfolio> ProductPortfolios { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
