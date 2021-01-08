using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class Kørsel
    {
        public decimal KørselTid { get; set; }
        public string KørselDato { get; set; }
        public string KørselNotering { get; set; }
        public Guid KørselId { get; set; }
        public Guid SagId { get; set; }
        public Guid AdvokatId { get; set; }

        public virtual Medarbejder Advokat { get; set; }
        public virtual Sag Sag { get; set; }
    }
}
