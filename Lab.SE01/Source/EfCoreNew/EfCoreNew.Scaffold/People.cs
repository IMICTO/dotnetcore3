using System;
using System.Collections.Generic;

namespace EfCoreNew.Scaffold
{
    public partial class People
    {
        public People()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
