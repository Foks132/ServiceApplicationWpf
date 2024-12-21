using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApplication.Entities
{
    public partial class Client
    {
        public string fullName
        {
            get
            {
                return $"{this.lastName} {this.firstName} {this.secondaryName}";
            }
            set { }
        }
    }
}
