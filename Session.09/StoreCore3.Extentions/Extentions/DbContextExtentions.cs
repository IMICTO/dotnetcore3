using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreCore3.Extentions.Extentions
{
    public static class DbContextExtentions
    {
        public static DbContext GetDbContext<TEntity>(this TEntity dbSet) where TEntity : class
        {
            IInfrastructure<IServiceProvider> infrastructure = dbSet as IInfrastructure<IServiceProvider>;

            IServiceProvider serviceProvider = infrastructure.Instance;

            ICurrentDbContext currentDbContext = serviceProvider.GetService(typeof(ICurrentDbContext)) as ICurrentDbContext;

            return currentDbContext.Context;
        }

        public static int Clear<TEntity>(this DbContext dbContext) where TEntity : class
        {
            return dbContext.ContainsEntity<TEntity>() ? dbContext.Set<TEntity>().Clear() : 0;
        }

        public static bool ContainsEntity<TEntity>(this DbContext dbContext) where TEntity : class
        {
            return dbContext.Model.FindEntityType(typeof(TEntity)) != null;
        }

        public static IEnumerable<EntityEntry> GetChangedEntities(this DbContext dbContext, EntityState? entityState)
        {
            IEnumerable<EntityEntry> entries = dbContext.ChangeTracker.Entries();

            if (entityState.HasValue)
            {
                entries = entries.Where(c => c.State == entityState.Value);
            }

            return entries;
        }

        public static IEnumerable<EntityEntry> GetAddedOrModifiedEntities(this DbContext dbcontext)
        {
            return dbcontext.GetChangedEntities(null).Where(c => c.State == EntityState.Added || c.State == EntityState.Modified);
        }

        public static IEnumerable<EntityEntry> GetAddedEntities(this DbContext dbcontext)
        {
            return dbcontext.GetChangedEntities(EntityState.Added);
        }

        public static IEnumerable<EntityEntry> GetModifiedEntities(this DbContext dbContext)
        {
            return dbContext.GetChangedEntities(EntityState.Modified);
        }

        public static IEnumerable<EntityEntry> GetDeletedEntities(this DbContext dbContext)
        {
            return dbContext.GetChangedEntities(EntityState.Deleted);
        }
    }
}
