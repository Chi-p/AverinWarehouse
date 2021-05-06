using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverinApp.Entities
{
    public partial class Shipment
    {
        public decimal TotalWeight
        {
            get
            {
                return ShipmentOfProduct.ToList().Sum(i => i.Weight);
            }
        }
    }
}
