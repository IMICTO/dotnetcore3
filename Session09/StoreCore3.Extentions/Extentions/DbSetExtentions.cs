using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreCore3.Extentions.Extentions
{
    public static class DbSetExtentions
    {
        public static int Clear<TEntity>(this DbSet<TEntity> dbSet) where TEntity : class
        {
            using (DbContext dbContext = dbSet.GetDbContext())
            {
                IEntityType entityType = dbContext.Model.FindEntityType(typeof(TEntity));

                string schema = entityType.GetSchema();
                string tableName = entityType.GetTableName();

                string DeleteCommand = $"Delete {schema ?? "dbo"}.{tableName}";

                return dbContext.Database.ExecuteSqlRaw(DeleteCommand);
            }
        }
    }
}
