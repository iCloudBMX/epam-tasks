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

namespace DotnetFundamentals.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextbox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show($"Username cannot be null or white space");
                return;
            }

            MessageBox.Show($"Hello {username}");
        }
    }
}
