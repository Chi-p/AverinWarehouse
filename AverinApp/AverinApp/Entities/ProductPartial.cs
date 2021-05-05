using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace AverinApp.Entities
{
    public partial class Product
    {
        public string WeightUnit
        {
            get
            {
                return Weight + " " + MeasureUnit;
            }
        }

        public string CertificateState
        {
            get
            {
                if (Certificate.DateEnd >= DateTime.Now)
                    return $"до {Certificate.DateEnd:dd MMMM yyyy г.}";
                else
                    return $"устарел";
            }
        }

        public Brush CertifacateStateColor
        {
            get
            {
                if (Certificate.DateEnd >= DateTime.Now)
                    return (Brush)Application.Current.Resources["PColor_Second"];

                    return (Brush)Application.Current.Resources["PColor_First"];
            }
        }

        public string Info
        {
            get
            {
                return $"{Description}, вес - {WeightUnit}, цена - {Price} рублей(руб.)";
            }
        }
    }
}
