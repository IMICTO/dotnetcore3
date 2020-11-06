using System;

namespace StoreCore3.Domain
{
    public class BaseEntity
    {
        public string TimeStamp { get; set; }

        public DateTime LastChangeDate { get; set; }

        public string ModifierUsername { get; set; }
    }
}
