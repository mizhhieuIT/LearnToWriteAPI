using System;
using System.Collections.Generic;

#nullable disable

namespace LearnAPI.Models
{
    public partial class Khoa
    {
        public Khoa()
        {
            Bomons = new HashSet<Bomon>();
        }

        public int IdKhoa { get; set; }
        public string TenKhoa { get; set; }
        public DateTime? NgaythanhlapKhoa { get; set; }

        public virtual ICollection<Bomon> Bomons { get; set; }
    }
}
