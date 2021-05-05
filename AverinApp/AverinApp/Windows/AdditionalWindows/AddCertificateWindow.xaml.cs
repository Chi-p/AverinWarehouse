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
using System.Windows.Shapes;

namespace AverinApp.Windows.AdditionalWindows
{
    /// <summary>
    /// Interaction logic for AddCertificateWindow.xaml
    /// </summary>
    public partial class AddCertificateWindow : Window
    {
        private Certificate _certificate;

        public AddCertificateWindow(Certificate certificate)
        {
            InitializeComponent();
            _certificate = certificate;
            Load();
        }

        private void Load()
        {
            CbxManufacturer.ItemsSource = AppData.Context.Manufacturer.ToList();

            if (_certificate != null)
            {
                Title = "Окно просмотра. Сертификат номер: " + _certificate.Number;
                TbxNumber.Text = _certificate.Number;
                CbxManufacturer.SelectedItem = _certificate.Manufacturer;
                DpStartDate.SelectedDate = _certificate.DateStart;
                DpEndDate.SelectedDate = _certificate.DateEnd;
            }
            else
            {
                Title = "Окно добавления. Новый сертификат";
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TbxNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            TbkNumber.Text = TbxNumber.Text;

        }

        private void DpStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DpEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CbxManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAddManufacturer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
