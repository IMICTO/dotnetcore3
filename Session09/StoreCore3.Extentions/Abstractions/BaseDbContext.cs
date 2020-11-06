using Microsoft.EntityFrameworkCore;

using StoreCore3.Extentions.Extentions;

using System.Linq;
using System.Reflection;

namespace StoreCore3.Extentions.Abstractions
{
    public class BaseDbContext : DbContext
    {
        public override int SaveChanges()
        {
            BeforSaveChanges();
            int result = base.SaveChanges();
            AfterSaveChanges();
            return result;
        }

        private void AfterSaveChanges()
        {
        }

        private void BeforSaveChanges()
        {
            SetYeKe();
        }

        private void SetYeKe()
        {
            System.Collections.Generic.IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry> addedOrUpdated = this.GetAddedOrModifiedEntities();

            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry item in addedOrUpdated)
            {
                object entity = item.Entity;
                if (entity == null)
                {
                    continue;
                }

                System.Collections.Generic.IEnumerable<PropertyInfo> propertylnfos = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (PropertyInfo propertyInfo in propertylnfos)
                {
                    object value = propertyInfo.GetValue(entity);

                    if (value != null)
                    {
                        string strValue = value.ToString();
                        string newValue = strValue.SetPersianYeKe();//اصلاح حروف عربی
                        if (newValue != strValue)
                        {
                            propertyInfo.SetValue(entity, newValue);
                        }
                    }
                }
            }
        }
    }
}
