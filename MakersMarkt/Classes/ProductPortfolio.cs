using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersMarkt.Classes
{
    class ProductPortfolio
    {
        public int Id { get; set; }
        public int Portfolio_id { get; set; }
        public int Product_id { get; set; }
        public DateTime Date_added { get; set; }
    }
}
