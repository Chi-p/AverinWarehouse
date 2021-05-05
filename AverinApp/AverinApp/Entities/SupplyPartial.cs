using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverinApp.Entities
{
    public partial class Supply
    {
        public string ProductCount
        {
            get
            {
                return $"{SupplyOfProduct.Count} ед. товара";
            }
        }

        public string SupplyInfo
        {
            get
            {
                return $"Принятие отгрузки №{SupplyContractNumber} [{SupplyContract.Date:dd MMMM yyyy г.}]";
            }
        }
    }
}
