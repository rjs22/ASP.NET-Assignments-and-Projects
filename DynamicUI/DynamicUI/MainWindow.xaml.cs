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

namespace DynamicUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBox txtMessage = new TextBox();
        public MainWindow()
        {
            InitializeComponent();

            // Create label and add to stack panel
            Label lblMessage = new Label();
            lblMessage.Content = "Message:";
            stpContainer.Children.Add(lblMessage);

            // Create textbox and add to stack panel
            
            stpContainer.Children.Add(txtMessage);

            // Create button and add to stack panel
            Button btnGo = new Button();
            btnGo.Content = "Go!";
            btnGo.Padding.Equals(20);
            btnGo.Background = Brushes.Red;
            btnGo.Click += showMessage;
            stpContainer.Children.Add(btnGo);
        }

        private void showMessage(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(txtMessage.Text);
        }
    }
}
