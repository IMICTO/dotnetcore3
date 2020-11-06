using System;

namespace Bazzar.Core.Domain.Advertisements.Commands
{
    public class Create
    {
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }
    }
}
