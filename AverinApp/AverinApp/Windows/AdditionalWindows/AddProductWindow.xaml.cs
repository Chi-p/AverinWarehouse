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
        private readonly string _status;
        public static Certificate _certificate;

        public AddProductWindow(Product product, string status)
        {
            InitializeComponent();
            _product = product;
            _status = status;
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
            if (_status == "new")
                Save("new");
            else
                Save("edit");
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
            Save("check");
            AddCertificateWindow window = new AddCertificateWindow(_product, "edit")
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
            if (_certificate != null)
                TbxCertificate.Text = _certificate.Info;
        }


        private bool Save(string status)
        {
            if (string.IsNullOrWhiteSpace(TbxName.Text) || string.IsNullOrWhiteSpace(TbxDescription.Text) || string.IsNullOrWhiteSpace(TbxWeight.Text)
                || string.IsNullOrWhiteSpace(TbxUnit.Text) || string.IsNullOrWhiteSpace(TbxPrice.Text))
            {
                AppData.Message.Error("Сначала заполните все поля.");
                return false;
            }
            else
            {
                var products = AppData.Context.Product.ToList();
                if (_product == null)
                {
                    if (products.FirstOrDefault(i => i.Name == TbxName.Text) != null)
                    {
                        AppData.Message.Error("Продукт с указанным названием уже существует.");
                        return false;
                    }
                    _product = new Product
                    {
                        Number = TbxNumber.Text,
                        Name = TbxName.Text,
                        Description = TbxDescription.Text,
                        Weight = Convert.ToDecimal(TbxWeight.Text),
                        MeasureUnit = TbxUnit.Text,
                        Price = Convert.ToDecimal(TbxPrice.Text),
                    };
                }
                else
                {
                    if (products.FirstOrDefault(i => i.Name == TbxName.Text && i.Name != _product.Name) != null)
                    {
                        AppData.Message.Error("Продукт с указанным названием уже существует.");
                        return false;
                    }
                }

                if (status == "new")
                {
                    if (_certificate == null)
                    {
                        AppData.Message.Error("Добавьте сертификат.");
                        return false;
                    }
                    _product.Name = TbxName.Text;
                    _product.Description = TbxDescription.Text;
                    _product.Weight = Convert.ToDecimal(TbxWeight.Text);
                    _product.MeasureUnit = TbxUnit.Text;
                    _product.Price = Convert.ToDecimal(TbxPrice.Text);
                    _product.Certificate = _certificate;
                    AppData.Context.Product.Add(_product);
                    AppData.Context.SaveChanges();
                    AppData.Message.Info("Продукт успешно сохранён!");
                    Close();
                }

                if (status == "edit")
                {
                    _product.Name = TbxName.Text;
                    _product.Description = TbxDescription.Text;
                    _product.Weight = Convert.ToDecimal(TbxWeight.Text);
                    _product.MeasureUnit = TbxUnit.Text;
                    _product.Price = Convert.ToDecimal(TbxPrice.Text);
                    _product.Certificate = _certificate;
                    AppData.Context.SaveChanges();
                    AppData.Message.Info("Продукт успешно сохранён!");
                    Close();
                }
                return true;
            }
        }

        private void BtnAddCertificate_Click(object sender, RoutedEventArgs e)
        {
            if (Save("check"))
            {
                AddCertificateWindow window = new AddCertificateWindow(_product, "edit")
                {
                    Owner = Window.GetWindow(this)
                };
                window.ShowDialog();
            }
            if (_certificate != null)
                TbxCertificate.Text = _certificate.Info;
        }
    }
}
