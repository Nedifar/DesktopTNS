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
    /// Логика взаимодействия для ManageForm.xaml
    /// </summary>
    public partial class ManageForm : Page
    {
        public ManageForm()
        {
            InitializeComponent();
            dgMagistral.ItemsSource = Models.context.GetContext().Magistrals.Include(p => p.Equipment).ToList();
            dgAbonte.ItemsSource = Models.context.GetContext().AbontentEquipments.Include(p => p.Equipment).ToList();
            dgNetwork.ItemsSource = Models.context.GetContext().AccsessNetworks.Include(p => p.Equipment).ToList();
        }

        private async void clka(object sender, RoutedEventArgs e)
        {
            foreach(var item in dgMagistral.ItemsSource)
            {
                var iten = item as Models.Magistral;
                using(var http = new HttpClient())
                {
                    var response = await http.GetAsync($"http://localhost:62727/api/equipment/state?serialNumber={iten.Equipment.SeriesNumber}");
                    response.EnsureSuccessStatusCode();
                    var res = response.Content.ReadAsStringAsync().Result;
                    if(res == "0")
                    {
                        iten.Equipment.working = false;                     
                    }
                    else
                    {
                        iten.Equipment.working = true;
                    }
                    Models.context.GetContext().SaveChanges();
                }
            }
            dgMagistral.ItemsSource = Models.context.GetContext().Magistrals.Include(p => p.Equipment).ToList();
            MessageBoxResult resa = MessageBox.Show("nh", "yt", MessageBoxButton.OKCancel);
        }
    }
}
