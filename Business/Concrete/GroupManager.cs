using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class GroupManager : IGroupService
    {
        private readonly IGroupDal _groupDal;

        public GroupManager(IGroupDal groupDal)
        {
            _groupDal = groupDal;
        }

        public void SeedData()
        {
            var groups = new List<Group>
            {
                new Group { Id = 1,Name='A',Teams=null},
                new Group { Id = 2,Name='B',Teams=null},
                new Group { Id = 3,Name='C',Teams=null},
                new Group { Id = 4,Name='D',Teams=null},
                new Group { Id = 5,Name='E',Teams=null},
                new Group { Id = 6,Name='F',Teams=null},
                new Group { Id = 7,Name='G',Teams=null},
                new Group { Id = 8,Name='H',Teams=null},
            };

            foreach (var group in groups)
            {
                _groupDal.Add(group);
            }
        }
    }
}
