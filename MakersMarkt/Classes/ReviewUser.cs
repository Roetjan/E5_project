using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersMarkt.Classes
{
    class ReviewUser
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public Review Review { get; set; }
        public User User { get; set; }
    }
}
