using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AverinApp.Entities
{
    public partial class Warehouse
    {
        public string OperatorName
        {
            get
            {
                if (Operator != null)
                {
                    return Operator.FullName;
                }
                return "Не назначен";
            }
        }

        public decimal Busy
        {
            get
            {
                return WarehouseOfProduct.ToList().Sum(i=>i.Weight);
            }
        }
    }
}
