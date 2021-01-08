using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class MedarbejderType
    {
        public MedarbejderType()
        {
            Medarbejders = new HashSet<Medarbejder>();
        }

        public string MeType { get; set; }

        public virtual ICollection<Medarbejder> Medarbejders { get; set; }


    
    }
}
