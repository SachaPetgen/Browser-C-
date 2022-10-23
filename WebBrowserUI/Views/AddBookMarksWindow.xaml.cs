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

namespace WebBrowserUI
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class AddBookmarksWindow : Window
    {

        public delegate void BookMarkEvent(object sender, BookMarkAddEventArgs e);

        public event BookMarkEvent BookMarkAddEvent;

        public AddBookmarksWindow()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {

            string name = txtName.Text;
            string tagString = txtTags.Text;

            List<String> tagList = new List<string>();

            foreach (string tag in tagString.Split(','))
            {
                tagList.Add(tag.Trim());
            }

            if(name != "")
            {
                BookMarkAddEvent(this, new BookMarkAddEventArgs(name, tagList));

            }

            Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
