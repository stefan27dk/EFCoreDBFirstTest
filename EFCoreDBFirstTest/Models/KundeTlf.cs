using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class KundeTlf
    {
        public int KundeTlf1 { get; set; }
        public Guid KundeId { get; set; }

        public virtual Kunde Kunde { get; set; }
    }
}
