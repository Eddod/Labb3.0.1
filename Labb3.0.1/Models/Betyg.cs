using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3._0._1.Models
{
    public partial class Betyg
    {
        public int BetygId { get; set; }
        public int FkElevId { get; set; }
        public int FkPersonalId { get; set; }
        public int FkKursId { get; set; }
        public int Betyg1 { get; set; }
        public DateTime? Datum { get; set; }

        public virtual Elev FkElev { get; set; }
        public virtual Kurs FkKurs { get; set; }
        public virtual Personal FkPersonal { get; set; }
    }
}
