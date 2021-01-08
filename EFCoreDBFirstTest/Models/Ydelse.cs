using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class Ydelse
    {
        public Ydelse()
        {
            SagYdelsers = new HashSet<SagYdelser>();
        }

        public string YdelseNavn { get; set; }
        public decimal YdelsePris { get; set; }
        public string YdelseType { get; set; }
        public string YdelseArt { get; set; }
        public Guid YdelseNr { get; set; }
        public string YdelseOpretsDato { get; set; }

        public virtual TypeYdelse YdelseTypeNavigation { get; set; }
        public virtual ICollection<SagYdelser> SagYdelsers { get; set; }
    }
}
