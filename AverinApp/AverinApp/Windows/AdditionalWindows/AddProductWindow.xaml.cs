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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private Product _product;

        public AddProductWindow(Product product)
        {
            InitializeComponent();
            _product = product;
            Load();
        }

        private void Load()
        {
            AppData.Context.ChangeTracker.Entries<Product>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<Certificate>().ToList().ForEach(i => i.Reload());
            if (_product != null)
            {
                Title = "Окно редактирования. " + _product.Name;
                TbxNumber.Text = _product.Number;
                TbxName.Text = _product.Name;
                TbxDescription.Text = _product.Description;
                TbxWeight.Text = _product.Weight.ToString();
                TbxUnit.Text = _product.MeasureUnit;
                TbxPrice.Text = _product.Price.ToString();
                if (_product.Certificate.DateEnd > DateTime.Now)
                {
                    TbxCertificate.Text = _product.Certificate.Info;
                    BtnAddCertificate.IsEnabled = false;
                    TbkCertificateInfo.Visibility = Visibility.Visible;
                }
                else
                {
                    TbxCertificate.Text = "Добавьте сертификат...";
                    BtnAddCertificate.IsEnabled = true;
                    TbkCertificateInfo.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                TbxNumber.Text = GenerateNumber();
                TbkCertificateInfo.Visibility = Visibility.Hidden;
                BtnAddCertificate.IsEnabled = true;
                TbxCertificate.Text = "Добавьте сертификат...";
                Title = "Окно добавления. Новый продукт";
            }
        }

        private static string GenerateNumber()
        {
            string number = "";
            bool IsUniq = false;
            while (!IsUniq)
            {
                int count = AppData.Context.Product.ToList().Count + 1;
                if (count < 10)
                    number += "0" + count;
                else
                    number += count;

                Random rand = new Random();
                number += rand.Next(10000000, 100000000).ToString();

                if (AppData.Context.Product.ToList().FirstOrDefault(i => i.Number == number) == null)
                    IsUniq = true;
            }
            return number;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.Question("Вы уверены? Не сохранённые данные будут утеряны.") == MessageBoxResult.Yes)
                Close();
        }

        private void Tbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text[0] == '.' && (sender as TextBox).Text.Contains('.'))
                e.Handled = true;
            else if (e.Text[0] != '.' && !Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }

        private void TextBlock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddCertificateWindow window = new AddCertificateWindow(_product.Certificate)
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
        }

        private void BtnAddCertificate_Click(object sender, RoutedEventArgs e)
        {
            AddCertificateWindow window = new AddCertificateWindow(null)
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
        }
    }
}
