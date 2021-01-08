using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class Medarbejder
    {
        public Medarbejder()
        {
            AdvArbejdsYdelsers = new HashSet<AdvArbejdsYdelser>();
            AdvokatUddannelsers = new HashSet<AdvokatUddannelser>();
            Kørsels = new HashSet<Kørsel>();
            MedarbejderTlves = new HashSet<MedarbejderTlf>();
            Sags = new HashSet<Sag>();
            Tids = new HashSet<Tid>();
        }

        public string MeFornavn { get; set; }
        public string MeEfternavn { get; set; }
        public int MePostNr { get; set; }
        public string MeAdresse { get; set; }
        public Guid MeId { get; set; }
        public string MeType { get; set; }
        public string MeEmail { get; set; }
        public string MeOpretsDato { get; set; }

        public virtual Post MePostNrNavigation { get; set; }
        public virtual MedarbejderType MeTypeNavigation { get; set; }
        public virtual ICollection<AdvArbejdsYdelser> AdvArbejdsYdelsers { get; set; }
        public virtual ICollection<AdvokatUddannelser> AdvokatUddannelsers { get; set; }
        public virtual ICollection<Kørsel> Kørsels { get; set; }
        public virtual ICollection<MedarbejderTlf> MedarbejderTlves { get; set; }
        public virtual ICollection<Sag> Sags { get; set; }
        public virtual ICollection<Tid> Tids { get; set; }
    }
}
