using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersMarkt.Classes
{
    class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime DatePlaced { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
