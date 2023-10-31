using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class EfGroupDal : EfEntityRepositoryBase<Group, TournamentContext>, IGroupDal
    {
        public IDataResult<List<Group>> GetNumberedList(int count)
        {
            try
            {
                using (var context = new TournamentContext())
                {
                    return new DataResult<List<Group>>(context.Groups.Take(count).ToList(), true);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Group>>(ex.Message);
            }
        }
    }
}
