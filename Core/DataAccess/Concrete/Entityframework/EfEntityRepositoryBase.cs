using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.Concrete.Entityframework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
    where TEntity: class, IEntity, new()
    where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void InsertOrUpdate(TEntity entity)
        {
            //using (var context = new TContext())
            //{
            //    context.Entry(entity).State = entity.Id
            //}
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntiy = context.Entry(entity);
                updatedEntiy.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
