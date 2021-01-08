using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class AdvArbejdsYdelser
    {
        public int YdelseNr { get; set; }
        public Guid AdvId { get; set; }

        public virtual Medarbejder Adv { get; set; }
    }
}
