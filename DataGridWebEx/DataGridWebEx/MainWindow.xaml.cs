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
using System.Xml.Linq;

namespace DataGridWebEx
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string _xmlPath = @"List.xml";
        private XDocument _xDocument;

        public MainWindow()
        {
            InitializeComponent();
            BindXmlToDataGrid();
        }

        private void BindXmlToDataGrid()
        {
            _xDocument = XDocument.Load(_xmlPath);

            var items = from book in _xDocument.Root.Elements("Book") select book;

            this.dataGrid1.ItemsSource = items;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Do you want to save xml file?", "Closing", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);

            switch (result)
            {
                case MessageBoxResult.Cancel:
                    e.Cancel = true;
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Yes:
                    _xDocument.Save(_xmlPath);
                    break;
                default:
                    break;
            }
        }
    }
}
