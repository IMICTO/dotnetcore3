using Bazzar.Core.Domain.Advertisements.Entities;

using System;

namespace Bazzar.Core.Domain.Advertisements.Data
{
    public interface IAdvertisementsRepository
    {
        bool Exists(Guid id);

        Advertisment Load(Guid id);

        void Add(Advertisment entity);
    }
}
