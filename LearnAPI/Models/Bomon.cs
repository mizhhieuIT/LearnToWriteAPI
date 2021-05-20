using System;
using System.Collections.Generic;

#nullable disable

namespace LearnAPI.Models
{
    public partial class Bomon
    {
        public Bomon()
        {
            Canbos = new HashSet<Canbo>();
        }

        public int IdBoMon { get; set; }
        public string TenBoMon { get; set; }
        public DateTime? NgaythanhlapBoMon { get; set; }
        public int? IdKhoa { get; set; }

        public virtual Khoa IdKhoaNavigation { get; set; }
        public virtual ICollection<Canbo> Canbos { get; set; }
    }
}
