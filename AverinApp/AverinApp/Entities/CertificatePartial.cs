using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverinApp.Entities
{
    public partial class Certificate
    {
        public string Info
        {
            get
            {
                return $"{Number}, {Manufacturer.Name}, до {DateEnd:dd MMMM yyyy г.}";
            }
        }
    }
}
