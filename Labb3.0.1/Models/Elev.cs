using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3._0._1.Models
{
    public partial class Elev
    {
        public Elev()
        {
            Betyg = new HashSet<Betyg>();
            KursLista = new HashSet<KursLista>();
        }

        public int ElevId { get; set; }
        public string Personnummer { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Klass { get; set; }
        public int? FkGenderId { get; set; }

        public virtual ICollection<Betyg> Betyg { get; set; }
        public virtual ICollection<KursLista> KursLista { get; set; }
    }
}
