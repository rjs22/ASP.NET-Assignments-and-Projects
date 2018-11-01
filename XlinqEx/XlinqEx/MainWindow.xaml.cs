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

namespace XlinqEx
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Create a root node
            XElement authors = new XElement("Authors");
            // Add child nodes
            XAttribute name = new XAttribute("Author", "Mahesh Chand");
            XElement book = new XElement("Book", "GDI+ Programming");
            XElement cost = new XElement("Cost", "$49.95");
            XElement publisher = new XElement("Publisher", "Addison-Wesley");
            XElement author = new XElement("Author");
            author.Add(name);
            author.Add(book);
            author.Add(cost);
            author.Add(publisher);
            authors.Add(author);

            name = new XAttribute("Name", "Mike Gold");
            book = new XElement("Book", "Programmer's Guide to C#");
            cost = new XElement("Cost", "$44.95");
            publisher = new XElement("Publisher", "Microgold Publishing");
            author = new XElement("Author");
            author.Add(name);
            author.Add(book);
            author.Add(cost);
            author.Add(publisher);
            authors.Add(author);

            name = new XAttribute("Name", "Scott Lysle");
            book = new XElement("Book", "Custom Controls");
            cost = new XElement("Cost", "$39.95");
            publisher = new XElement("Publisher", "C# Corner");
            author = new XElement("Author");
            author.Add(name);
            author.Add(book);
            author.Add(cost);
            author.Add(publisher);
            authors.Add(author);

            authors.Save(@"Authors.xml");
        }
    }
}
