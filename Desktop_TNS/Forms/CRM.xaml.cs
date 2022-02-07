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

namespace Desktop_TNS.Forms
{
    /// <summary>
    /// Логика взаимодействия для CRM.xaml
    /// </summary>
    public partial class CRM : Page
    {
        public CRM()
        {
            InitializeComponent();
        }

        private void btClick(object sender, RoutedEventArgs e)
        {
            var abon = Models.context.GetContext().Abonents.Where(p => p.lastName == tbLastName.Text && p.phone == tbTel.Text).FirstOrDefault();
            if(abon != null)
            {
                tbLastName.Text = "";
                tbTel.Text = "";
                Models.AddBid add = new Models.AddBid(abon);
                add.Show();
            }
        }
    }
}
