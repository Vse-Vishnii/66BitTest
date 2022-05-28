using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _66BitApp.DB;
using _66BitApp.Models;
using Microsoft.EntityFrameworkCore;

namespace _66BitApp.Repositories
{
    public class Repository<TEntity>:IRepository<TEntity>
    where TEntity:DbEntity
    {
        protected readonly UserContext db;

        public Repository(UserContext db)
        {
            this.db = db;
        }

        public async virtual Task<List<TEntity>> GetAll()
        {
            return await db.Set<TEntity>().ToListAsync();
        }

        public async virtual Task<TEntity> Get(long id)
        {
            return await db.Set<TEntity>().FindAsync(id);
        }

        public async virtual Task<TEntity> Add(TEntity entity)
        {
            db.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public async virtual Task<TEntity> Update(long id, TEntity newEntity)
        {
            var entity = db.Set<TEntity>().Find(id);
            newEntity.GetType()
                .GetProperties()
                .Where(p => p.GetValue(newEntity) != null)
                .ToList()
                .ForEach(p => entity.GetType().GetProperty(p.Name).SetValue(entity, p.GetValue(newEntity)));
            db.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<TEntity> Delete(long id)
        {
            var entity = db.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return entity;
            }
            db.Remove(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
