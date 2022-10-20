using CefSharp;
using Microsoft.Win32;
using Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WebBrowserUI.Events;
using RegistryManager;
using System.Windows.Media;
using WebBrowserUI.Views;
using System.Diagnostics;

namespace WebBrowserUI
{

    public partial class WebBrowserWindow : Window
    {

        private HistoryWindow _historyWindow;


        private WebBrowserViewModel _viewModel;


        public WebBrowserWindow()
        {

            InitializeComponent();
            RegistryUtils.SetDefaultValues();
            SetColorMode();

            _viewModel = new WebBrowserViewModel();

            _historyWindow = new HistoryWindow();

            BookMarks.DataContext = _bookMarkViewModel;

            _viewModel.NewBrowser();

            tabControl.SelectedItem = _viewModel.ActualBrowser;

            DataContext = _viewModel;

        }

        /// <summary>
        /// COMMAND HANDLERS
        /// </summary>

        private void textBox_EnterKeyDown(object sender, KeyEventArgs e)
        {

            if(e.Key == Key.Return)
            {
                _viewModel.Load(searchTextBox.Text);
            }

        }

        

        /// <summary>
        /// EVENTS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void OnClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Application.Current.Shutdown();
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.ActualBrowser = (BrowserWrapper) tabControl.SelectedItem;
        }


        /// <summary>
        /// UTILS
        /// </summary>

        private void SetColorMode()
        {
            if (RegistryUtils.getDarkMode() == false)
            {
                Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                Background = new SolidColorBrush(Colors.Black);
            }
        }

    }
}
