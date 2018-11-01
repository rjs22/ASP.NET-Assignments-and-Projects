using System.Data;
using System.Windows;
using System.Windows.Input;

namespace RWXmlAssign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string xmlPath = @"us-states.xml";
        private DataSet ds = new DataSet();

        public MainWindow()
        {
            InitializeComponent();
            BindData();
        }

        // Binding data to the dataset and converting it to a datagrid
        private void BindData()
        {
            ds.ReadXml(xmlPath); // uses dataset to read in xml file
            DataView dv = new DataView(ds.Tables["state"]); // sets the dataset to a data view.
            dgState.ItemsSource = dv; // sets the source of the datagrid to the xml file being read in.
        }


        // Key events to trigger saving and edits.
        private new void KeyDown(object sender, KeyEventArgs e)
        {
            DataRow drInsert = ds.Tables["state"].NewRow(); // setup for insert of new row
            drInsert.SetParentRow(ds.Tables["states"].Rows[0]); // setting parent row
            
            // when pressing the enter or tab key, it saves the data
            if (e.Key == Key.Enter || e.Key == Key.Tab )
            {
                dgState.CommitEdit();
                ds.WriteXml(xmlPath);
            }

            // when pressing enter key, it creates a new row in the datagrid
            if (e.Key == Key.Enter && dgState.Items.Count - 1 == dgState.SelectedIndex)
            {
                ds.Tables["state"].Rows.Add(drInsert);
            }
            
        }
        
        // event for delete button
        private void btnDeleteRecord(object sender, RoutedEventArgs e)
        {
            while (dgState.SelectedItems.Count > 0)
            {
                DataRowView drv = (DataRowView)dgState.SelectedItem; // takes in the row selected to know which row to delete
                drv.Row.Delete();
                ds.WriteXml(xmlPath);
            }
        }
            
    }
}
