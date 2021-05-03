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
        public string CertifacateState
        {
            get
            {
                if (AppData.Context.Product.Where(i => i.CertificateNumber == CertificateNumber) == null)
                    return $"новый - до {Certificate.DateEnd:dd MMMM yyyy г.}";

                return $"до {Certificate.DateEnd:dd MMMM yyyy г.}";
            }
        }

        public Brush CertifacateStateColor
        {
            get
            {
                if (AppData.Context.Product.Where(i => i.CertificateNumber == CertificateNumber) == null)
                    return (Brush)Application.Current.Resources["PColor_Second"];

                return Brushes.Black;
            }
        }
    }
}
