using System;
using System.Collections.Generic;

#nullable disable

namespace LearnAPI.Models
{
    public partial class Canbo
    {
        public int Idcb { get; set; }
        public string Fullnamecb { get; set; }
        public bool? Gioitinhcb { get; set; }
        public DateTime? Sinhnhatcb { get; set; }
        public string Hocvancb { get; set; }
        public string Sdtcb { get; set; }
        public string Diachicb { get; set; }
        public DateTime? Ngaybatdaulamcb { get; set; }
        public int? IdBoMon { get; set; }
        public int? Idchucvu { get; set; }

        public virtual Bomon IdBoMonNavigation { get; set; }
        public virtual Chucvu IdchucvuNavigation { get; set; }
    }
}
