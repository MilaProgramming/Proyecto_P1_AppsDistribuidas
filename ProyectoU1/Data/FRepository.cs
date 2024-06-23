using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FRepository : iRepository
    {
        DbContext dbContext;
        public FRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public TEntity Create<TEntity>(TEntity toCreate) where TEntity : class
        {
            TEntity Result = default(TEntity);
            try
            {
                dbContext.Set<TEntity>().Add(toCreate);
                dbContext.SaveChanges();
                Result = toCreate;
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public bool Delete<TEntity>(TEntity toDelete) where TEntity : class
        {
            bool Result = false;
            try
            {
                dbContext.Entry<TEntity>(toDelete).State = EntityState.Deleted;
                Result = dbContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public void Dispose()
        {
            if (dbContext != null) dbContext.Dispose();
        }

        public List<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            List<TEntity> Result = null;

            try
            {
                Result = dbContext.Set<TEntity>().Where(criteria).ToList();
            }
            catch
            {
                throw;
            }
            return Result;
        }

        public TEntity Retrieve<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            TEntity Result = null;
            try
            {
                Result = dbContext.Set<TEntity>().FirstOrDefault(criteria);
            }
            catch
            {
                throw;
            }
            return Result;
        }

        public List<TEntity> RetrieveAll<TEntity>() where TEntity : class
        {
            List<TEntity> Result = null;
            try
            {
                Result = dbContext.Set<TEntity>().ToList();
            }
            catch
            {
                throw;
            }
            return Result;
        }

        public bool Update<TEntity>(TEntity toUpdate) where TEntity : class
        {
            bool result = false;
            try
            {
                var entry = dbContext.Entry(toUpdate);
                if (entry.State == EntityState.Detached)
                {
                    var existingEntity = dbContext.Set<TEntity>().Find(GetKeyValues(toUpdate));
                    if (existingEntity != null)
                    {
                        dbContext.Entry(existingEntity).CurrentValues.SetValues(toUpdate);
                        result = dbContext.SaveChanges() > 0;
                    }
                    else
                    {
                        dbContext.Entry(toUpdate).State = EntityState.Modified;
                        result = dbContext.SaveChanges() > 0;
                    }
                }
                else
                {
                    // If the entity is already being tracked, just save changes
                    result = dbContext.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error updating entity", ex);
            }
            return result;
        }

        // Helper method to get the primary key values of an entity
        private object[] GetKeyValues<TEntity>(TEntity entity) where TEntity : class
        {
            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
            var objectSet = objectContext.CreateObjectSet<TEntity>();
            var entityKey = objectSet.EntitySet.ElementType.KeyMembers[0];
            var property = entity.GetType().GetProperty(entityKey.Name);
            return new object[] { property.GetValue(entity) };
        }
    }
}
