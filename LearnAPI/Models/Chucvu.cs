using System;
using System.Collections.Generic;

#nullable disable

namespace LearnAPI.Models
{
    public partial class Chucvu
    {
        public Chucvu()
        {
            Canbos = new HashSet<Canbo>();
        }

        public int Idchucvucanbo { get; set; }
        public string Tenchucvucanbo { get; set; }

        public virtual ICollection<Canbo> Canbos { get; set; }
    }
}
