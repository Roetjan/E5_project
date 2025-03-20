using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersMarkt.Classes
{
    class ProductReview
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public Review Review { get; set; }
        public Product Product { get; set; }
    }
}
