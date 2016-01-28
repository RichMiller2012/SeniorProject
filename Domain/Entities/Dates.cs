using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Dates
    {
        public virtual int dateId { get; set; }
        public virtual DateTime date { get; set; }

        public virtual Item item { get; set; }

    }
}
