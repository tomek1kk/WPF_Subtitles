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

namespace WPF_Subtitles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            double currentMS;
            double.TryParse(txtNum.Text, out currentMS);
            currentMS += 1000;

            txtNum.Text = currentMS.ToString();
        }
        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            double currentMS;
            double.TryParse(txtNum.Text, out currentMS);
            currentMS -= 1000;

            txtNum.Text = currentMS.ToString();
        }
    }
}
