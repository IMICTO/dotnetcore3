using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

namespace StoreCore3.DAL.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        private readonly StoreCore3Db ctx;

        public BaseRepository(StoreCore3Db ctx)
        {
            this.ctx = ctx;
        }

        public void Truncate()
        {

            string sqlQuery = $"delete from [{ctx.Model.FindEntityType(typeof(TEntity)).GetDefaultSchema()}].[{ctx.Model.FindEntityType(typeof(TEntity)).GetDefaultTableName()}]";

            ctx.Database.ExecuteSqlCommand(sqlQuery);
        }

        public void UpdateWithList(TEntity entity, List<string> properties)
        {
            List<string> discoveredProperties = new List<string>();
            foreach (System.Reflection.PropertyInfo item in typeof(TEntity).GetProperties())
            {
                discoveredProperties.Add(item.Name);
            }

            foreach (string property in properties)
            {
                if (properties.Contains(property))
                {
                    ctx.Entry(entity).Property(property).IsModified = true;
                    ctx.SaveChanges();
                }
            }
        }
    }
}
