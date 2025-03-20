using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersMarkt.Classes
{
    class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public ICollection<NotificationUser> NotificationUsers { get; set; }
    }
}
