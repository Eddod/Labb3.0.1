using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3._0._1.Models
{
    public partial class Personal
    {
        public Personal()
        {
            Betyg = new HashSet<Betyg>();
        }

        public int PersonalId { get; set; }
        public string Namn { get; set; }
        public string Befattning { get; set; }

        public virtual ICollection<Betyg> Betyg { get; set; }
    }
}
