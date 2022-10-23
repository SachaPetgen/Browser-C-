
using Models;
using RegistryManager;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WebBrowserUI
{

    public partial class MainWindow : Window
    {

        private readonly MainViewModel _viewModel;


        public MainWindow()
        {

            InitializeComponent();

            RegistryUtils.SetDefaultValues();

            _viewModel = new MainViewModel();

            DataContext = _viewModel;

            BookMarks.DataContext = _viewModel.BookMarkViewModel;

            tabControl.SelectedItem = _viewModel.ActualBrowser;
        }

        /// <summary>
        /// COMMAND HANDLERS
        /// </summary>

        private void textBox_EnterKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
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


    }
}
