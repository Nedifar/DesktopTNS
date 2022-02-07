using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Desktop_TNS.Models
{
    /// <summary>
    /// Логика взаимодействия для AddBid.xaml
    /// </summary>
    public partial class AddBid : Window
    {
        private Models.Bid _bid = new Bid();
        Abonent abo;
        public AddBid(Models.Abonent abonent)
        {
            InitializeComponent();
            abo = abonent;
            _bid.bidNumber = abonent.personalAcc + "/" + DateTime.Now.ToString("dd/MM/yyyy");
            _bid.dateCreated = DateTime.Now;
            _bid.personalAcc = abonent.personalAcc;
            _bid.Status = "Новая";
            gg.ItemsSource = Models.context.GetContext().Services.ToList();
            DataContext = _bid;
        }

        private async void clTry(object sender, RoutedEventArgs e)
        {
            using(var http = new HttpClient())
            {
                var response = await http.GetAsync($@"http://localhost:62727/api/Equipment/State?serialNumber={abo.SeriesNumber}");
                response.EnsureSuccessStatusCode();
                var res = response.Content.ReadAsStringAsync().Result;
                if (res == "1")
                {
                    _bid.Status = "Закрыта";
                    _bid.dateClosed = DateTime.Now;
                }
                else
                    _bid.Status = "Требует выезда";
                Models.context.GetContext().Bids.Add(_bid);
                Models.context.GetContext().SaveChanges();
                Close();
            }
        }
    }
}
