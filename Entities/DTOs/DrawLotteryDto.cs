using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class DrawLotteryDto : IDto
    {
        public int GroupCount { get; set; }
        public string FullName { get; set; }
    }
}
