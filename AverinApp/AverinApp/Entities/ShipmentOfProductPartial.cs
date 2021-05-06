using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverinApp.Entities
{
    public partial class ShipmentOfProduct
    {
        public decimal Weight
        {
            get
            {
                decimal multiplier;
                switch (Product.MeasureUnit)
                {
                    case "мг.":
                        multiplier = 0.000000001M;
                        break;
                    case "г.":
                        multiplier = 0.000001M;
                        break;
                    case "кг.":
                        multiplier = 0.001M;
                        break;
                    case "т.":
                        multiplier = 1M;
                        break;
                    default:
                        return 0;
                }
                return Product.Weight * multiplier * Count;
            }
        }

        public decimal TotalCount { get; set; }
    }
}
