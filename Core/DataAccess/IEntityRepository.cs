using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        IDataResult<T> Get(Expression<Func<T, bool>> filter);
        IDataResult<List<T>> GetList(Expression<Func<T, bool>> filter = null);
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}
