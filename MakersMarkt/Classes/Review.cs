using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersMarkt.Classes
{
    class Review
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Score { get; set; }
        public ICollection<ReviewUser> ReviewUsers { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }
    }
}
