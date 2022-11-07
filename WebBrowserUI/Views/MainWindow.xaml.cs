
using Models;
using RegistryManager;
using System;
using System.ComponentModel;
using System.Reflection.Metadata;
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

        private void TextBox_EnterKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                _viewModel.Load(searchTextBox.Text);
            }

        }

        protected void OnClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Application.Current.Shutdown();
        }

        private void OpenMenuButton_Click(object sender, EventArgs e)
        {
            ContextMenu cm = this.FindResource("menu") as ContextMenu;
            cm.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            cm.IsOpen = true;
        }
    }
}
