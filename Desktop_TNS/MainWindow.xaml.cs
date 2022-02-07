using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Desktop_TNS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Forms.AbonentForm abonent;
        public MainWindow()
        {
            InitializeComponent();
            Frame.MainFrame = frame;
            abonent = new Forms.AbonentForm();
            frame.Navigate(abonent);
            cbUsers.ItemsSource = Models.context.GetContext().Employees.ToList();

            //import();
            //importjson();
        }
        public void import()
        {
            var lines = File.ReadAllLines(@"C:\Users\Nedifar\Desktop\imp\Заявку.txt");
            foreach (var line in lines)
            {
                string[] mm = line.Split('\t');
                string num = mm[3];
                var distr = new Models.Bid
                {
                    bidNumber = mm[0],
                    dateCreated = Convert.ToDateTime(mm[1]),
                    personalAcc = mm[2],
                    ServiceView = mm[4],
                    idService = Models.context.GetContext().Services.Where(p => p.Name == num).FirstOrDefault().idService,
                    ServiceType = mm[5],
                    Status = mm[6],
                    EquipmentType = mm[7],
                    Problem = mm[8],
                    problemType = mm[10]
                };
                if (mm[9] != "")
                    distr.dateClosed = Convert.ToDateTime(mm[9]);
                Models.context.GetContext().Bids.Add(distr);
                Models.context.GetContext().SaveChanges();
            }
        }
        public void importjson()
        {
            string r = File.ReadAllText(@"C:\Users\Nedifar\Desktop\_____\2_Основные\Сессия 2\Абоненты\Адреса абонентовd.json");
            var jsons = JsonConvert.DeserializeObject<List<Models.Address>>(r);
            foreach (var json in jsons)
            {
                var addres = new Models.Address
                {
                    AddressNumber = json.AddressNumber,
                    prefixCode = json.prefixCode,
                    house = json.house,
                    prefix = json.prefix,
                    Raion = json.Raion
                };
                Models.context.GetContext().Addresses.Add(addres);
            }
            Models.context.GetContext().SaveChanges();
        }

        private void selChang(object sender, SelectionChangedEventArgs e)
        {
            var mod = (sender as ComboBox).SelectedItem as Models.Employee;
            abonent.lv.ItemsSource = Models.context.GetContext().EmployeeInfos.Where(p => p.idEmployeeType == mod.idEmployeeType).ToList();
            if (File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}Resources/{mod.idEmployee}.jpg"))
            {
                img.Source = new BitmapImage(new Uri($"{AppDomain.CurrentDomain.BaseDirectory}Resources/{mod.idEmployee}.jpg"));
            }
            else
                img.Source = new BitmapImage(new Uri($"{AppDomain.CurrentDomain.BaseDirectory}Resources/zaglushka.jpg"));
            switch (mod.idEmployeeType)
            {
                case 1:
                    tnAbonent.Visibility = Visibility.Visible;
                    tnActives.Visibility = Visibility.Collapsed;
                    tnBiling.Visibility = Visibility.Visible;
                    tnCRM.Visibility = Visibility.Visible;
                    tnManage.Visibility = Visibility.Collapsed;
                    tnSupport.Visibility = Visibility.Collapsed;
                    break;
                case 8:
                    tnAbonent.Visibility = Visibility.Visible;
                    tnActives.Visibility = Visibility.Collapsed;
                    tnBiling.Visibility = Visibility.Collapsed;
                    tnCRM.Visibility = Visibility.Visible;
                    tnManage.Visibility = Visibility.Collapsed;
                    tnSupport.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    tnAbonent.Visibility = Visibility.Visible;
                    tnActives.Visibility = Visibility.Collapsed;
                    tnBiling.Visibility = Visibility.Collapsed;
                    tnCRM.Visibility = Visibility.Visible;
                    tnManage.Visibility = Visibility.Visible;
                    tnSupport.Visibility = Visibility.Visible;
                    break;
                case 3:
                    tnAbonent.Visibility = Visibility.Visible;
                    tnActives.Visibility = Visibility.Collapsed;
                    tnBiling.Visibility = Visibility.Collapsed;
                    tnCRM.Visibility = Visibility.Visible;
                    tnManage.Visibility = Visibility.Visible;
                    tnSupport.Visibility = Visibility.Visible;
                    break;
                case 7:
                    tnAbonent.Visibility = Visibility.Visible;
                    tnActives.Visibility = Visibility.Visible;
                    tnBiling.Visibility = Visibility.Visible;
                    tnCRM.Visibility = Visibility.Collapsed;
                    tnManage.Visibility = Visibility.Collapsed;
                    tnSupport.Visibility = Visibility.Collapsed;
                    break;
                case 5:
                    tnAbonent.Visibility = Visibility.Visible;
                    tnActives.Visibility = Visibility.Visible;
                    tnBiling.Visibility = Visibility.Visible;
                    tnCRM.Visibility = Visibility.Visible;
                    tnManage.Visibility = Visibility.Visible;
                    tnSupport.Visibility = Visibility.Visible;
                    break;
                case 6:
                    tnAbonent.Visibility = Visibility.Visible;
                    tnActives.Visibility = Visibility.Visible;
                    tnBiling.Visibility = Visibility.Collapsed;
                    tnCRM.Visibility = Visibility.Visible;
                    tnManage.Visibility = Visibility.Visible;
                    tnSupport.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void clMAnage(object sender, RoutedEventArgs e)
        {
            Frame.MainFrame.Navigate(new Forms.ManageForm());
            metod();
        }

        private void clAbo(object sender, RoutedEventArgs e)
        {
            abonent = new Forms.AbonentForm();
            Frame.MainFrame.Navigate(abonent);
            metod();
        }

        private void clActives(object sender, RoutedEventArgs e)
        {
            metod();
        }

        private void clBiling(object sender, RoutedEventArgs e)
        {
            metod();
        }

        private void clSupport(object sender, RoutedEventArgs e)
        {
            metod();
        }

        private void clCRM(object sender, RoutedEventArgs e)
        {
            metod();
            Frame.MainFrame.Navigate(new Forms.CRM());
        }
        private void metod()
        {
            col1.Width = new GridLength(col1.Width.Value == 47 ? 32 : 47, GridUnitType.Star);
        }


        private void Grid_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (col1.Width.Value == 32)
                metod();
        }

        private void Grid_MouseEnters(object sender, MouseButtonEventArgs e)
        {
            if (col1.Width.Value == 47)
                metod();
        }

        private void mm(object sender, MouseButtonEventArgs e)
        {
            if (col1.Width.Value == 32)
                metod();
        }

        private void col2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (col1.Width.Value == 32)
                metod();
        }

        private void ls(object sender, RoutedEventArgs e)
        {
            if (col1.Width.Value == 32)
                metod();
        }
    }
}
