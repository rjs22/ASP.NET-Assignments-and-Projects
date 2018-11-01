using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DataGridEx2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string xmlPath = @"Books.xml";
        private DataSet ds = new DataSet();
        
        public MainWindow()
        {
            InitializeComponent();
            BindData();
        }

        public void BindData()
        {
            ds.ReadXml(xmlPath);
            DataView dv = new DataView(ds.Tables[0]);
            dgBooks.ItemsSource = dv;

        }

        private void btnDeleteRecord(object sender, RoutedEventArgs e)
        {
            while (dgBooks.SelectedItems.Count > 0)
            {
                DataRowView drv = (DataRowView)dgBooks.SelectedItem;
                drv.Row.Delete();
            }
        }

        private void DataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                DataGrid grd = (DataGrid)sender;
                grd.BeginEdit(e);
                ds.WriteXml(xmlPath);
            }
        }

        private new void KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter || e.Key == Key.Tab)
            {
                dgBooks.CommitEdit();
                ds.WriteXml(xmlPath);
            }

            

        }
    }
}
