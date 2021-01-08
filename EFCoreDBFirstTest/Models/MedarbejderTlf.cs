using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class MedarbejderTlf
    {
        public int MeTlf { get; set; }
        public Guid MeId { get; set; }

        public virtual Medarbejder Me { get; set; }
    }
}
