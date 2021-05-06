using AverinApp.Entities;
using mshtml;
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
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        StringBuilder _builder = new StringBuilder();
        public ReportPage()
        {
            InitializeComponent();
        }

        private void SupplyReport()
        {
            List<Supply> supplies = AppData.Context.Supply.ToList().Where(i => i.Warehouse == AppData.CurrentUser.Operator.Warehouse.First()).ToList();

            if (DpSupplyStartDate.SelectedDate != null)
                supplies = supplies.Where(i => i.SupplyContract.Date >= DpSupplyStartDate.SelectedDate).ToList();

            if (DpSupplyEndDate.SelectedDate != null)
                supplies = supplies.Where(i => i.SupplyContract.Date <= DpSupplyEndDate.SelectedDate).ToList();

            _builder = new StringBuilder();

            _builder.Append("<html>");
            _builder.Append("<meta charset=\"utf-8\"/>");
            _builder.Append("<body>");

            _builder.Append($"<h1 align=\"center\"> <b>Отчёт отгрузок товаров на склад</b> </h1>");

            string massive = "";
            if (DpSupplyStartDate.SelectedDate == null && DpSupplyEndDate.SelectedDate == null)
                massive = "за всё время";
            else if (DpSupplyStartDate.SelectedDate != null && DpSupplyEndDate.SelectedDate == null)
                massive = $"от {DpSupplyStartDate.SelectedDate:dd MMMM yyyy}";
            else if (DpSupplyStartDate.SelectedDate != null && DpSupplyEndDate.SelectedDate != null)
                massive = $"от {DpSupplyStartDate.SelectedDate:dd MMMM yyyy} до {DpSupplyEndDate.SelectedDate:dd MMMM yyyy}";



            _builder.Append($"<h3 align=\"center\"> <b>В промежутке: {massive}</b> </h1>");
            _builder.Append($"<h3> <b>Всего записей: </b>{supplies.Count}</h3>");

            _builder.Append("<table width=\"100%\" align=\"center\" border=\"1\">");

            _builder.Append("<tr>");

            _builder.Append("<td align=\"center\"> <b>Номер</b> </td>");
            _builder.Append("<td align=\"center\"> <b>Дата прибытия</b> </td>");
            _builder.Append("<td align=\"center\"> <b>Поставщик</b> </td>");
            _builder.Append("<td align=\"center\"> <b>Товары</b> </td>");

            _builder.Append("</tr>");

            foreach (var item in supplies)
            {
                _builder.Append("<tr>");

                _builder.Append($"<td align=\"center\">{item.SupplyContractNumber}</td>");
                _builder.Append($"<td align=\"center\">{item.SupplyContract.Date:dd MMMM yyyy г. HH ч. mm мин.}</td>");
                _builder.Append($"<td align=\"center\">{item.Provider.Name}</td>");

                string products = "";
                foreach (var item2 in item.SupplyOfProduct)
                    products += $"&nbsp;&nbsp;{item2.Product.Name}, {item2.Count} шт.<br/>";

                _builder.Append($"<td align=\"left\">{products}</td>");

                _builder.Append("</tr>");
            }

            _builder.Append("</table>");
            _builder.Append($"<h3 align=\"right\"> <b>Оператор:</b> {AppData.CurrentUser.Operator.FullName}</h3>");
            _builder.Append($"<h3 align=\"right\"> <b>{AppData.CurrentUser.Operator.Warehouse.First().Name}</b></h3>");

            _builder.Append("</body>");
            _builder.Append("</html>");

            WBSupply.Visibility = Visibility.Visible;
            WBSupply.NavigateToString(_builder.ToString());
        }

        private void ShipmentReport()
        {
            List<Shipment> supplies = AppData.Context.Shipment.ToList().Where(i => i.Warehouse == AppData.CurrentUser.Operator.Warehouse.First()).ToList();

            if (DpShipmentStartDate.SelectedDate != null)
                supplies = supplies.Where(i => i.ShipmentContract.Date >= DpShipmentStartDate.SelectedDate).ToList();

            if (DpShipmentEndDate.SelectedDate != null)
                supplies = supplies.Where(i => i.ShipmentContract.Date <= DpShipmentEndDate.SelectedDate).ToList();

            _builder = new StringBuilder();

            _builder.Append("<html>");
            _builder.Append("<meta charset=\"utf-8\"/>");
            _builder.Append("<body>");

            _builder.Append($"<h1 align=\"center\"> <b>Отчёт отправок товаров со склада</b> </h1>");

            string massive = "";
            if (DpShipmentStartDate.SelectedDate == null && DpShipmentEndDate.SelectedDate == null)
                massive = "за всё время";
            else if (DpShipmentStartDate.SelectedDate != null && DpShipmentEndDate.SelectedDate == null)
                massive = $"от {DpShipmentStartDate.SelectedDate:dd MMMM yyyy}";
            else if (DpShipmentStartDate.SelectedDate != null && DpShipmentEndDate.SelectedDate != null)
                massive = $"от {DpShipmentStartDate.SelectedDate:dd MMMM yyyy} до {DpShipmentEndDate.SelectedDate:dd MMMM yyyy}";



            _builder.Append($"<h3 align=\"center\"> <b>В промежутке: {massive}</b> </h1>");
            _builder.Append($"<h3> <b>Всего записей: </b>{supplies.Count}</h3>");

            _builder.Append("<table width=\"100%\" align=\"center\" border=\"1\">");

            _builder.Append("<tr>");

            _builder.Append("<td align=\"center\"> <b>Номер</b> </td>");
            _builder.Append("<td align=\"center\"> <b>Дата отправки</b> </td>");
            _builder.Append("<td align=\"center\"> <b>Поставщик</b> </td>");
            _builder.Append("<td align=\"center\"> <b>Клиент</b> </td>");
            _builder.Append("<td align=\"center\"> <b>Товары</b> </td>");

            _builder.Append("</tr>");

            foreach (var item in supplies)
            {
                _builder.Append("<tr>");

                _builder.Append($"<td align=\"center\">{item.ShipmentContractNumber}</td>");
                _builder.Append($"<td align=\"center\">{item.ShipmentContract.Date:dd MMMM yyyy г. HH ч. mm мин.}</td>");
                _builder.Append($"<td align=\"center\">{item.Provider.Name}</td>");
                _builder.Append($"<td align=\"center\">{item.Client.Address}</td>");

                string products = "";
                foreach (var item2 in item.ShipmentOfProduct)
                    products += $"&nbsp;&nbsp;{item2.Product.Name}, {item2.Count} шт.<br/>";

                _builder.Append($"<td align=\"left\">{products}</td>");

                _builder.Append("</tr>");
            }

            _builder.Append("</table>");
            _builder.Append($"<h3 align=\"right\"> <b>Оператор:</b> {AppData.CurrentUser.Operator.FullName}</h3>");
            _builder.Append($"<h3 align=\"right\"> <b>{AppData.CurrentUser.Operator.Warehouse.First().Name}</b></h3>");

            _builder.Append("</body>");
            _builder.Append("</html>");

            WBShipment.Visibility = Visibility.Visible;
            WBShipment.NavigateToString(_builder.ToString());
        }


        private void BtnShipments_Click(object sender, RoutedEventArgs e)
        {
            GridShipments.Visibility = Visibility.Visible;
            SPType.Visibility = Visibility.Hidden;
        }

        private void BtnSupplies_Click(object sender, RoutedEventArgs e)
        {
            GridSupplies.Visibility = Visibility.Visible;
            SPType.Visibility = Visibility.Hidden;
        }

        private void BtnSupplyPrint_Click(object sender, RoutedEventArgs e)
        {
            if (WBSupply.Visibility == Visibility.Visible)
            {
                IHTMLDocument2 document = WBSupply.Document as IHTMLDocument2;
                document.execCommand("Print");
                BtnSupplyBack_Click(null, null);
            }
        }

        private void BtnSupplyBack_Click(object sender, RoutedEventArgs e)
        {
            GridSupplies.Visibility = Visibility.Hidden;
            SPType.Visibility = Visibility.Visible;
            WBSupply.Visibility = Visibility.Hidden;
            _builder = new StringBuilder();
        }

        private void BtnSupplyReport_Click(object sender, RoutedEventArgs e)
        {
            SupplyReport();
        }

        private void BtnSupplyClear_Click(object sender, RoutedEventArgs e)
        {
            DpSupplyStartDate.SelectedDate = DpSupplyEndDate.SelectedDate = null;
            SupplyReport();
        }

        private void BtnShipmentPrint_Click(object sender, RoutedEventArgs e)
        {
            if (WBShipment.Visibility == Visibility.Visible)
            {
                IHTMLDocument2 document = WBShipment.Document as IHTMLDocument2;
                document.execCommand("Print");
                BtnShipmentBack_Click(null, null);
            }
        }

        private void BtnShipmentBack_Click(object sender, RoutedEventArgs e)
        {
                GridShipments.Visibility = Visibility.Hidden;
                SPType.Visibility = Visibility.Visible;
                WBShipment.Visibility = Visibility.Hidden;
                _builder = new StringBuilder();
        }

        private void BtnShipmentClear_Click(object sender, RoutedEventArgs e)
        {
            DpShipmentStartDate.SelectedDate = DpShipmentEndDate.SelectedDate = null;
            ShipmentReport();
        }

        private void BtnShipmentReport_Click(object sender, RoutedEventArgs e)
        {
            ShipmentReport();
        }
    }
}
