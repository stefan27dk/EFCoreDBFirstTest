using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class TypeYdelse
    {
        public TypeYdelse()
        {
            Ydelses = new HashSet<Ydelse>();
        }

        public string YdelseType { get; set; }

        public virtual ICollection<Ydelse> Ydelses { get; set; }
    }
}
