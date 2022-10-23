using RegistryManager;
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
using WebBrowserUI.Events;

namespace WebBrowserUI
{
    /// <summary>
    /// Logique d'interaction pour SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {

        public delegate void SettingsEvent(object sender, SettingsEventArgs e);

        public event SettingsEvent SettingsSetEvent;

        public SettingsWindow()
        {
            InitializeComponent();

            darkModeCheckBox.IsChecked = RegistryUtils.getDarkMode();
            defaultUrlTxt.Text = RegistryUtils.getDefaultUrl();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {


            string defaultUrl = defaultUrlTxt.Text;
            bool isDarkMode;

            if (darkModeCheckBox.IsChecked == true)
            {
                isDarkMode = true;
            }
            else
            {
                isDarkMode = false;
            }

            SettingsSetEvent(this, new SettingsEventArgs(isDarkMode, defaultUrl));

            Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }

}
