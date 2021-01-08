using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class SagYdelser
    {
        public SagYdelser()
        {
            Tids = new HashSet<Tid>();
        }

        public string SagYdelseOpretsDato { get; set; }
        public Guid SagId { get; set; }
        public Guid YdelseNr { get; set; }

        public virtual Sag Sag { get; set; }
        public virtual Ydelse YdelseNrNavigation { get; set; }
        public virtual ICollection<Tid> Tids { get; set; }
    }
}
