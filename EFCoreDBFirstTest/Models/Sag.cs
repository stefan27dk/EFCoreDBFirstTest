using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDBFirstTest.Models
{
    public partial class Sag
    {
        public Sag()
        {
            Kørsels = new HashSet<Kørsel>();
            SagYdelsers = new HashSet<SagYdelser>();
            Tids = new HashSet<Tid>();
        }

        public string SagOpretsDato { get; set; }
        public string SagSlutDato { get; set; }
        public string SagType { get; set; }
        public bool SagAfslutet { get; set; }
        public Guid SagId { get; set; }
        public Guid SagKundeId { get; set; }
        public Guid SagAdvokatId { get; set; }

        public virtual Medarbejder SagAdvokat { get; set; }
        public virtual Kunde SagKunde { get; set; }
        public virtual ICollection<Kørsel> Kørsels { get; set; }
        public virtual ICollection<SagYdelser> SagYdelsers { get; set; }
        public virtual ICollection<Tid> Tids { get; set; }
    }
}
