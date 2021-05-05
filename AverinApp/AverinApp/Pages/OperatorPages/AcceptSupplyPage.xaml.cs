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
            Load();
        }

        private void Load()
        {
            ICProducts.ItemsSource = _supply.SupplyOfProduct.ToList();
        }

        private void UpdateIC()
        {
            ICProducts.ItemsSource = null;
            ICProducts.ItemsSource = _supply.SupplyOfProduct.ToList();
            UpdateContext();
        }

        private void UpdateContext()
        {
            DataContext = null;
            DataContext = _supply;
        }

        private void ChkBxAccept_Checked(object sender, RoutedEventArgs e)
        {
            UpdateContext();
        }

        private void ChkBxAcceptAll_Checked(object sender, RoutedEventArgs e)
        {
            _supply.SupplyOfProduct.ToList().ForEach(i => i.Checked = ChkBxAcceptAll.IsChecked.Value);
            UpdateIC();
        }
    }
}
