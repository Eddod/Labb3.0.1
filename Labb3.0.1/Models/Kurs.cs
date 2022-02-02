using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3._0._1.Models
{
    public partial class Kurs
    {
        public Kurs()
        {
            Betyg = new HashSet<Betyg>();
            KursLista = new HashSet<KursLista>();
        }

        public int KursId { get; set; }
        public string KursNamn { get; set; }

        public virtual ICollection<Betyg> Betyg { get; set; }
        public virtual ICollection<KursLista> KursLista { get; set; }
    }
}
