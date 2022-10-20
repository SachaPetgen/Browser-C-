using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using CefSharp;
using CefSharp.Wpf;
using Microsoft.Win32;
using Models;
using RegistryManager;
using WebBrowserUI.ViewModels;
using WebBrowserUI.Views;

namespace WebBrowserUI
{
    public class WebBrowserViewModel : INotifyPropertyChanged
    {

        public DelegateCommand PreviousCommand { get; set; }
        public DelegateCommand ForwardCommand { get; set; }
        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand HomeCommand { get; set; }
        public DelegateCommand NewTabCommand { get; set; }
        public DelegateCommand AddFavCommand { get; set; }
        public DelegateCommand OpenHistoryCommand { get; set; }
        public DelegateCommand OpenMenuCommand { get; set; }
        public DelegateCommand OpenBookmarksCommand { get; set; }
        public DelegateCommand OpenSettingsCommand { get; set; }
        public DelegateCommand LoadBookmarksCommand { get; set; }
        public DelegateCommand SaveBookmarksCommand { get; set; }
        public DelegateCommand ClearHistoryCommand { get; set; }

        public ObservableCollection<BrowserWrapper> Browsers { get; set; }

        private BrowserWrapper _actualBrowser;

        private BookMarkViewModel _bookMarkViewModel;


        public BrowserWrapper ActualBrowser
        {
            get
            {
                return _actualBrowser;
            }
            set
            {
                _actualBrowser = value;
                PropertyChangedEventHandler();
            }
        }

        public WebBrowserViewModel()
        {
            Browsers = new ObservableCollection<BrowserWrapper>();

            PreviousCommand = new DelegateCommand(previousCommand_Executed);
            ForwardCommand = new DelegateCommand(forwardCommand_Executed);
            RefreshCommand = new DelegateCommand(refreshCommand_Executed);
            HomeCommand = new DelegateCommand(homeCommand_Executed);
            NewTabCommand = new DelegateCommand(newTabCommand_Executed);
            AddFavCommand = new DelegateCommand(addFavCommand_Executed);
            OpenHistoryCommand = new DelegateCommand(openHistoryCommand_Executed);
            OpenMenuCommand = new DelegateCommand(openMenuCommand_Executed);
            OpenBookmarksCommand = new DelegateCommand(openBookmarksCommand_Executed);
            OpenSettingsCommand = new DelegateCommand(openSettingsCommand_Executed);
            LoadBookmarksCommand = new DelegateCommand(loadBookmarksCommand_Executed);
            SaveBookmarksCommand = new DelegateCommand(saveBookmarksCommand_Executed);
            ClearHistoryCommand = new DelegateCommand(clearHistoryCommand_Executed);

            _bookMarkViewModel = new BookMarkViewModel();


        }

        public void NewBrowser()
        {
            ActualBrowser = new BrowserWrapper();
            Load(RegistryUtils.getDefaultUrl());
            ActualBrowser.Browser.FrameLoadEnd += OnFrameLoadEnd;
            ActualBrowser.Browser.AddressChanged += Browser_AddressChanged;
            ActualBrowser.Browser.TitleChanged += Browser_TitleChanged;
            Browsers.Add(ActualBrowser);
        }

        private void Browser_TitleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                ActualBrowser.CurrentTitle = e.NewValue as string;

            }));
        }

        private void Browser_AddressChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                ActualBrowser.CurrentUrl = e.NewValue as string;

            }));
        }

        private void OnFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.HttpStatusCode == 200)
            {
                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    HistoryWebPage historyWebPage = new(ActualBrowser.CurrentUrl, ActualBrowser.CurrentTitle);
                    HistoryWindow.ViewModel.AddHistory(historyWebPage);

                }));
            }
        }

        public void OnBookMarkAddEvent(object sender, BookMarkAddEventArgs e)
        {
            BookMarkWebPage bookMarkWebPage = new BookMarkWebPage(_viewModel.ActualBrowser.CurrentUrl, _viewModel.ActualBrowser.CurrentTitle, e.Name, e.TagList);
            _bookMarkViewModel.AddBookMark(bookMarkWebPage);
        }

        public void OnSettingsSetEvent(object sender, SettingsEventArgs e)
        {
            if (e.defaultUrl != "")
            {
                RegistryUtils.setDefaultUrl(e.defaultUrl);
            }

            Debug.WriteLine(e.isDarkMode);

            RegistryUtils.setDarkMode(e.isDarkMode);
            SetColorMode();
        }

        public void Load(string url)
        {
            ActualBrowser.CurrentUrl = url;
            ActualBrowser.Browser.Load(url);
        }

        private void PropertyChangedEventHandler([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void refreshCommand_Executed(object sender)
        {
            ActualBrowser.Browser.Reload();
        }


        private void addFavCommand_Executed(object sender)
        {
            AddBookMarksWindow addBookMarksWindow = new AddBookMarksWindow();

            addBookMarksWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            addBookMarksWindow.BookMarkAddEvent += OnBookMarkAddEvent;
            addBookMarksWindow.ShowDialog();
        }


        private void forwardCommand_Executed(object sender)
        {
            if (ActualBrowser.Browser.CanGoForward)
            {
                ActualBrowser.Browser.Forward();

            }
        }


        private void homeCommand_Executed(object sender)
        {
            Load(RegistryUtils.getDefaultUrl());
        }



        private void openHistoryCommand_Executed(object sender)
        {
            Show();
        }


        private void previousCommand_Executed(object sender)
        {
            if (ActualBrowser.Browser.CanGoBack)
            {
                ActualBrowser.Browser.Back();
            }
        }


        private void newTabCommand_Executed(object sender)
        {
            NewBrowser();
            tabControl.SelectedItem = _viewModel.ActualBrowser;
        }



        private void openMenuCommand_Executed(object sender)
        {
            ContextMenu cm = FindResource("menu") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            cm.IsOpen = true;
        }

        private void openBookmarksCommand_Executed(object sender)
        {
            BookMarkWebPage bookMarkWebPage = (e.OriginalSource as FrameworkElement)?.DataContext as BookMarkWebPage;
            _viewModel.Load(bookMarkWebPage.Url);
        }
        private void saveBookmarksCommand_Executed(object sender)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml file|*.xml";
            saveFileDialog.Title = "Save bookmarks to xml";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                _bookMarkViewModel.SaveBookMarksToXML(saveFileDialog.FileName);
            }
        }

        private void loadBookmarksCommand_Executed(object sender)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Xml file|*.xml";
            openFileDialog.Title = "Save bookmarks to xml";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                _bookMarkViewModel.LoadBookMarksFromXML(openFileDialog.FileName);
            }
        }

        private void openSettingsCommand_Executed(object sender)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            settingsWindow.SettingsSetEvent += OnSettingsSetEvent;
            settingsWindow.ShowDialog();
        }
        private void clearHistoryCommand_Executed(object sender)
        {
            HistoryWindow.ViewModel.ClearHistory();

        }
    }
}
