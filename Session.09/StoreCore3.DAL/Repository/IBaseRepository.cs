using System.Collections.Generic;

namespace StoreCore3.DAL.Repository
{
    public interface IBaseRepository<TEntity>
    {
        void UpdateWithList(TEntity entity, List<string> properties);

        void Truncate();
    }
}
