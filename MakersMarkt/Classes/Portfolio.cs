using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakersMarkt.Classes
{
    class Portfolio
    {
        public int Id { get; set; }
        public string DisplayedName { get; set; } = string.Empty;
        public byte[]? ProfilePicture { get; set; }
        public byte[]? ProfileBanner { get; set; }
        public string? Description { get; set; }
        public ICollection<ProductPortfolio> ProductPortfolios { get; set; }
    }
}
