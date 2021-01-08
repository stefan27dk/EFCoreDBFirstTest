using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class LogIn
    {
        public Guid MeId { get; set; }
        public string LogInNavn { get; set; }
        public string LogInPass { get; set; }

        public virtual Medarbejder Me { get; set; }
    }
}
