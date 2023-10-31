using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Lot : IEntity
    {

        [Key]
        public int Id { get; set; }
        public string DrawerFullname { get; set; }
        public int GroupCount { get; set; }
        public string Details { get; set; }
        public List<Group>? Groups { get; set; }
    }
}
