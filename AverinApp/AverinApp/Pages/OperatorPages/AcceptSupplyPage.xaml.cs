using AverinApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AverinApp.Pages.OperatorPages
{
    /// <summary>
    /// Interaction logic for AcceptSupplyPage.xaml
    /// </summary>
    public partial class AcceptSupplyPage : Page
    {
        private Supply _supply;

        public AcceptSupplyPage(Supply supply)
        {
            InitializeComponent();
            _supply = supply;
            DataContext = _supply;
        }
    }
}
