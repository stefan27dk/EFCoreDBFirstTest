using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class AdvokatUddannelser
    {
        public string AdvokatUddanelse { get; set; }
        public Guid MeId { get; set; }

        public virtual Uddannelser AdvokatUddanelseNavigation { get; set; }
        public virtual Medarbejder Me { get; set; }
    }
}
