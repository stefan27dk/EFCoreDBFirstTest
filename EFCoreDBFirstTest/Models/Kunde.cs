using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class Kunde
    {
        public Kunde()
        {
            KundeTlves = new HashSet<KundeTlf>();
            Sags = new HashSet<Sag>();
        }

        public string KundeFornavn { get; set; }
        public string KundeEfternavn { get; set; }
        public int KundePostNr { get; set; }
        public string KundeAdresse { get; set; }
        public Guid KundeId { get; set; }
        public string KundeEmail { get; set; }
        public string KundeOpretsDato { get; set; }

        public virtual Post KundePostNrNavigation { get; set; }
        public virtual ICollection<KundeTlf> KundeTlves { get; set; }
        public virtual ICollection<Sag> Sags { get; set; }
    }
}
