using Core.Entities;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
           where TEntity : class, IEntity, new()
           where TContext : DbContext, new()
    {
        public IResult Add(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            return new Result(true);
        }

        public IResult Delete(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                }
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                using (var context = new TContext())
                {
                    return new DataResult<TEntity>(context.Set<TEntity>().SingleOrDefault(filter), true);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<TEntity>(ex.Message);
            }

        }

        public IDataResult<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                using (var context = new TContext())
                {
                    return filter == null
                        ? new DataResult<List<TEntity>>(context.Set<TEntity>().ToList(), true)
                        : new DataResult<List<TEntity>>(context.Set<TEntity>().Where(filter).ToList(), true);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<TEntity>>(ex.Message);
            }

        }

        public IResult Update(TEntity entity)
        {
            try
            {
                using (var context = new TContext())
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    context.SaveChanges();
                }
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }
    }
}
