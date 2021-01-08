using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class Post
    {
        public Post()
        {
            Kundes = new HashSet<Kunde>();
            Medarbejders = new HashSet<Medarbejder>();
        }

        public int PostNr { get; set; }
        public string Distrikt { get; set; }

        public virtual ICollection<Kunde> Kundes { get; set; }
        public virtual ICollection<Medarbejder> Medarbejders { get; set; }
    }
}
