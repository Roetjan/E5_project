using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersMarkt.Classes
{
    class NotificationUser
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public Notification Notification { get; set; }
        public User User { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
