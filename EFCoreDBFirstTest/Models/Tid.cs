using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class Tid
    {
        public decimal Tid1 { get; set; }
        public string TidDato { get; set; }
        public Guid TidId { get; set; }
        public Guid SagId { get; set; }
        public Guid YdelseNr { get; set; }
        public Guid AdvokatId { get; set; }

        public virtual Medarbejder Advokat { get; set; }
        public virtual Sag Sag { get; set; }
        public virtual SagYdelser SagYdelser { get; set; }
    }
}
