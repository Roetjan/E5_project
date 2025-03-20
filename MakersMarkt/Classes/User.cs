using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersMarkt.Classes
{
    class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public int Role_id { get; set; }
        public ICollection<ReviewUser> ReviewUsers { get; set; }
        public ICollection<NotificationUser> NotificationUsers { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
