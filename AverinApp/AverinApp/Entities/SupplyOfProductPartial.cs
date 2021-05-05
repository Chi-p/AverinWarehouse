using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace AverinApp.Entities
{
    public partial class SupplyOfProduct
    {
        public string CertificateState
        {
            get
            {
                return $"до {Product.Certificate.DateEnd:dd MMMM yyyy г.}";
            }
        }

        private bool _checked;
        public bool Checked
        {
            get => _checked;
            set
            {
                _checked = value;
                if (Checked)
                {
                    if (Supply.Warehouse.WarehouseOfProduct.ToList().FirstOrDefault(i => i.Product == Product) == null)
                        Supply.Warehouse.WarehouseOfProduct.Add(new WarehouseOfProduct
                        {
                            WarehouseId = Supply.WarehouseId,
                            Product = Product,
                            Count = Count
                        });
                }
                else
                {
                    Supply.Warehouse.WarehouseOfProduct.Remove(Supply.Warehouse.WarehouseOfProduct.ToList().FirstOrDefault(i => i.Product == Product));
                }
            }
        }

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


        public string WeightCount
        {
            get
            {

                return $"{Count} шт. ({Weight:N3} т.)";
            }
        }
    }
}
