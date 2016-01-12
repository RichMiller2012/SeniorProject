using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Barcode
    {
        public virtual int barcodeId { get; set; }
        public virtual Item item { get; set; }
    }
}
