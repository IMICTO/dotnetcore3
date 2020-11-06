using Bazzar.Core.Domain.UserProfiles.Entities;

using System;

namespace Bazzar.Core.Domain.UserProfiles.Data
{
    public interface IUserProfileRepository
    {
        UserProfile Load(Guid id);

        void Add(UserProfile entity);

        bool Exists(Guid id);
    }
}
