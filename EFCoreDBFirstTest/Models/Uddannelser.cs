using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class Uddannelser
    {
        public Uddannelser()
        {
            AdvokatUddannelsers = new HashSet<AdvokatUddannelser>();
        }

        public string AdvokatUddanelse { get; set; }

        public virtual ICollection<AdvokatUddannelser> AdvokatUddannelsers { get; set; }
    }
}
