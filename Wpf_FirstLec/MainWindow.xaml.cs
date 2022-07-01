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

namespace Wpf_FirstLec
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> list;
        public MainWindow()
        {
            InitializeComponent();
            list = new List<string>();
            list.Add("Apple");
            list.Add("Kiwi");
            list.Add("Orange");
            list.Add("Banana");
            cb1.ItemsSource = list;

        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("My First WPF App");        
        }
    }
}
