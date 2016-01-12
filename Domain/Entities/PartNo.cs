using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PartNo
    {
        public virtual int partNoId { get; set; }
        public virtual Item item { get; set; }
    }
}
