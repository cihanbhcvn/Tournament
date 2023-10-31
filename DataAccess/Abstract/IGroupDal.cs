using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IGroupDal : IEntityRepository<Group>
    {
        IDataResult<List<Group>> GetNumberedList(int count);
    }
}
