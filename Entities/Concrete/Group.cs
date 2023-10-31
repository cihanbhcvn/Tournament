using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Group : IEntity
    {
        public Group()
        {
            Teams = new List<Team>();
        }
        [Key]
        public int Id { get; set; }
        public char Name { get; set; }
        public List<Team>? Teams { get; set; }
    }
}
