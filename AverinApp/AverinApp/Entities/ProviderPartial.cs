using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverinApp.Entities
{
    public partial class Provider
    {
        public string Info
        {
            get
            {
                return $"{Name}, {Address} {Country.Name}, {Phone}";
            }
        }
    }
}
