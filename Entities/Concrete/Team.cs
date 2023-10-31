﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Team : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
