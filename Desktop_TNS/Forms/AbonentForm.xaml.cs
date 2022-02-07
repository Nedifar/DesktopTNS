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
using System.Data.Entity;
using System.Net.Http;

namespace Desktop_TNS.Forms
{
    /// <summary>
    /// Логика взаимодействия для AbonentForm.xaml
    /// </summary>
    public partial class AbonentForm : Page
    {
        public AbonentForm()
        {
            InitializeComponent();
            dgAbonents.ItemsSource = Models.context.GetContext().Abonents.Include(p=>p.Services).ToList();
            //post();
        }

        private void clUpList(object sender, RoutedEventArgs e)
        {
            scr.LineUp();
        }

        private void clDownList(object sender, RoutedEventArgs e)
        {
            scr.LineDown();
        }

        private void dgAbonents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var abon = dgAbonents.SelectedItem as Models.Abonent;
                string txt = "Номер абонета: " + abon.AbonentNumber + "\n" +
                    "ФИО: " + abon.lastName + "\n" +
                    "Cерия паспорта: " + abon.passport_s + "\n" +
                    "Номер паспорта: " + abon.passport_n + "\n" +
                    "Дата выдачи: " + abon.IssuedDate.Value.ToShortDateString() + "\n" +
                    "Кем выдан: " + abon.AbonentNumber + "\n" +
                    "Номер договора с абонентом: " + abon.ContractNumber + "\n" +
                    "Дата заключения договора: " + abon.dateСonclusion + "\n" +
                    "Тип договора : " + abon.ContractType + "\n" +
                    "Дата расторжения договора: " + ((abon.dateRastor.HasValue) ? abon.dateRastor.Value.ToShortDateString() : "не расторгнут") + "\n" +
                    "Причина расторжения договора : " + abon.reasonContract + "\n";
                MessageBox.Show(txt);
            }
            catch { }
        }

        private void isCheck(object sender, RoutedEventArgs e)
        {
            if(activ.IsChecked == true && neactiv.IsChecked == true)
            {
                dgAbonents.ItemsSource = Models.context.GetContext().Abonents.ToList();
            }
            else if(activ.IsChecked == true && neactiv.IsChecked == false)
            {
                dgAbonents.ItemsSource = Models.context.GetContext().Abonents.Where(p=>p.dateRastor!=null).ToList();
            }
            else if (activ.IsChecked == false && neactiv.IsChecked == true)
            {
                dgAbonents.ItemsSource = Models.context.GetContext().Abonents.Where(p => p.dateRastor == null).ToList();
            }
            else
                dgAbonents.ItemsSource = Models.context.GetContext().Abonents.ToList();
        }
        //private async void post()
        //{
        //    using (var http = new HttpClient())
        //    {
        //        var response = await http.GetAsync("http://localhost:62727/api/Equipment/State?serialNumber=М0123ТНС312");
        //        response.EnsureSuccessStatusCode();
        //        var res = response.Content.ReadAsStringAsync().Result;
        //    }
        //}
    }
}
