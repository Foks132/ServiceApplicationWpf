using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApplication.Entities
{
    public class BindContext
    {
        public Service Service { get; set; }
        public bool IsEdit { get; set; }
    }
}
