using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class LotValidator : AbstractValidator<Lot>
    {
        public LotValidator()
        {
            RuleFor(x => x.GroupCount).Must(x => x.Equals(4) || x.Equals(8));
        }
    }
}
