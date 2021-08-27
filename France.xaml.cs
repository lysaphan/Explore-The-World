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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for France.xaml
    /// </summary>
    public partial class France : Window
    {
        public France()
        {
            InitializeComponent();
        }

        private void ChangeColor(object sender, RoutedEventArgs e)
        {
            
        }


        private void MoveToParisWin(object sender, RoutedEventArgs e)
        {
            ParisWindow Pwin = new ParisWindow();
            Pwin.Show();
            this.Close();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwin = new MainWindow();
            mwin.Show();
            this.Close();
        }
    }
}
