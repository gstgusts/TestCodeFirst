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
using TestCodeFirst;

namespace WpfApp1
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BloggingContext())
            {
                var blog = new Blog { Name = textBox.Text };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BloggingContext())
            {
                var blogEntries = db.Blogs.Select(a=> new { Id=a.BlogId, Name=a.Name }).ToList();
                dataGrid.ItemsSource = blogEntries;
            }
        }
    }
}
