using System;
using System.Collections.Generic;

namespace EfCoreNew.Scaffold
{
    public partial class Address
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Phone { get; set; }
        public string AddressLine { get; set; }

        public virtual People Person { get; set; }
    }
}
